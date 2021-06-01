using System;
using PP.Core.Messages;

namespace PP.Usuario.API.Application.Commands.Ficha
{
    public class FichaCommand : Command {
        public Guid Id { get; set; }
        public string Objetivo { get; set; }
        public DateTime DataCadastro { get; set; }
        public Guid AlunoId { get; set; }
        public Guid AnamneseRespostaId { get; set; }
    }
}