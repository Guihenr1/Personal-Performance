using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PP.Core.Controllers;
using PP.Core.DomainObjects;
using PP.Core.Enums;
using PP.Core.Mediator;
using PP.Core.User;
using PP.Usuario.API.Application.Commands.Aluno;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Controllers {
    [Authorize]
    [Route("api/aluno")]
    public class AlunoController : MainController 
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAspNetUser _user;

        public AlunoController(IMediatorHandler mediatorHandler, IAlunoRepository alunoRepository, IAspNetUser user) {
            _mediatorHandler = mediatorHandler;
            _alunoRepository = alunoRepository;
            _user = user;
        }

        /// <summary>
        /// Atualiza um aluno.
        /// </summary>
        /// <response code="204">Aluno atualizado com sucesso</response>
        [HttpPut]
        public async Task<IActionResult> Index([FromBody] AtualizarAlunoCommand alunoCommand)
        {
            EhUsuarioLogado(alunoCommand.Id);

            var resultado = await _mediatorHandler.EnviarComando(alunoCommand);

            return CustomResponse(resultado);
        }

        /// <summary>
        /// Obter todos os alunos.
        /// </summary>
        /// <response code="200">Lista de alunos</response>
        [HttpGet]
        public async Task<PagedResult<Models.Aluno>> Index([FromQuery] int ps = 8, [FromQuery] int page = 1)
        {
            EhAdmin();

            return await _alunoRepository.ObterTodos(ps, page);
        }

        private void EhAdmin() {
            if (!Equals(Enum.Parse<TipoUsuario>(_user.ObterTipo()), TipoUsuario.Administrador)) throw new DomainException("Somente administradores podem realizar essa tarefa");
        }

        private void EhUsuarioLogado(Guid usuarioId)
        {
            if (_user.ObterUserId() != usuarioId) throw new DomainException("Só é permitida a auto edição de usuários");
        }
    }
}