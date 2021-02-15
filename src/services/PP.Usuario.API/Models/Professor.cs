using System;
using PP.Core.DomainObjects;

namespace PP.Aluno.API.Models
{
    public class Professor : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public int CREF { get; set; }
        public Email Email { get; private set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataExcluido { get; set; }
        public bool Excluido { get; set; }

        protected Professor() { }

        public Professor(Guid id, string nome, int cref, string email)
        {
            Id = id;
            Nome = nome;
            CREF = cref;
            Email = new Email(email);
            DataCadastro = DateTime.Now;
            Excluido = false;
        }
    }
}