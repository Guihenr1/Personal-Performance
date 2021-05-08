using System;
using PP.Permissao.API.Models.Enums;

namespace PP.Permissao.API.Models
{
    public class Permissao : Entity {
        public string Nome { get; set; }
        public Guid TipoId { get; set; }
        public Tipo Tipo { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Permissao(string nome, Guid tipoId, TipoUsuario tipoUsuario)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            TipoId = tipoId;
            TipoUsuario = tipoUsuario;
        }

        public Permissao()
        {
            
        }
    }
}