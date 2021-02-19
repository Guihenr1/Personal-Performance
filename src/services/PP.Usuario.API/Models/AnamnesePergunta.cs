using System;
using System.Collections.Generic;
using PP.Core.DomainObjects;

namespace PP.Usuario.API.Models
{
    public class AnamnesePergunta : Entity 
    {
        public string Pergunta { get; set; }

        protected AnamnesePergunta() { }

        public ICollection<AnamneseResposta> AnamneseResposta { get; set; }

        public AnamnesePergunta(Guid id, string pergunta)
        {
            Id = id;
            Pergunta = pergunta;
        }
    }
}