﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PP.Core.Controllers;
using PP.Core.DomainObjects;
using PP.Core.Enums;
using PP.Core.Messages.Integration;
using PP.Core.User;
using PP.Identidade.API.Models;
using PP.Identidade.API.Services;
using PP.MessageBus;

namespace PP.Identidade.API.Controllers {
    [Authorize]
    [Route("identidade")]
    public class AuthController : MainController {
        private readonly IAspNetUser _user;
        private readonly AuthenticationService _authenticationService;
        private readonly IMessageBus _bus;

        public AuthController(AuthenticationService authenticationService,
                              IMessageBus bus, IAspNetUser user) {
            _authenticationService = authenticationService;
            _bus = bus;
            _user = user;
        }

        [AllowAnonymous]
        [HttpPost("novo-administrador")]
        public async Task<ActionResult> Registrar(AdministradorRegistro administradorRegistro) {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var administrador = await _authenticationService.UserManager.FindByEmailAsync(administradorRegistro.Email);

            if (administrador != null)
            {
                AdicionarErroProcessamento("E-mail já está em uso");
                return CustomResponse();
            }

            var user = new ApplicationUser {
                UserName = administradorRegistro.Email,
                Email = administradorRegistro.Email,
                UserType = TipoUsuario.Administrador,
                EmailConfirmed = true,
                IsActive = true
            };

            var result = await _authenticationService.UserManager.CreateAsync(user, administradorRegistro.Senha);

            foreach (var error in result.Errors) {
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse();
        }

        [AllowAnonymous]
        [HttpPost("novo-aluno")]
        public async Task<ActionResult> Registrar(AlunoRegistro alunoRegistro)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new ApplicationUser {
                UserName = alunoRegistro.Email,
                Email = alunoRegistro.Email,
                UserType = TipoUsuario.Aluno,
                EmailConfirmed = true,
                IsActive = true
            };

            var result = await _authenticationService.UserManager.CreateAsync(user, alunoRegistro.Senha);

            if (result.Succeeded)
            {
                var alunoResult = await RegistrarAluno(alunoRegistro);
                if (!alunoResult.ValidationResult.IsValid) {
                    await _authenticationService.UserManager.DeleteAsync(user);
                    return CustomResponse(alunoResult.ValidationResult);
                }

                return CustomResponse();
            }

            foreach (var error in result.Errors) {
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse();
        }

        [HttpPost("novo-professor")]
        public async Task<ActionResult> Registrar(ProfessorRegistro professorRegistro) {
            EhAdmin();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new ApplicationUser {
                UserName = professorRegistro.Email,
                Email = professorRegistro.Email,
                UserType = TipoUsuario.Professor,
                EmailConfirmed = true,
                IsActive = true
            };

            var result = await _authenticationService.UserManager.CreateAsync(user, professorRegistro.Senha);

            if (result.Succeeded) {
                var professorResult = await RegistrarProfessor(professorRegistro);
                if (!professorResult.ValidationResult.IsValid) {
                    await _authenticationService.UserManager.DeleteAsync(user);
                    return CustomResponse(professorResult.ValidationResult);
                }

                return CustomResponse();
            }

            foreach (var error in result.Errors) {
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse();
        }

        [HttpPut("alternar-situacao-aluno/{id}")]
        public async Task<ActionResult> AlternarSituacaoAluno(Guid id) {
            EhAdmin();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var userRegister = await _authenticationService.UserManager.FindByIdAsync(id.ToString());
            if (userRegister == null)
            {
                AdicionarErroProcessamento("Aluno não encontrado");
                return CustomResponse();
            }

            userRegister.AlternarAtivo();
            var result = await _authenticationService.UserManager.UpdateAsync(userRegister);

            if (result.Succeeded) {
                var alunoResult = await SituacaoAluno(userRegister);
                if (!alunoResult.ValidationResult.IsValid) {
                    userRegister.AlternarAtivo();
                    await _authenticationService.UserManager.UpdateAsync(userRegister);
                    return CustomResponse(alunoResult.ValidationResult);
                }
            }

            foreach (var error in result.Errors) {
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse();
        }

        [HttpPut("alternar-situacao-professor/{id}")]
        public async Task<ActionResult> AlternarSituacaoProfessor(Guid id) {
            EhAdmin();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var userRegister = await _authenticationService.UserManager.FindByIdAsync(id.ToString());
            if (userRegister == null) {
                AdicionarErroProcessamento("Professor não encontrado");
                return CustomResponse();
            }

            userRegister.IsActive = !userRegister.IsActive;
            var result = await _authenticationService.UserManager.UpdateAsync(userRegister);

            if (result.Succeeded) {
                var professorResult = await SituacaoProfessor(userRegister);
                if (!professorResult.ValidationResult.IsValid) {
                    userRegister.AlternarAtivo();
                    await _authenticationService.UserManager.UpdateAsync(userRegister);
                    return CustomResponse(professorResult.ValidationResult);
                }
            }

            foreach (var error in result.Errors) {
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse();
        }

        [AllowAnonymous]
        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(UsuarioLogin usuarioLogin) {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _authenticationService.SignInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha,
                false, true);

            if (result.Succeeded)
            {
                if (await VerificarUsuarioInativo(usuarioLogin.Email)) {
                    AdicionarErroProcessamento("Usuário desabilitado");
                    return CustomResponse();
                }

                return CustomResponse(await _authenticationService.GerarJwt(usuarioLogin.Email));
            }

            if (result.IsLockedOut) {
                AdicionarErroProcessamento("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse();
            }

            AdicionarErroProcessamento("Usuário ou Senha incorretos");
            return CustomResponse();
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken([FromBody] string refreshToken) {
            if (string.IsNullOrEmpty(refreshToken)) {
                AdicionarErroProcessamento("Refresh Token inválido");
                return CustomResponse();
            }

            var token = await _authenticationService.ObterRefreshToken(Guid.Parse(refreshToken));

            if (token is null) {
                AdicionarErroProcessamento("Refresh Token expirado");
                return CustomResponse();
            }

            return CustomResponse(await _authenticationService.GerarJwt(token.Username));
        }

        private async Task<ResponseMessage> RegistrarAluno(AlunoRegistro alunoRegistro) {
            var aluno = await _authenticationService.UserManager.FindByEmailAsync(alunoRegistro.Email);
            var alunoRegistrado = new AlunoRegistradoIntegrationEvent(Guid.Parse(aluno.Id), alunoRegistro.Nome,
                alunoRegistro.ProfessorId, alunoRegistro.Email, alunoRegistro.DataNascimento, alunoRegistro.Cep,
                alunoRegistro.Logradouro, alunoRegistro.Numero, alunoRegistro.Bairro, alunoRegistro.Complemento,
                alunoRegistro.Cidade, alunoRegistro.EstadoId);

            try {
                return await _bus.RequestAsync<AlunoRegistradoIntegrationEvent, ResponseMessage>(alunoRegistrado);
            } catch {
                await _authenticationService.UserManager.DeleteAsync(aluno);
                throw;
            }
        }

        private async Task<ResponseMessage> SituacaoAluno(ApplicationUser applicationUser) {
            var alunoAlternado = new AlternarSituacaoAlunoIntegrationEvent(Guid.Parse(applicationUser.Id));

            try {
                return await _bus.RequestAsync<AlternarSituacaoAlunoIntegrationEvent, ResponseMessage>(alunoAlternado);
            } catch {
                applicationUser.AlternarAtivo();
                await _authenticationService.UserManager.UpdateAsync(applicationUser);
                throw;
            }
        }

        private async Task<ResponseMessage> SituacaoProfessor(ApplicationUser applicationUser) {
            var professorAlternado = new AlternarSituacaoProfessorIntegrationEvent(Guid.Parse(applicationUser.Id));

            try {
                return await _bus.RequestAsync<AlternarSituacaoProfessorIntegrationEvent, ResponseMessage>(professorAlternado);
            } catch {
                applicationUser.AlternarAtivo();
                await _authenticationService.UserManager.UpdateAsync(applicationUser);
                throw;
            }
        }

        private async Task<ResponseMessage> RegistrarProfessor(ProfessorRegistro professorRegistro) {
            var professor = await _authenticationService.UserManager.FindByEmailAsync(professorRegistro.Email);
            var professorRegistrado = new ProfessorRegistradoIntegrationEvent(Guid.Parse(professor.Id),
                professorRegistro.Nome, professorRegistro.CREF, professorRegistro.Email);

            try {
                return await _bus.RequestAsync<ProfessorRegistradoIntegrationEvent, ResponseMessage>(professorRegistrado);
            } catch {
                await _authenticationService.UserManager.DeleteAsync(professor);
                throw;
            }
        }

        private async Task<bool> VerificarUsuarioInativo(string email)
        {
            var user = await _authenticationService.UserManager.FindByEmailAsync(email);

            return !user.IsActive;
        }

        private void EhAdmin()
        {
            if (!Equals(Enum.Parse<TipoUsuario>(_user.ObterTipo()), TipoUsuario.Administrador)) throw new DomainException("Somente administradores podem realizar essa tarefa");
        }
    }
}