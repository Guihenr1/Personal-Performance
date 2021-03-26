using System;
using PP.Usuario.API.Application.Commands.Validations.Aluno;

namespace PP.Usuario.API.Application.Commands.Aluno {
    public class AtualizarAlunoCommand : AlunoCommand {
        public AtualizarAlunoCommand(Guid id, string nome, string email, DateTime dataNascimento, bool excluido)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Excluido = excluido;
        }

        public override bool EhValido() {
            ValidationResult = new AtualizarAlunoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}