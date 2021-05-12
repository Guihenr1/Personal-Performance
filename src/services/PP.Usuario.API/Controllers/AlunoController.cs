using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PP.Core.Controllers;
using PP.Core.Mediator;
using PP.Usuario.API.Application.Commands.Aluno;

namespace PP.Usuario.API.Controllers
{
    [Route("api/aluno")]
    public class AlunoController : MainController 
    {
        private readonly IMediatorHandler _mediatorHandler;

        public AlunoController(IMediatorHandler mediatorHandler) {
            _mediatorHandler = mediatorHandler;
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
        /// Exclui um aluno.
        /// </summary>
        /// <response code="204">Aluno excluido com sucesso</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Index(Guid id) {
            var resultado = await _mediatorHandler.EnviarComando(new RemoverAlunoCommand(id));

            return CustomResponse(resultado);
        }
    }
}