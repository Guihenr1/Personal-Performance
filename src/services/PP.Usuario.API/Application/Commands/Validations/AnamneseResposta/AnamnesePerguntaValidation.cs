using System;
using FluentValidation;
using PP.Usuario.API.Application.Commands.AnamneseResposta;

namespace PP.Usuario.API.Application.Commands.Validations.AnamneseResposta
{
    public class AnamnesePerguntaValidation<T> : AbstractValidator<T> where T : AnamneseRespostaCommand {
        protected void ValidateId() {
            RuleFor(a => a.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da anamnese resposta inválido");
        }

        protected void ValidateAnamnesePerguntaId() {
            RuleFor(a => a.AnamnesePerguntaId)
                .NotEqual(Guid.Empty)
                .WithMessage("Anamnese pergunta id da anamnese resposta inválido");
        }

        protected void ValidateResposta() {
            RuleFor(a => a.Resposta)
                .NotEmpty().WithMessage("Informe a resposta")
                .Length(2, 100).WithMessage("A resposta deve ter entre 2 e 100 caracteres");
        }
    }
}