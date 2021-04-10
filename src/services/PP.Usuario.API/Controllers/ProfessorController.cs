using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PP.Core.Controllers;
using PP.Core.Mediator;
using PP.Usuario.API.Application.Commands.Professor;

namespace PP.Usuario.API.Controllers
{
    public class ProfessorController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ProfessorController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("professor")]
        public async Task<IActionResult> Index() {
            var resultado = await _mediatorHandler.EnviarComando(new RegistrarProfessorCommand(
                "Eduardo", 1452, "eduardo.prof@gmail.com"));

            return CustomResponse(resultado);
        }
    }
}