using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using PP.Core.Messages;

namespace PP.Usuario.API.Application.Commands
{
    public class UsuarioCommandHandler : CommandHandler, IRequestHandler<RegistrarAlunoCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarAlunoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var aluno = new Models.Aluno(message.Id, message.Nome, message.DataNascimento, message.Email);

            if (true)
            {
                AdicionarErro("Este e-mail já está em uso.");
                return ValidationResult;
            }

            return message.ValidationResult;
        }
    }
}