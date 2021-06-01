using System;
using PP.Usuario.API.Application.Commands.Validations.AnamneseResposta;

namespace PP.Usuario.API.Application.Commands.AnamneseResposta
{
    public class RegistrarAnamneseRespostaCommand : AnamneseRespostaCommand {
        public RegistrarAnamneseRespostaCommand(string resposta, Guid anamnesePerguntaId) {
            Resposta = resposta;
            AnamnesePerguntaId = anamnesePerguntaId;
        }

        public override bool EhValido() {
            ValidationResult = new RegistrarAnamneseRespostaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}