using System;
using PP.Core.DomainObjects;

namespace PP.Aluno.API.Models
{
    public class Endereco : Entity {
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }

        protected Endereco() { }

        public Aluno Aluno { get; set; }
        public Estado Estado { get; set; }

        public Endereco(Guid id, int cep, string logradouro, int numero, string bairro, string complemento, string cidade)
        {
            Id = id;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = cidade;
        }

        public void AtribuirAluno(Aluno aluno) {
            Aluno = aluno;
        }

        public void AtribuirEstado(Estado estado) {
            Estado = estado;
        }
    }
}