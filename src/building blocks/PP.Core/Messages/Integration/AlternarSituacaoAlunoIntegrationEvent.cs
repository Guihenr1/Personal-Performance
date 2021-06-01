using System;

namespace PP.Core.Messages.Integration
{
    public class AlternarSituacaoAlunoIntegrationEvent : IntegrationEvent {
        public Guid Id { get; private set; }

        public AlternarSituacaoAlunoIntegrationEvent(Guid id)
        {
            Id = id;
        }
    }
}