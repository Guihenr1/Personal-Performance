using System;
using System.Collections.Generic;

namespace PP.Treino.API.Models
{
    public class Repeticao
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public List<ExercicioTreino> ExercicioTreino { get; set; } = new List<ExercicioTreino>();

        public Repeticao(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
        }

        public Repeticao() { }
    }
}