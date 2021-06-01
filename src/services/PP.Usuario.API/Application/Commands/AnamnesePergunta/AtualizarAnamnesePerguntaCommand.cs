using System;
using PP.Usuario.API.Application.Commands.Validations.AnamnesePergunta;

namespace PP.Usuario.API.Application.Commands.AnamnesePergunta
{
    public class AtualizarAnamnesePerguntaCommand : AnamnesePerguntaCommand {
        public AtualizarAnamnesePerguntaCommand(Guid id, string pergunta)
        {
            Id = id;
            Pergunta = pergunta;
        }

        public override bool EhValido() {
            ValidationResult = new AtualizarAnamnesePerguntaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}