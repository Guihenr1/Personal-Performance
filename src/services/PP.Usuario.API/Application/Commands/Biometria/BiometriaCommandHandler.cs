using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using PP.Core.Messages;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Application.Commands.Biometria
{
    public class BiometriaCommandHandler : CommandHandler,
        IRequestHandler<RegistrarBiometriaCommand, ValidationResult>,
        IRequestHandler<AtualizarBiometriaCommand, ValidationResult>,
        IRequestHandler<RemoverBiometriaCommand, ValidationResult>
    {
        private readonly IBiometriaRepository _biometriaRepository;
        public BiometriaCommandHandler(IBiometriaRepository biometriaRepository)
        {
            _biometriaRepository = biometriaRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarBiometriaCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var biometria = new Models.Biometria(message.Id, message.Peso, message.Altura, message.BracoDireito, 
                message.BracoEsquerdo, message.Torax, message.Cintura, message.Quadril, message.CoxaDireita, message.CoxaEsquerda, 
                message.GemeoDireito, message.GemeoEsquerdo, message.AntebracoDireito, message.AntebracoEsquerdo);

            _biometriaRepository.Adicionar(biometria);

            return await PersistirDados(_biometriaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarBiometriaCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var biometria = new Models.Biometria(message.Id, message.Peso, message.Altura, message.BracoDireito,
                message.BracoEsquerdo, message.Torax, message.Cintura, message.Quadril, message.CoxaDireita, message.CoxaEsquerda,
                message.GemeoDireito, message.GemeoEsquerdo, message.AntebracoDireito, message.AntebracoEsquerdo);

            _biometriaRepository.Atualizar(biometria);

            return await PersistirDados(_biometriaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverBiometriaCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var biometria = await _biometriaRepository.ObterPorId(message.Id);

            biometria.DesativarBiometria();
            _biometriaRepository.Atualizar(biometria);

            return await PersistirDados(_biometriaRepository.UnitOfWork);
        }
    }
}