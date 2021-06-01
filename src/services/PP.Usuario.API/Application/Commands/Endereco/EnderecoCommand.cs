using System;

namespace PP.Usuario.API.Application.Commands.Endereco
{
    public class EnderecoCommand
    {
        public Guid Id { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public Guid AlunoId { get; set; }
        public Guid EstadoId { get; set; }
    }
}