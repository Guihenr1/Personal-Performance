using System;

namespace PP.Bff.Identidades.Models
{
    public class PermissaoViewModel {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid TipoId { get; set; }
        public TipoViewModel Tipo { get; set; }
        public int TipoUsuario { get; set; }
    }
}