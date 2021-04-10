using System;
using PP.Core.Messages;

namespace PP.Usuario.API.Application.Events.Aluno
{
    public class AlunoRegistradoEvent : Event {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Excluido { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public AlunoRegistradoEvent(Guid id, string nome, string email, DateTime dataNascimento, bool excluido, DateTime dataCadastro)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Excluido = excluido;
            DataCadastro = dataCadastro;
        }
    }
}