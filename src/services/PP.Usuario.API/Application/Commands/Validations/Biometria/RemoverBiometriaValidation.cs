using PP.Usuario.API.Application.Commands.Biometria;

namespace PP.Usuario.API.Application.Commands.Validations.Biometria
{
    public class RemoverBiometriaValidation : BiometriaValidation<RemoverBiometriaCommand> {
        public RemoverBiometriaValidation()
        {
            ValidateId();
        }
    }
}