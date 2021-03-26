using System;
using FluentValidation;
using PP.Usuario.API.Application.Commands.AnamnesePergunta;

namespace PP.Usuario.API.Application.Commands.Validations.AnamnesePergunta
{
    public class AnamnesePerguntaValidation<T> : AbstractValidator<T> where T : AnamnesePerguntaCommand {
        protected void ValidateId() {
            RuleFor(a => a.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da anamnese pergunta inválido");
        }

        protected void ValidatePergunta() {
            RuleFor(a => a.Pergunta)
                .NotEmpty().WithMessage("Informe a pergunta")
                .Length(2, 100).WithMessage("A pergunta deve ter entre 2 e 100 caracteres");
        }
    }
}