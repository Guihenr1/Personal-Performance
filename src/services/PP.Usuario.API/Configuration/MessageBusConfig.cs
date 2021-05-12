using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PP.Core.Utils;
using PP.MessageBus;
using PP.Usuario.API.Services;

namespace PP.Aluno.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<RegistroAlunoIntegrationHandler>()
                .AddHostedService<RegistroProfessorIntegrationHandler>()
                .AddHostedService<AlterarSituacaoAlunoIntegrationHandler>();
        }
    }
}