using Microsoft.Extensions.DependencyInjection;
using PP.Permissao.API.Data;

namespace PP.Permissao.API.Configuration
{
    public static class DependencyInjectionConfig {
        public static void RegisterServices(this IServiceCollection services) {
            services.AddScoped<PermissaoContext>();
        }
    }
}