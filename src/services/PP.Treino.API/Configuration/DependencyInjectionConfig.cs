using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PP.Core.User;
using PP.Treino.API.Data;
using PP.Treino.API.Data.Repositories;

namespace PP.Treino.API.Configuration
{
    public static class DependencyInjectionConfig {
        public static void RegisterServices(this IServiceCollection services) {
            services.AddScoped<ITreinoRepository, TreinoRepository>();
            services.AddScoped<IExercicioCargaRepository, ExercicioCargaRepository>();
            services.AddScoped<IExercicioTreinoRepository, ExercicioTreinoRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddScoped<TreinoContext>();
        }
    }
}