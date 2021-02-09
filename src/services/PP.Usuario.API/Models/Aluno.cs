using System;
using PP.Core.DomainObjects;

namespace PP.Aluno.API.Models
{
    public class Aluno : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataExcluido { get; set; }
        public bool Excluido { get; set; }

        protected Aluno() {}

        public Professor Professor { get; set; }
        public Endereco Endereco { get; set; }

        public Aluno(string nome, DateTime dataNascimento)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.Now;
            Excluido = false;
        }
    }
}