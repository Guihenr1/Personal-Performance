using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using PP.Core.Messages;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Application.Commands.AnamneseResposta
{
    public class AnamneseRespostaCommandHandler : CommandHandler,
        IRequestHandler<RegistrarAnamnesePerguntaCommand, ValidationResult>,
        IRequestHandler<AtualizarAnamnesePerguntaCommand, ValidationResult> {
        private readonly IAnamneseRespostaRepository _anamneseRespostaRepository;

        public AnamneseRespostaCommandHandler(IAnamneseRespostaRepository anamneseRespostaRepository) {
            _anamneseRespostaRepository = anamneseRespostaRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarAnamnesePerguntaCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var anamneseResposta = new Models.AnamneseResposta(Guid.NewGuid(), message.Resposta);

            _anamneseRespostaRepository.Adicionar(anamneseResposta);

            return await PersistirDados(_anamneseRespostaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarAnamnesePerguntaCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var anamneseResposta = new Models.AnamneseResposta(Guid.NewGuid(), message.Resposta);

            _anamneseRespostaRepository.Atualizar(anamneseResposta);

            return await PersistirDados(_anamneseRespostaRepository.UnitOfWork);
        }
    }
}