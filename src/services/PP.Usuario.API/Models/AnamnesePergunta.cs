using System;
using PP.Core.DomainObjects;

namespace PP.Aluno.API.Models
{
    public class AnamnesePergunta : Entity 
    {
        public string Pergunta { get; set; }

        protected AnamnesePergunta() { }

        public AnamnesePergunta(Guid id, string pergunta)
        {
            Id = id;
            Pergunta = pergunta;
        }
    }
}