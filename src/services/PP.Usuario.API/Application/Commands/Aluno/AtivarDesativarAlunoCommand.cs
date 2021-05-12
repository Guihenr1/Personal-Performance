using System;
using PP.Usuario.API.Application.Commands.Validations.Aluno;

namespace PP.Usuario.API.Application.Commands.Aluno {
    public class AtivarDesativarAlunoCommand : AlunoCommand {
        public AtivarDesativarAlunoCommand(Guid id)
        {
            Id = id;
        }

        public override bool EhValido() {
            ValidationResult = new AtivarDesativarAlunoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}