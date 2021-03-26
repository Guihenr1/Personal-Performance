using System;
using PP.Usuario.API.Application.Commands.Validations.AnamneseResposta;

namespace PP.Usuario.API.Application.Commands.AnamneseResposta
{
    public class RegistrarAnamnesePerguntaCommand : AnamneseRespostaCommand {
        public RegistrarAnamnesePerguntaCommand(string resposta, Guid anamnesePerguntaId) {
            Resposta = resposta;
            AnamnesePerguntaId = anamnesePerguntaId;
        }

        public override bool EhValido() {
            ValidationResult = new RegistrarAnamnesePerguntaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}