using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PP.Core.Controllers;
using PP.Core.Messages.Integration;
using PP.Identidade.API.Models;
using PP.Identidade.API.Services;
using PP.MessageBus;

namespace PP.Identidade.API.Controllers {
    [Route("identidade")]
    public class AuthController : MainController {
        private readonly AuthenticationService _authenticationService;
        private readonly IMessageBus _bus;

        public AuthController(AuthenticationService authenticationService,
                              IMessageBus bus) {
            _authenticationService = authenticationService;
            _bus = bus;
        }

        [HttpPost("novo-aluno")]
        public async Task<ActionResult> Registrar(AlunoRegistro alunoRegistro) {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser {
                UserName = alunoRegistro.Email,
                Email = alunoRegistro.Email,
                EmailConfirmed = true
            };

            var result = await _authenticationService.UserManager.CreateAsync(user, alunoRegistro.Senha);

            if (result.Succeeded)
            {
                var alunoResult = await RegistrarAluno(alunoRegistro);
                if (!alunoResult.ValidationResult.IsValid) {
                    await _authenticationService.UserManager.DeleteAsync(user);
                    return CustomResponse(alunoResult.ValidationResult);
                }

                return CustomResponse(await _authenticationService.GerarJwt(alunoRegistro.Email));
            }

            foreach (var error in result.Errors) {
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse();
        }

        [HttpPost("novo-professor")]
        public async Task<ActionResult> Registrar(ProfessorRegistro professorRegistro) {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser {
                UserName = professorRegistro.Email,
                Email = professorRegistro.Email,
                EmailConfirmed = true
            };

            var result = await _authenticationService.UserManager.CreateAsync(user, professorRegistro.Senha);

            if (result.Succeeded) {
                var professorResult = await RegistrarProfessor(professorRegistro);
                if (!professorResult.ValidationResult.IsValid) {
                    await _authenticationService.UserManager.DeleteAsync(user);
                    return CustomResponse(professorResult.ValidationResult);
                }

                return CustomResponse(await _authenticationService.GerarJwt(professorRegistro.Email));
            }

            foreach (var error in result.Errors) {
                AdicionarErroProcessamento(error.Description);
            }

            return CustomResponse();
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(UsuarioLogin usuarioLogin) {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _authenticationService.SignInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha,
                false, true);

            if (result.Succeeded) {
                return CustomResponse(await _authenticationService.GerarJwt(usuarioLogin.Email));
            }

            if (result.IsLockedOut) {
                AdicionarErroProcessamento("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse();
            }

            AdicionarErroProcessamento("Usuário ou Senha incorretos");
            return CustomResponse();
        }
        
        private async Task<ResponseMessage> RegistrarAluno(AlunoRegistro alunoRegistro) {
            var aluno = await _authenticationService.UserManager.FindByEmailAsync(alunoRegistro.Email);
            var alunoRegistrado = new AlunoRegistradoIntegrationEvent(Guid.Parse(aluno.Id), alunoRegistro.Nome,
                alunoRegistro.ProfessorId, alunoRegistro.Email, alunoRegistro.DataNascimento, alunoRegistro.Cep,
                alunoRegistro.Logradouro, alunoRegistro.Numero, alunoRegistro.Bairro, alunoRegistro.Complemento,
                alunoRegistro.Cidade, alunoRegistro.EstadoId);

            try
            {
                return await _bus.RequestAsync<AlunoRegistradoIntegrationEvent, ResponseMessage>(alunoRegistrado);
            }
            catch
            {
                await _authenticationService.UserManager.DeleteAsync(aluno);
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
    }
}