using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace PP.Usuario.API.Application.Events.Aluno
{
    public class AlunoEventHandler : INotificationHandler<AlunoRegistradoEvent>
    {
        public Task Handle(AlunoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            // Ex: enviar email de confirmação de conta
            return Task.CompletedTask;
        }
    }
}