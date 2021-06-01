using PP.Usuario.API.Application.Commands.Validations.AnamnesePergunta;

namespace PP.Usuario.API.Application.Commands.AnamnesePergunta
{
    public class RegistrarAnamnesePerguntaCommand : AnamnesePerguntaCommand {
        public RegistrarAnamnesePerguntaCommand(string pergunta) {
            Pergunta = pergunta;
        }

        public override bool EhValido() {
            ValidationResult = new RegistrarAnamnesePerguntaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}