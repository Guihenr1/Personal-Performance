using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PP.Bff.Identidades.Models;
using PP.Bff.Identidades.Services;
using PP.Core.Controllers;
using PP.Core.Enums;

namespace PP.Bff.Identidades.Controllers {
    [Route("autenticacao")]
    public class AutenticacaoController : MainController
    {
        private readonly IIdentidadeService _identidadeService;
        private readonly IPermissaoService _permissaoService;

        public AutenticacaoController(IIdentidadeService identidadeService, IPermissaoService permissaoService) {
            _identidadeService = identidadeService;
            _permissaoService = permissaoService;
        }

        [HttpPost]
        public async Task<IActionResult> Autenticar(UsuarioLogin usuario)
        {
            var identidade = await _identidadeService.Autenticar(usuario);

            if (identidade.Errors.Any()) identidade.Errors.ForEach(AdicionarErroProcessamento);
            else identidade.Permissoes = await _permissaoService.ObterPermissao(
                Enum.Parse<TipoUsuario>(identidade.UsuarioRespostaLogin.UsuarioToken
                    .Claims.First(x => x.Type == "UserType").Value), 
                identidade.UsuarioRespostaLogin.AccessToken);

            return CustomResponse(identidade);
        }
    }
}