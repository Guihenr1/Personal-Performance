using PP.Usuario.API.Application.Commands.Ficha;

namespace PP.Usuario.API.Application.Commands.Validations.Ficha
{
    public class RemoverFichaValidation : FichaValidation<FichaCommand>
    {
        public RemoverFichaValidation() {
            ValidateId();
        }
    }
}