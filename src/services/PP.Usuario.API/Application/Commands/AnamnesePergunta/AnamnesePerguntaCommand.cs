using System;
using PP.Core.Messages;

namespace PP.Usuario.API.Application.Commands.AnamnesePergunta
{
    public class AnamnesePerguntaCommand : Command {
        public Guid Id { get; protected set; }
        public string Pergunta { get; protected set; }
    }
}