using System;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Core.DomainObjects;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.ViewModels
{
    public class AlunoViewModel {
        public string Nome { get; set; }
        public Email Email { get; private set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataExcluido { get; set; }
        public bool Excluido { get; set; }
        public Guid ProfessorId { get; set; }
        public Guid EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}