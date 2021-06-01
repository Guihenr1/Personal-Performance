using System;

namespace PP.Bff.Identidades.Models
{
    public class UsuarioRespostaLoginViewModel {
        public string AccessToken { get; set; }
        public Guid RefreshToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioTokenViewModel UsuarioToken { get; set; }
    }
}