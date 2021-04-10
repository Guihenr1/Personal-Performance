using System;

namespace PP.Usuario.API.Application.Commands.Endereco
{
    public class RegistrarEnderecoCommand : EnderecoCommand
    {
        public RegistrarEnderecoCommand(Guid id, int cep, string logradouro, int numero, string bairro, string complemento, string cidade, Guid alunoId, Guid estadoId) {
            Id = id;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = cidade;
            AlunoId = alunoId;
            EstadoId = estadoId;
        }
    }
}