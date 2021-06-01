using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PP.Core.Controllers;
using PP.Core.DomainObjects;
using PP.Core.Enums;
using PP.Core.Mediator;
using PP.Core.User;
using PP.Usuario.API.Application.Commands.Professor;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Controllers {
    [Authorize]
    [Route("api/professor")]
    public class ProfessorController : MainController {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProfessorRepository _professorRepository;
        private readonly IAspNetUser _user;

        public ProfessorController(IMediatorHandler mediatorHandler, IProfessorRepository professorRepository, IAspNetUser user) {
            _mediatorHandler = mediatorHandler;
            _professorRepository = professorRepository;
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
        public async Task<PagedResult<Professor>> Index([FromQuery] int ps = 8, [FromQuery] int page = 1) {
            EhAdmin();

            return await _professorRepository.ObterTodos(ps, page);
        }

        private void EhAdmin() {
            if (!Equals(Enum.Parse<TipoUsuario>(_user.ObterTipo()), TipoUsuario.Administrador)) throw new DomainException("Somente administradores podem realizar essa tarefa");
        }

        private void EhUsuarioLogado(Guid usuarioId) {
            if (_user.ObterUserId() != usuarioId) throw new DomainException("Só é permitida a auto edição de usuários");
        }
    }
}