using System;

namespace PP.Bff.Identidades.Models
{
    public class UsuarioRespostaLoginDTO {
        public string AccessToken { get; set; }
        public Guid RefreshToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioTokenDTO UsuarioToken { get; set; }
    }
}