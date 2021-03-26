using System;
using System.Collections.Generic;
using PP.Core.DomainObjects;

namespace PP.Usuario.API.Models
{
    public class AnamneseResposta : Entity, IAggregateRoot {
        public string Resposta { get; set; }

        protected AnamneseResposta() { }

        public Guid AnamnesePerguntaId { get; set; }
        public AnamnesePergunta AnamnesePergunta { get; set; }
        public ICollection<Ficha> Ficha { get; set; }

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