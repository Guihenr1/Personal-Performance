using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PP.Core.Mediator;
using PP.Core.Messages.Integration;
using PP.MessageBus;
using PP.Usuario.API.Application.Commands.Aluno;

namespace PP.Usuario.API.Services
{
    public class AlterarSituacaoAlunoIntegrationHandler : BackgroundService {
        private IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public AlterarSituacaoAlunoIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder() {
            _bus.RespondAsync<AlternarSituacaoAlunoIntegrationEvent, ResponseMessage>(async request =>
                await AlterarSituacao(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken sttoppingToken) {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e) {
            SetResponder();
        }

        private async Task<ResponseMessage> AlterarSituacao(AlternarSituacaoAlunoIntegrationEvent message) {
            var alunoCommand = new AtivarDesativarAlunoCommand(message.Id);
            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope()) {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.EnviarComando(alunoCommand);
            }

            return new ResponseMessage(sucesso);
        }
    }
}