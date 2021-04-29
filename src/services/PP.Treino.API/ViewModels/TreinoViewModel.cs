using System;
using System.Collections.Generic;
using FluentValidation;

namespace PP.Treino.API.ViewModels
{
    public class TreinoViewModel {
        public List<ExercicioTreinoViewModel> ExercicioTreino { get; set; } = new List<ExercicioTreinoViewModel>();

        public bool EhValido() {
            return new TreinoValidation().Validate(this).IsValid;
        }

        private class TreinoValidation : AbstractValidator<TreinoViewModel> {
            public TreinoValidation() {
                RuleForEach(x => x.ExercicioTreino).SetValidator(new ExercicioTreinoViewModelValidation());
            }
        }
    }
}