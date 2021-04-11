using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PP.Core.Utils;
using PP.MessageBus;

namespace PP.Identidade.API.Configuration
{
    public static class MessageBusConfig {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration) {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
        }
    }
}