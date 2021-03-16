using System;
using PP.Core.Messages;

namespace PP.Usuario.API.Application.Commands.Aluno
{
    public class AlunoCommand : Command {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public bool Excluido { get; protected set; }
    }
}