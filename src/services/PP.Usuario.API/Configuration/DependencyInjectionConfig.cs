using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PP.Core.Mediator;
using PP.Usuario.API.Application.Commands.Aluno;
using PP.Usuario.API.Data;
using PP.Usuario.API.Data.Repository;
using PP.Usuario.API.Models;

namespace PP.Aluno.API.Configuration
{
    public static class DependencyInjectionConfig {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarAlunoCommand, ValidationResult>, UsuarioCommandHandler>();

            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<UsuarioContext>();
        }
    }
}