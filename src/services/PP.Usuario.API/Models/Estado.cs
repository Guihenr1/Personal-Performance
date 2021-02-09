using PP.Core.DomainObjects;

namespace PP.Aluno.API.Models
{
    public class Estado : Entity
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public Endereco Endereco { get; set; }
    }
}