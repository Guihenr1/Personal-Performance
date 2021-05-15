using System.Collections.Generic;

namespace PP.Bff.Identidades.Models
{
    public class AutenticacaoViewModel
    {
        public UsuarioRespostaLoginViewModel usuarioRespostaLogin { get; set; }
        public IEnumerable<PermissaoViewModel> permissoes { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}