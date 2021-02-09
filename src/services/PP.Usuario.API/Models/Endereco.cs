namespace PP.Aluno.API.Models
{
    public class Endereco {
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }

        protected Endereco() { }

        public Aluno Aluno { get; set; }
        public Endereco Estado { get; set; }

        public Endereco(int cep, string logradouro, int numero, string bairro, string complemento, string cidade)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = cidade;
        }
    }
}