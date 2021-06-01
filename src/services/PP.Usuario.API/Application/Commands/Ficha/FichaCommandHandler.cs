using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using PP.Core.Messages;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Application.Commands.Ficha
{
    public class FichaCommandHandler : CommandHandler,
        IRequestHandler<RegistrarFichaCommand, ValidationResult>,
        IRequestHandler<AtualizarFichaCommand, ValidationResult> {
        private readonly IFichaRepository _fichaRepository;

        public FichaCommandHandler(IFichaRepository fichaRepository) {
            _fichaRepository = fichaRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarFichaCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var ficha = new Models.Ficha(Guid.NewGuid(), message.Objetivo);

            _fichaRepository.Adicionar(ficha);

            return await PersistirDados(_fichaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarFichaCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var ficha = new Models.Ficha(Guid.NewGuid(), message.Objetivo);

            _fichaRepository.Atualizar(ficha);

            return await PersistirDados(_fichaRepository.UnitOfWork);
        }
    }
}