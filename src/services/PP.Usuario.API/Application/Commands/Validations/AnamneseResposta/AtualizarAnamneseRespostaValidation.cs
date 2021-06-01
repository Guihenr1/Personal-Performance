using PP.Usuario.API.Application.Commands.AnamneseResposta;

namespace PP.Usuario.API.Application.Commands.Validations.AnamneseResposta
{
    public class AtualizarAnamneseRespostaValidation : AnamneseRespostaValidation<AtualizarAnamneseRespostaCommand> {
        public AtualizarAnamneseRespostaValidation() {
            ValidateId();
            ValidateAnamnesePerguntaId();
            ValidateResposta();
        }
    }
}