using PP.Core.DomainObjects;

namespace PP.Aluno.API.Models
{
    public class AnamneseResposta : Entity
    {
        public string Resposta { get; set; }

        protected AnamneseResposta() { }

        public AnamnesePergunta AnamnesePergunta { get; set; }

        public AnamneseResposta(string resposta)
        {
            Resposta = resposta;
        }
    }
}