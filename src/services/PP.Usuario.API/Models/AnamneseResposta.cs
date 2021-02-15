using System;
using PP.Core.DomainObjects;

namespace PP.Aluno.API.Models
{
    public class AnamneseResposta : Entity
    {
        public string Resposta { get; set; }

        protected AnamneseResposta() { }

        public AnamnesePergunta AnamnesePergunta { get; set; }

        public AnamneseResposta(Guid id, string resposta)
        {
            Id = id;
            Resposta = resposta;
        }

        public void AtribuirAnamnesePergunta(AnamnesePergunta anamnesePergunta) {
            AnamnesePergunta = anamnesePergunta;
        }
    }
}