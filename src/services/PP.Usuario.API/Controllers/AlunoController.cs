using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PP.Core.Controllers;
using PP.Core.Mediator;
using PP.Usuario.API.Application.Commands.Aluno;
using PP.Usuario.API.Models;
using PP.Usuario.API.ViewModels;

namespace PP.Usuario.API.Controllers
{
    [Route("api/aluno")]
    public class AlunoController : MainController 
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoController(IMediatorHandler mediatorHandler, IAlunoRepository alunoRepository, IMapper mapper) {
            _mediatorHandler = mediatorHandler;
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Atualiza um aluno.
        /// </summary>
        /// <response code="204">Aluno atualizado com sucesso</response>
        [HttpPut]
        public async Task<IActionResult> Index([FromBody] AtualizarAlunoCommand alunoCommand) {
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
            var alunos = await _alunoRepository.ObterTodos();
            return CustomResponse(_mapper.Map<IEnumerable<AlunoViewModel>>(alunos));
        }
    }
}