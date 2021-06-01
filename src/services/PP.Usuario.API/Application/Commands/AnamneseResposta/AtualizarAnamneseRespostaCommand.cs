using System;
using PP.Usuario.API.Application.Commands.Validations.AnamneseResposta;

namespace PP.Usuario.API.Application.Commands.AnamneseResposta
{
    public class AtualizarAnamneseRespostaCommand : AnamneseRespostaCommand {
        public AtualizarAnamneseRespostaCommand(Guid id, string resposta, Guid anamnesePerguntaId)
        {
            Id = id;
            Resposta = resposta;
            AnamnesePerguntaId = anamnesePerguntaId;
        }

        public override bool EhValido() {
            ValidationResult = new AtualizarAnamneseRespostaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}