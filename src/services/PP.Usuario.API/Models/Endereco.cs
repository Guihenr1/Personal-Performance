using System;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Core.DomainObjects;

namespace PP.Usuario.API.Models
{
    public class Endereco : Entity {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }

        protected Endereco() { }

        [ForeignKey("Aluno")]
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        [ForeignKey("Estado")]
        public Guid EstadoId { get; set; }
        public Estado Estado { get; set; }

        public Endereco(Guid id, string cep, string logradouro, int numero, string bairro, string complemento, string cidade, Guid estadoId, Guid alunoId)
        {
            Id = id;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = cidade;
            EstadoId = estadoId;
            AlunoId = alunoId;
        }
    }
}