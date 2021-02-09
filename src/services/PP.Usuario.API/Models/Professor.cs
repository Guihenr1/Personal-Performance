using System;
using PP.Core.DomainObjects;

namespace PP.Aluno.API.Models
{
    public class Professor : Entity
    {
        public string Nome { get; set; }
        public int CREF { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataExcluido { get; set; }
        public bool Excluido { get; set; }

        protected Professor() { }

        public Professor(string nome, int cref)
        {
            Nome = nome;
            CREF = cref;
            DataCadastro = DateTime.Now;
            Excluido = false;
        }
    }
}