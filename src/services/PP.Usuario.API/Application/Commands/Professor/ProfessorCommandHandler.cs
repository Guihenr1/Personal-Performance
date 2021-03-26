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
        IRequestHandler<RemoverProfessorCommand, ValidationResult> {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorCommandHandler(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarProfessorCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var professor = new Models.Professor(Guid.NewGuid(), message.Nome, message.CREF, message.Email);

            var professorExistente = await _professorRepository.ObterPorEmail(professor.Email.Endereco);

            if (professorExistente != null)
            {
                AdicionarErro("Este e-mail já está em uso.");
                return ValidationResult;
            }

            _professorRepository.Adicionar(professor);

            return await PersistirDados(_professorRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarProfessorCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var professor = new Models.Professor(message.Id, message.Nome, message.CREF, message.Email);

            var professorExistente = await _professorRepository.ObterPorEmail(professor.Email.Endereco);

            if (professorExistente != null && professor.Id != professorExistente.Id) {
                AdicionarErro("Este e-mail já está em uso.");
                return ValidationResult;
            }

            _professorRepository.Atualizar(professor);

            return await PersistirDados(_professorRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverProfessorCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var professor = await _professorRepository.ObterPorId(message.Id);

            if (professor is null) {
                AdicionarErro("Professor não existe.");
                return ValidationResult;
            }

            professor.ExcluirProfessor();
            _professorRepository.Atualizar(professor);

            return await PersistirDados(_professorRepository.UnitOfWork);
        }
    }
}