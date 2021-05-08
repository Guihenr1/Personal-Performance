using System;

namespace PP.Bff.Identidades.Models
{
    public class PermissaoDTO {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid TipoId { get; set; }
        public TipoDTO Tipo { get; set; }
        public int TipoUsuario { get; set; }
    }
}