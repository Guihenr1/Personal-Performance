using PP.Usuario.API.Application.Commands.AnamnesePergunta;

namespace PP.Usuario.API.Application.Commands.Validations.AnamnesePergunta
{
    public class RegistrarAnamnesePerguntaValidation : AnamnesePerguntaValidation<RegistrarAnamnesePerguntaCommand> {
        public RegistrarAnamnesePerguntaValidation() {
            ValidatePergunta();
        }
    }
}