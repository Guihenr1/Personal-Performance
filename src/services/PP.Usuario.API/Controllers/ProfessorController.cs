using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PP.Core.Controllers;
using PP.Core.Mediator;
using PP.Usuario.API.Application.Commands.Professor;
using PP.Usuario.API.Models;
using PP.Usuario.API.ViewModels;

namespace PP.Usuario.API.Controllers {
    [Route("api/professor")]
    public class ProfessorController : MainController {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProfessorRepository _professorRepository;
        private readonly IMapper _mapper;

        public ProfessorController(IMediatorHandler mediatorHandler, IProfessorRepository professorRepository, IMapper mapper) {
            _mediatorHandler = mediatorHandler;
            _professorRepository = professorRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Atualiza um professor.
        /// </summary>
        /// <response code="204">Professor atualizado com sucesso</response>
        [HttpPut]
        public async Task<IActionResult> Index([FromBody] AtualizarProfessorCommand alunoCommand) {
            var resultado = await _mediatorHandler.EnviarComando(alunoCommand);

            return CustomResponse(resultado);
        }

        /// <summary>
        /// Obter todos os professores
        /// </summary>
        /// <response code="200">Lista de professores</response>
        [HttpGet]
        public async Task<IActionResult> Index() {
            var alunos = await _professorRepository.ObterTodos();
            return CustomResponse(_mapper.Map<IEnumerable<ProfessorViewModel>>(alunos));
        }
    }
}