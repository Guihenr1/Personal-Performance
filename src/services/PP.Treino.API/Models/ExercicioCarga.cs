using System;

namespace PP.Treino.API.Models
{
    public class ExercicioCarga
    {
        public Guid Id { get; set; }
        public int Carga { get; set; }
        public DateTime DataCadastro { get; set; }
        public ExercicioTreino ExercicioTreino { get; set; }

        public ExercicioCarga(int carga)
        {
            Id = Guid.NewGuid();
            Carga = carga;
            DataCadastro = DateTime.Now;
        }

        public void AssociarExercicioTreino(ExercicioTreino exercicioTreino)
        {
            ExercicioTreino = exercicioTreino;
        }
    }
}