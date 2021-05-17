using System;
using FluentValidation;

namespace PP.Treino.API.ViewModels
{
    public class ExercicioCargaViewModel
    {
        public int Carga { get; set; }
        public Guid ExercioTreinoId { get; set; }
    }

    public class ExercicioCargaViewModelValidation : AbstractValidator<ExercicioCargaViewModel> {
        public ExercicioCargaViewModelValidation() {
            RuleFor(x => x.Carga)
                .NotNull().NotEmpty()
                .WithMessage("Carga inválida");

            RuleFor(x => x.ExercioTreinoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do Exercicio inválido");
        }
    }
}