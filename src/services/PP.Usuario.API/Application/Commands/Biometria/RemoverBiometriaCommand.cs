using System;
using PP.Usuario.API.Application.Commands.Validations.Biometria;

namespace PP.Usuario.API.Application.Commands.Biometria
{
    public class RemoverBiometriaCommand : BiometriaCommand {
        public RemoverBiometriaCommand(Guid id)
        {
            Id = id;
        }

        public override bool EhValido() {
            ValidationResult = new RemoverBiometriaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}