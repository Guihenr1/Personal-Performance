using System;

namespace PP.Core.Messages.Integration {
    public class AlunoRegistradoIntegrationEvent : IntegrationEvent {
        public Guid Id { get; private set; }
        public Guid ProfessorId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; private set; }
        public Guid EstadoId { get; private set; }

        public AlunoRegistradoIntegrationEvent(Guid id, string nome, Guid professorId, string email, DateTime dataNascimento,
            string cep, string logradouro, int numero, string bairro, string complemento, string cidade, Guid estadoId) {
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
    }
}
