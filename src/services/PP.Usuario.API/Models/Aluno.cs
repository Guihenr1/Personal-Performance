using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PP.Core.DomainObjects;

namespace PP.Usuario.API.Models
{
    public class Aluno : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public Email Email { get; private set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataExcluido { get; set; }
        public bool Excluido { get; set; }

        protected Aluno() {}

        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }
        [ForeignKey("Endereco")]
        public Guid EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<Biometria> Biometria { get; set; }
        public ICollection<Ficha> Ficha { get; set; }

        public Aluno(Guid id, string nome, DateTime dataNascimento, string email)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = new Email(email);
            DataCadastro = DateTime.Now;
            Excluido = false;
        }

        public void TrocarEmail(string email)
        {
            Email = new Email(email);
        }

        public void AtribuirEndereco(Endereco endereco) 
        {
            Endereco = endereco;
        }

        public void AtribuirProfessor(Professor professor) 
        {
            Professor = professor;
        }

        public void ExcluirAluno() {
            Excluido = true;
        }
    }
}