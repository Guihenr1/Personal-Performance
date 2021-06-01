using System;
using PP.Core.DomainObjects;

namespace PP.Usuario.API.ViewModels
{
    public class ProfessorViewModel {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CREF { get; set; }
        public Email Email { get; private set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataExcluido { get; set; }
        public bool Excluido { get; set; }
    }
}