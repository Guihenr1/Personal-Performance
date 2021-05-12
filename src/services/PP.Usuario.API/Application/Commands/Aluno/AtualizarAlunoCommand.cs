using System;
using PP.Usuario.API.Application.Commands.Validations.Aluno;

namespace PP.Usuario.API.Application.Commands.Aluno {
    public class AtualizarAlunoCommand : AlunoCommand {
        public AtualizarAlunoCommand(Guid id, string nome, Guid professorId, string email, DateTime dataNascimento,
            string cep, string logradouro, int numero, string bairro, string complemento, string cidade, Guid estadoId) {
            Id = id;
            Nome = nome;
            ProfessorId = professorId;
            Email = email;
            DataNascimento = dataNascimento;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = cidade;
            EstadoId = estadoId;
        }

        public AtualizarAlunoCommand()
        {
            
        }

        public override bool EhValido() {
            ValidationResult = new AtualizarAlunoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}