using PP.Usuario.API.Application.Commands.Ficha;

namespace PP.Usuario.API.Application.Commands.Validations.Ficha
{
    public class RegistrarFichaValidation : FichaValidation<FichaCommand>
    {
        public RegistrarFichaValidation() {
            ValidateObjetivo();
            ValidateAlunoId();
            ValidateAnamneseRespostaId();
        }
    }
}