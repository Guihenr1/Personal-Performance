using PP.Usuario.API.Application.Commands.AnamneseResposta;

namespace PP.Usuario.API.Application.Commands.Validations.AnamneseResposta
{
    public class AtualizarAnamnesePerguntaValidation : AnamnesePerguntaValidation<AtualizarAnamnesePerguntaCommand> {
        public AtualizarAnamnesePerguntaValidation() {
            ValidateId();
            ValidateAnamnesePerguntaId();
            ValidateResposta();
        }
    }
}