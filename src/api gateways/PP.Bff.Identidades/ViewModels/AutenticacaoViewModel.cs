using System.Collections.Generic;

namespace PP.Bff.Identidades.Models
{
    public class AutenticacaoViewModel
    {
        public UsuarioRespostaLoginViewModel UsuarioRespostaLogin { get; set; }
        public IEnumerable<PermissaoViewModel> Permissoes { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}