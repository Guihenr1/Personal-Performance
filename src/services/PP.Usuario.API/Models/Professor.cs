using System;
using System.Collections.Generic;
using PP.Core.DomainObjects;

namespace PP.Usuario.API.Models
{
    public class Professor : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public int CREF { get; set; }
        public Email Email { get; private set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataExcluido { get; set; }
        public bool Excluido { get; set; }

        public ICollection<Aluno> Aluno { get; set; }

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

        public void AlternarSituacao() {
            if (Excluido) {
                DataExcluido = null;
                Excluido = false;
            } else {
                DataExcluido = DateTime.Now;
                Excluido = true;
            }
        }
    }
}