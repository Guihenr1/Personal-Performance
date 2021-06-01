using System;
using System.ComponentModel.DataAnnotations;

namespace PP.Usuario.API.Models
{
    public class Estado {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
    }
}