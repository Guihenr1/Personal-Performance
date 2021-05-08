using System.Collections.Generic;

namespace PP.Bff.Identidades.Models
{
    public class AutenticacaoDTO
    {
        public UsuarioRespostaLoginDTO usuarioRespostaLogin { get; set; }
        public IEnumerable<PermissaoDTO> permissoes { get; set; }
    }
}