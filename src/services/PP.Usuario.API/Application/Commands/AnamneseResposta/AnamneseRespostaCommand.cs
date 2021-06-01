using System;
using PP.Core.Messages;

namespace PP.Usuario.API.Application.Commands.AnamneseResposta
{
    public class AnamneseRespostaCommand : Command {
        public Guid Id { get; protected set; }
        public string Resposta { get; protected set; }
        public Guid AnamnesePerguntaId { get; protected set; }
    }
}