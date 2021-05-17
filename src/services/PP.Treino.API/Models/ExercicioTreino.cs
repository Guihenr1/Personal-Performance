using System;
using System.Collections.Generic;

namespace PP.Treino.API.Models
{
    public class ExercicioTreino
    {
        public Guid Id { get; set; }
        public Guid ExercicioId { get; set; }
        public Guid TreinoId { get; set; }
        public Guid RepeticaoId { get; set; }
        public List<ExercicioCarga> ExercicioCarga { get; set; } = new List<ExercicioCarga>();

        public ExercicioTreino(Guid id, Guid exercicioId, Guid treinoId, Guid repeticaoId)
        {
            Id = id;
            ExercicioId = exercicioId;
            TreinoId = treinoId;
            RepeticaoId = repeticaoId;
        }

        public ExercicioTreino() {}
    }
}