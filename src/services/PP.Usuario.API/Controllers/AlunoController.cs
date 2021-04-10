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

        public AlunoController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        /// <summary>
        /// Criar um aluno.
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// 
        ///     {
        ///         "Nome": "",
        ///         "ProfessorId": "",
        ///         "Email": "",
        ///         "DataNascimento": "",
        ///         "Cep": "",
        ///         "Logradouro": "",
        ///         "Numero": 0,
        ///         "Bairro": "",
        ///         "Complemento": "",
        ///         "Cidade": "",
        ///         "EstadoId": ""
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Aluno criado com sucesso</response>
        [HttpPost]
        public async Task<IActionResult> Index([FromBody]RegistrarAlunoCommand alunoCommand)
        {
            var resultado = await _mediatorHandler.EnviarComando(alunoCommand);

            return CustomResponse(resultado);
        }
    }
}