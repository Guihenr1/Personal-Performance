using PP.Usuario.API.Application.Commands.AnamneseResposta;

namespace PP.Usuario.API.Application.Commands.Validations.AnamneseResposta {
    public class RegistrarAnamneseRespostaValidation : AnamneseRespostaValidation<RegistrarAnamneseRespostaCommand> {
        public RegistrarAnamneseRespostaValidation() {
            ValidateResposta();
            ValidateAnamnesePerguntaId();
        }
    }
}