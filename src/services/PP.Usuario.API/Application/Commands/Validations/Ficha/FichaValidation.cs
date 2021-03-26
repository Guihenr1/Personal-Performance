using System;
using FluentValidation;
using PP.Usuario.API.Application.Commands.Ficha;

namespace PP.Usuario.API.Application.Commands.Validations.Ficha
{
    public class FichaValidation<T> : AbstractValidator<T> where T : FichaCommand {
        protected void ValidateId() {
            RuleFor(a => a.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da ficha inválido");
        }

        protected void ValidateObjetivo() {
            RuleFor(a => a.Objetivo)
                .NotEmpty().WithMessage("Informe o objetivo")
                .Length(2, 100).WithMessage("O objetivo deve ter entre 2 e 100 caracteres");
        }
        protected void ValidateAlunoId() {
            RuleFor(a => a.AlunoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Aluno da ficha inválido");
        }
        protected void ValidateAnamneseRespostaId() {
            RuleFor(a => a.AnamneseRespostaId)
                .NotEqual(Guid.Empty)
                .WithMessage("Anamnese resposta da ficha inválido");
        }
    }
}