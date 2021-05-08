using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PP.Core.User;
using PP.Permissao.API.Data;

namespace PP.Permissao.API.Configuration
{
    public static class DependencyInjectionConfig {
        public static void RegisterServices(this IServiceCollection services) {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddScoped<PermissaoContext>();
        }
    }
}