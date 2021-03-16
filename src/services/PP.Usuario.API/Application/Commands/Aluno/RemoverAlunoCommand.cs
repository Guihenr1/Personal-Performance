using System;
using PP.Usuario.API.Application.Commands.Validations.Aluno;

namespace PP.Usuario.API.Application.Commands.Aluno {
    public class RemoverAlunoCommand : AlunoCommand {
        public RemoverAlunoCommand(Guid id)
        {
            Id = id;
        }

        public override bool EhValido() {
            ValidationResult = new RemoverAlunoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}