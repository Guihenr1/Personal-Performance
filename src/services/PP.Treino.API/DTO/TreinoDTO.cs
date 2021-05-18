using System;
using System.Collections.Generic;

namespace PP.Treino.API.DTO
{
    public class TreinoDTO {
        public Guid Id { get; set; }
        public Guid AlunoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public List<ExercicioTreinoDTO> ExercicioTreino { get; set; }
    }
}