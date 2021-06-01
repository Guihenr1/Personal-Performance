using PP.Usuario.API.Application.Commands.Ficha;

namespace PP.Usuario.API.Application.Commands.Validations.Ficha
{
    public class AtualizarFichaValidation : FichaValidation<FichaCommand>
    {
        public AtualizarFichaValidation() {
            ValidateId();
            ValidateObjetivo();
            ValidateAlunoId();
            ValidateAnamneseRespostaId();
        }
    }
}