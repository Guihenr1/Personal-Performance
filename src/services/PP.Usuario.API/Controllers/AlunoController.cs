using System;
using System.Collections;
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
using PP.Usuario.API.Application.Commands.Aluno;
using PP.Usuario.API.Models;
using PP.Usuario.API.ViewModels;

namespace PP.Usuario.API.Controllers {
    [Authorize]
    [Route("api/aluno")]
    public class AlunoController : MainController 
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;
        private readonly IAspNetUser _user;

        public AlunoController(IMediatorHandler mediatorHandler, IAlunoRepository alunoRepository, IMapper mapper, IAspNetUser user) {
            _mediatorHandler = mediatorHandler;
            _alunoRepository = alunoRepository;
            _mapper = mapper;
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
        public async Task<IActionResult> Index()
        {
            EhAdmin();

            var alunos = await _alunoRepository.ObterTodos();
            return CustomResponse(_mapper.Map<IEnumerable<AlunoViewModel>>(alunos));
        }

        private void EhAdmin() {
            if (!Equals(Enum.Parse<TipoUsuario>(_user.ObterTipo()), TipoUsuario.Admin)) throw new DomainException("Somente administradores podem realizar essa tarefa");
        }

        private void EhUsuarioLogado(Guid usuarioId)
        {
            if (_user.ObterUserId() != usuarioId) throw new DomainException("Só é permitida a auto edição de usuários");
        }
    }
}