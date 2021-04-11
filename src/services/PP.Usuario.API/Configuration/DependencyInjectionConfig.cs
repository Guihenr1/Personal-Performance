using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PP.Core.Mediator;
using PP.Usuario.API.Application.Commands.Aluno;
using PP.Usuario.API.Application.Commands.AnamnesePergunta;
using PP.Usuario.API.Application.Commands.AnamneseResposta;
using PP.Usuario.API.Application.Commands.Biometria;
using PP.Usuario.API.Application.Commands.Ficha;
using PP.Usuario.API.Application.Commands.Professor;
using PP.Usuario.API.Application.Events.Aluno;
using PP.Usuario.API.Data;
using PP.Usuario.API.Data.Repository;
using PP.Usuario.API.Models;
using PP.Usuario.API.Services;

namespace PP.Aluno.API.Configuration
{
    public static class DependencyInjectionConfig {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarAlunoCommand, ValidationResult>, AlunoCommandHandler>();
            services.AddScoped<IRequestHandler<RegistrarProfessorCommand, ValidationResult>, ProfessorCommandHandler>();
            services.AddScoped<IRequestHandler<RegistrarFichaCommand, ValidationResult>, FichaCommandHandler>();
            services.AddScoped<IRequestHandler<RegistrarBiometriaCommand, ValidationResult>, BiometriaCommandHandler>();
            services.AddScoped<IRequestHandler<RegistrarAnamnesePerguntaCommand, ValidationResult>, AnamnesePerguntaCommandHandler>();
            services.AddScoped<IRequestHandler<RegistrarAnamneseRespostaCommand, ValidationResult>, AnamneseRespostaCommandHandler>();

            services.AddScoped<INotificationHandler<AlunoRegistradoEvent>, AlunoEventHandler>();

            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IFichaRepository, FichaRepository>();
            services.AddScoped<IBiometriaRepository, BiometriaRepository>();
            services.AddScoped<IAnamneseRespostaRepository, AnamneseRespostaRepository>();
            services.AddScoped<IAnamnesePerguntaRepository, AnamnesePerguntaRepository>();
            services.AddScoped<UsuarioContext>();
        }
    }
}