using System;

namespace PP.Treino.API.DTO
{
    public class ExercicioTreinoDTO {
        public Guid Id { get; set; }
        public Guid ExercicioId { get; set; }
        public Guid TreinoId { get; set; }
        public Guid RepeticaoId { get; set; }
    }
}