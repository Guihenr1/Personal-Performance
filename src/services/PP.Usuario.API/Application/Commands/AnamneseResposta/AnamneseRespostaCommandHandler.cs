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
        IRequestHandler<RegistrarAnamneseRespostaCommand, ValidationResult>,
        IRequestHandler<AtualizarAnamneseRespostaCommand, ValidationResult> {
        private readonly IAnamneseRespostaRepository _anamneseRespostaRepository;

        public AnamneseRespostaCommandHandler(IAnamneseRespostaRepository anamneseRespostaRepository) {
            _anamneseRespostaRepository = anamneseRespostaRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarAnamneseRespostaCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var anamneseResposta = new Models.AnamneseResposta(Guid.NewGuid(), message.Resposta, message.AnamnesePerguntaId);

            _anamneseRespostaRepository.Adicionar(anamneseResposta);

            return await PersistirDados(_anamneseRespostaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarAnamneseRespostaCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var anamneseResposta = new Models.AnamneseResposta(Guid.NewGuid(), message.Resposta, message.AnamnesePerguntaId);

            _anamneseRespostaRepository.Atualizar(anamneseResposta);

            return await PersistirDados(_anamneseRespostaRepository.UnitOfWork);
        }
    }
}