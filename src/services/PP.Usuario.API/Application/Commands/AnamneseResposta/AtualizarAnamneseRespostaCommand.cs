using System;
using PP.Usuario.API.Application.Commands.Validations.AnamneseResposta;

namespace PP.Usuario.API.Application.Commands.AnamneseResposta
{
    public class AtualizarAnamnesePerguntaCommand : AnamneseRespostaCommand {
        public AtualizarAnamnesePerguntaCommand(Guid id, string resposta, Guid anamnesePerguntaId)
        {
            Id = id;
            Resposta = resposta;
            AnamnesePerguntaId = anamnesePerguntaId;
        }

        public override bool EhValido() {
            ValidationResult = new AtualizarAnamnesePerguntaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}