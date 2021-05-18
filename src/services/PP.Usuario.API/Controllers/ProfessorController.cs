using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PP.Core.Controllers;
using PP.Core.DomainObjects;
using PP.Core.Enums;
using PP.Core.Mediator;
using PP.Core.User;
using PP.Usuario.API.Application.Commands.Professor;
using PP.Usuario.API.Models;
using PP.Usuario.API.ViewModels;

namespace PP.Usuario.API.Controllers {
    [Authorize]
    [Route("api/professor")]
    public class ProfessorController : MainController {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProfessorRepository _professorRepository;
        private readonly IMapper _mapper;
        private readonly IAspNetUser _user;

        public ProfessorController(IMediatorHandler mediatorHandler, IProfessorRepository professorRepository, IMapper mapper, IAspNetUser user) {
            _mediatorHandler = mediatorHandler;
            _professorRepository = professorRepository;
            _mapper = mapper;
            _user = user;
        }

        /// <summary>
        /// Atualiza um professor.
        /// </summary>
        /// <response code="204">Professor atualizado com sucesso</response>
        [HttpPut]
        public async Task<IActionResult> Index([FromBody] AtualizarProfessorCommand professorCommand) {
            EhUsuarioLogado(professorCommand.Id);

            var resultado = await _mediatorHandler.EnviarComando(professorCommand);

            return CustomResponse(resultado);
        }

        /// <summary>
        /// Obter todos os professores
        /// </summary>
        /// <response code="200">Lista de professores</response>
        [HttpGet]
        public async Task<IActionResult> Index() {
            EhAdmin();

            var alunos = await _professorRepository.ObterTodos();
            return CustomResponse(_mapper.Map<IEnumerable<ProfessorViewModel>>(alunos));
        }

        private void EhAdmin() {
            if (!Equals(Enum.Parse<TipoUsuario>(_user.ObterTipo()), TipoUsuario.Administrador)) throw new DomainException("Somente administradores podem realizar essa tarefa");
        }

        private void EhUsuarioLogado(Guid usuarioId) {
            if (_user.ObterUserId() != usuarioId) throw new DomainException("Só é permitida a auto edição de usuários");
        }
    }
}