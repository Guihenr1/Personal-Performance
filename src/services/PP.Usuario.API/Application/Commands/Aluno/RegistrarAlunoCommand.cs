using System;
using PP.Usuario.API.Application.Commands.Validations.Aluno;

namespace PP.Usuario.API.Application.Commands.Aluno {
    public class RegistrarAlunoCommand : AlunoCommand {

        public RegistrarAlunoCommand(Guid id,string nome, Guid professorId, string email, DateTime dataNascimento, 
            string cep, string logradouro, int numero, string bairro, string complemento, string cidade, Guid estadoId)
        {
            Id = id;
            Nome = nome;
            ProfessorId = professorId;
            Email = email;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.Now;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = cidade;
            EstadoId = estadoId;
        }

        public override bool EhValido()
        {
            ValidationResult = new RegistrarAlunoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
