using System;
using PP.Usuario.API.Application.Commands.Validations.Aluno;

namespace PP.Usuario.API.Application.Commands.Aluno {
    public class RegistrarAlunoCommand : AlunoCommand {

        public RegistrarAlunoCommand(string nome, string email, DateTime dataNascimento, bool excluido)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Excluido = excluido;
            DataCadastro = DateTime.Now;
        }

        public override bool EhValido()
        {
            ValidationResult = new RegistrarAlunoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
