using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PP.Bff.Identidades.Models;
using PP.Bff.Identidades.Models.Enums;
using PP.Bff.Identidades.Services;
using PP.Core.Controllers;

namespace PP.Bff.Identidades.Controllers {
    [Route("autenticacao")]
    public class AutenticacaoController : MainController
    {
        private readonly IIdentidadeService _identidadeService;
        private readonly IPermissaoService _permissaoService;

        public AutenticacaoController(IIdentidadeService identidadeService, IPermissaoService permissaoService)
        {
            _identidadeService = identidadeService;
            _permissaoService = permissaoService;
        }

        [HttpPost]
        public async Task<IActionResult> Autenticar(UsuarioLogin usuario)
        {
            var identidade = await _identidadeService.Autenticar(usuario);

            if (identidade == null) AdicionarErroProcessamento("Usuario ou Senha incorretos");
            else identidade.permissoes = await _permissaoService.ObterPermissao(TipoUsuario.Aluno, identidade.usuarioRespostaLogin.AccessToken);

            return CustomResponse(identidade);
        }
    }
}