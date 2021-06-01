using System;
using FluentValidation;

namespace PP.Treino.API.ViewModels
{
    public class ExercicioTreinoViewModel {
        public Guid Id { get; set; }
        public Guid ExercicioId { get; set; }
        public Guid RepeticaoId { get; set; }

        internal bool EhValido() {
            return new ExercicioTreinoViewModelValidation().Validate(this).IsValid;
        }
    }
    public class ExercicioTreinoViewModelValidation : AbstractValidator<ExercicioTreinoViewModel> {
        public ExercicioTreinoViewModelValidation() {
            RuleFor(x => x.ExercicioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do exercicio inválido");

            RuleFor(x => x.RepeticaoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da repetição inválido");
        }
    }
}