using System;
using System.Collections.Generic;

namespace PP.Treino.API.Models
{
    public class Treino
    {
        public Guid Id { get; set; }
        public Guid AlunoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public List<ExercicioTreino> ExercicioTreino { get; set; } = new List<ExercicioTreino>();

        public Treino(Guid id, Guid alunoId, string nome, List<ExercicioTreino> exercicioTreino)
        {
            Id = id;
            AlunoId = alunoId;
            DataCadastro = DateTime.Now;
            Nome = nome;
            ExercicioTreino = exercicioTreino;
        }

        public Treino() { }
    }
}