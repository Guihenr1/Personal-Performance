using System;
using PP.Core.Messages;

namespace PP.Usuario.API.Application.Commands.Professor
{
    public class ProfessorCommand : Command {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public int CREF { get; protected set; }
        public string Email { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
    }
}