using System;
using System.Text.Json.Serialization;
using PP.Core.Messages;

namespace PP.Usuario.API.Application.Commands.Aluno
{
    public class AlunoCommand : Command {
        public Guid Id { get; set; }
        public Guid ProfessorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        [JsonIgnore]
        public bool Excluido { get; set; }
        [JsonIgnore]
        public DateTime DataCadastro { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public Guid EstadoId { get; set; }
    }
}