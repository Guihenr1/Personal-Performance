using System;
using PP.Core.DomainObjects;
using PP.Core.Messages;

namespace PP.Usuario.API.Application.Commands
{
    public class RegistrarAlunoCommand : Command {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; set; }
        public bool Excluido { get; set; }

        public RegistrarAlunoCommand(string nome, string email, DateTime dataNascimento, bool excluido)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Excluido = excluido;
        }
    }
}
