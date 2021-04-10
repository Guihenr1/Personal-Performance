using System;
using PP.Core.Messages;

namespace PP.Usuario.API.Application.Commands.Aluno
{
    public class AlunoCommand : Command {
        public Guid Id { get; protected set; }
        public Guid ProfessorId { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public bool Excluido { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public string Cep { get; protected set; }
        public string Logradouro { get; protected set; }
        public int Numero { get; protected set; }
        public string Bairro { get; protected set; }
        public string Complemento { get; protected set; }
        public string Cidade { get; protected set; }
        public Guid EstadoId { get; protected set; }
    }
}