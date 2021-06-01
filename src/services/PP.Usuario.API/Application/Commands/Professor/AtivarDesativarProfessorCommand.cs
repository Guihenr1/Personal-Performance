using System;
using PP.Usuario.API.Application.Commands.Validations.Professor;

namespace PP.Usuario.API.Application.Commands.Professor
{
    public class AtivarDesativarProfessorCommand : ProfessorCommand {
        public AtivarDesativarProfessorCommand(Guid id)
        {
            Id = id;
        }

        public override bool EhValido() {
            ValidationResult = new RemoverProfessorValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}