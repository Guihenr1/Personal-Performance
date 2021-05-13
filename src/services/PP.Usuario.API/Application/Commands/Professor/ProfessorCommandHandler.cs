using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using PP.Core.Messages;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Application.Commands.Professor {
    public class ProfessorCommandHandler : CommandHandler, 
        IRequestHandler<RegistrarProfessorCommand, ValidationResult>,
        IRequestHandler<AtualizarProfessorCommand, ValidationResult>,
        IRequestHandler<AtivarDesativarProfessorCommand, ValidationResult> {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorCommandHandler(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarProfessorCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var professor = new Models.Professor(message.Id, message.Nome, message.CREF, message.Email);

            var professorExistente = await _professorRepository.ObterPorEmail(professor.Email.Endereco);

            if (professorExistente != null)
            {
                AdicionarErro("Este e-mail já está em uso.");
                return ValidationResult;
            }

            var crefExistente = await _professorRepository.ObterPorCREF(message.CREF);

            if (crefExistente != null) 
            {
                AdicionarErro("Este CREF já está em uso.");
                return ValidationResult;
            }

            _professorRepository.Adicionar(professor);

            return await PersistirDados(_professorRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarProfessorCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var professor = new Models.Professor(message.Id, message.Nome, message.CREF, message.Email);

            var professorExistente = await _professorRepository.ObterPorId(professor.Id);

            if (professorExistente is null) {
                AdicionarErro("Professor não encontrado.");
                return ValidationResult;
            }

            var crefExistente = await _professorRepository.ObterPorCREF(message.CREF);

            if (crefExistente != null && professor.Id != crefExistente.Id) {
                AdicionarErro("Este CREF já está em uso.");
                return ValidationResult;
            }

            _professorRepository.SituacaoProfessor(professor);

            return await PersistirDados(_professorRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtivarDesativarProfessorCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var professor = await _professorRepository.ObterPorId(message.Id);

            if (professor is null) {
                AdicionarErro("Professor não existe.");
                return ValidationResult;
            }

            professor.AlternarSituacao();
            _professorRepository.SituacaoProfessor(professor);

            return await PersistirDados(_professorRepository.UnitOfWork);
        }
    }
}