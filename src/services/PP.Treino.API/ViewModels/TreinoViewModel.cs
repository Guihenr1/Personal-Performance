using System;
using System.Collections.Generic;
using FluentValidation;

namespace PP.Treino.API.ViewModels
{
    public class TreinoViewModel {
        public List<ExercicioTreinoViewModel> ExercicioTreino { get; set; } = new List<ExercicioTreinoViewModel>();
        public string Nome { get; set; }
        public Guid AlunoId { get; set; }

        public bool EhValido() {
            return new TreinoValidation().Validate(this).IsValid;
        }

        private class TreinoValidation : AbstractValidator<TreinoViewModel> {
            public TreinoValidation()
            {
                RuleFor(x => x.Nome).NotNull().MaximumLength(100);
                RuleForEach(x => x.ExercicioTreino).SetValidator(new ExercicioTreinoViewModelValidation());
            }
        }
    }
}