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
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PP.Usuario.API.Services
{
    public class RegistroAlunoIntegrationHandler : BackgroundService
    {
        private IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistroAlunoIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<AlunoRegistradoIntegrationEvent, ResponseMessage>(async request =>
                await RegistrarAluno(request));

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

        private async Task<ResponseMessage> RegistrarAluno(AlunoRegistradoIntegrationEvent message)
        {
            var alunoCommand = new RegistrarAlunoCommand(message.Id, message.Nome,
                message.ProfessorId, message.Email, message.DataNascimento, message.Cep,
                message.Logradouro, message.Numero, message.Bairro, message.Complemento,
                message.Cidade, message.EstadoId);
            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.EnviarComando(alunoCommand);
            }

            return new ResponseMessage(sucesso);
        }
    }
}