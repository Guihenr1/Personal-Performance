using System;

namespace PP.Core.Messages.Integration {
    public class ProfessorRegistradoIntegrationEvent : IntegrationEvent {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public int CREF { get; private set; }
        public string Email { get; private set; }

        public ProfessorRegistradoIntegrationEvent(Guid id, string nome, int cref, string email)
        {
            Id = id;
            Nome = nome;
            CREF = cref;
            Email = email;
        }
    }
}
