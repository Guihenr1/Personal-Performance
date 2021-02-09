using System;
using PP.Core.DomainObjects;

namespace PP.Aluno.API.Models
{
    public class Ficha : Entity
    {
        public string Objetivo { get; set; }
        public DateTime DataCadastro { get; set; }

        protected Ficha() { }

        public Aluno Aluno { get; set; }
        public AnamneseResposta AnamneseResposta { get; set; }

        public Ficha(string objetivo)
        {
            Objetivo = objetivo;
        }
    }
}