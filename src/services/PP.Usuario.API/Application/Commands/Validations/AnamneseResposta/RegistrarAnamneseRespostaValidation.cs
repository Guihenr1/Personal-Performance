using PP.Usuario.API.Application.Commands.AnamneseResposta;

namespace PP.Usuario.API.Application.Commands.Validations.AnamneseResposta
{
    public class RegistrarAnamnesePerguntaValidation : AnamnesePerguntaValidation<RegistrarAnamnesePerguntaCommand> {
        public RegistrarAnamnesePerguntaValidation() {
            ValidateAnamnesePerguntaId();
            ValidateResposta();
        }
    }
}