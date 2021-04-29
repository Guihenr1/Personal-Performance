using System;
using System.Collections.Generic;

namespace PP.Treino.API.Models
{
    public class Exercicio
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<ExercicioTreino> ExercicioTreino { get; set; } = new List<ExercicioTreino>();

        public Exercicio(string nome, string descricao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
        }

        public Exercicio() { }
    }
}