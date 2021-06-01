using System;
using System.Text.Json.Serialization;
using PP.Core.Messages;

namespace PP.Usuario.API.Application.Commands.Professor
{
    public class ProfessorCommand : Command {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CREF { get; set; }
        [JsonIgnore]
        public string Email { get; set; }
    }
}