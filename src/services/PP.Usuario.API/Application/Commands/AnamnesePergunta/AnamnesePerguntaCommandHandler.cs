using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using PP.Core.Messages;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Application.Commands.AnamnesePergunta
{
    public class AnamnesePerguntaCommandHandler : CommandHandler,
        IRequestHandler<RegistrarAnamnesePerguntaCommand, ValidationResult>,
        IRequestHandler<AtualizarAnamnesePerguntaCommand, ValidationResult> {
        private readonly IAnamnesePerguntaRepository _anamnesePerguntaRepository;

        public AnamnesePerguntaCommandHandler(IAnamnesePerguntaRepository anamnesePerguntaRepository) {
            _anamnesePerguntaRepository = anamnesePerguntaRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarAnamnesePerguntaCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var anamnesePergunta = new Models.AnamnesePergunta(Guid.NewGuid(), message.Pergunta);

            _anamnesePerguntaRepository.Adicionar(anamnesePergunta);

            return await PersistirDados(_anamnesePerguntaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarAnamnesePerguntaCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var anamnesePergunta = new Models.AnamnesePergunta(Guid.NewGuid(), message.Pergunta);

            _anamnesePerguntaRepository.Atualizar(anamnesePergunta);

            return await PersistirDados(_anamnesePerguntaRepository.UnitOfWork);
        }
    }
}