using System;
using FluentValidation;

namespace PP.Treino.API.Models
{
    public class ExercicioTreino
    {
        public Guid Id { get; set; }
        public Guid ExercicioId { get; set; }
        public Guid TreinoId { get; set; }
        public Guid RepeticaoId { get; set; }

        public ExercicioTreino(Guid exercicioId, Guid treinoId, Guid repeticaoId)
        {
            Id = Guid.NewGuid();
            ExercicioId = exercicioId;
            TreinoId = treinoId;
            RepeticaoId = repeticaoId;
        }

        public ExercicioTreino() {}

        public Exercicio Exercicio { get; set; }
        public Repeticao Repeticao { get; set; }
        public Treino Treino { get; set; }
    }
}