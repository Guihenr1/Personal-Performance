using System;
using PP.Usuario.API.Application.Commands.Validations.Professor;

namespace PP.Usuario.API.Application.Commands.Professor
{
    public class RegistrarProfessorCommand : ProfessorCommand {
        public RegistrarProfessorCommand(Guid id, string nome, int cref, string email)
        {
            Id = id;
            Nome = nome;
            CREF = cref;
            Email = email;
        }

        public override bool EhValido() {
            ValidationResult = new RegistrarProfessorValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}