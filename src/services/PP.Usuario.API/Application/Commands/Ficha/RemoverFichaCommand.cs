using System;
using PP.Usuario.API.Application.Commands.Validations.Ficha;

namespace PP.Usuario.API.Application.Commands.Ficha
{
    public class RemoverFichaCommand : FichaCommand {
        public RemoverFichaCommand(Guid id) {
            Id = id;
        }

        public override bool EhValido() {
            ValidationResult = new RemoverFichaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}