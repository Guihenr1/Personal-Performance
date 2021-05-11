using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PP.Core.Mediator;
using PP.Core.Messages.Integration;
using PP.MessageBus;
using PP.Usuario.API.Application.Commands.Professor;

namespace PP.Usuario.API.Services
{
    public class RegistroProfessorIntegrationHandler : BackgroundService
    {
        private IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistroProfessorIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<ProfessorRegistradoIntegrationEvent, ResponseMessage>(async request =>
                await RegistrarProfessor(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken sttoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e)
        {
            SetResponder();
        }

        private async Task<ResponseMessage> RegistrarProfessor(ProfessorRegistradoIntegrationEvent message)
        {
            var professorCommand = new RegistrarProfessorCommand(message.Id, message.Nome, message.CREF, message.Email);
            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.EnviarComando(professorCommand);
            }

            return new ResponseMessage(sucesso);
        }
    }
}