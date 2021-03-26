using System;
using PP.Usuario.API.Application.Commands.Validations.Professor;

namespace PP.Usuario.API.Application.Commands.Professor
{
    public class RegistrarProfessorCommand : ProfessorCommand {
        public RegistrarProfessorCommand(string nome, int cref, string email) {
            Nome = nome;
            CREF = cref;
            Email = email;
            DataCadastro = DateTime.Now;
        }

        public override bool EhValido() {
            ValidationResult = new RegistrarProfessorValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}