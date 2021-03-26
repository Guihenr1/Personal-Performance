using PP.Usuario.API.Application.Commands.AnamnesePergunta;

namespace PP.Usuario.API.Application.Commands.Validations.AnamnesePergunta
{
    public class AtualizarAnamnesePerguntaValidation : AnamnesePerguntaValidation<AtualizarAnamnesePerguntaCommand> {
        public AtualizarAnamnesePerguntaValidation() {
            ValidateId();
            ValidatePergunta();
        }
    }
}