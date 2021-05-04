using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PP.Core.Controllers;

namespace PP.Bff.Identidades.Controllers {
    [Authorize]
    [Route("autenticacao")]
    public class AutenticacaoController : MainController {
        [HttpGet]
        public async Task<IActionResult> Autenticar()
        {
            return CustomResponse();
        }
    }
}