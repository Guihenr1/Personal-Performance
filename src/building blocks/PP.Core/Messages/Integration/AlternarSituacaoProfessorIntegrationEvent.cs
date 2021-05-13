using System;

namespace PP.Core.Messages.Integration
{
    public class AlternarSituacaoProfessorIntegrationEvent : IntegrationEvent {
        public Guid Id { get; private set; }

        public AlternarSituacaoProfessorIntegrationEvent(Guid id) {
            Id = id;
        }
    }
}