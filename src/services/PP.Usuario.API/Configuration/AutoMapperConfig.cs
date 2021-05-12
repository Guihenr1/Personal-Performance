using System;
using Microsoft.Extensions.DependencyInjection;
using PP.Usuario.API.Application.AutoMapper;

namespace PP.Aluno.API.Configuration
{
    public static class AutoMapperConfig {
        public static void AddAutoMapperConfiguration(this IServiceCollection services) {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile));
        }
    }
}