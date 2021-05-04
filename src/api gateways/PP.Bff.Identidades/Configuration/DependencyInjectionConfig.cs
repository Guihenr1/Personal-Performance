using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PP.Bff.Identidades.Extensions;
using PP.Core.User;

namespace PP.Bff.Identidades.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services) {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
        }
    }
}