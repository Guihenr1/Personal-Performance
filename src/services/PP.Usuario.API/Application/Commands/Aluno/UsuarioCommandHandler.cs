using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using PP.Core.Messages;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Application.Commands.Aluno {
    public class UsuarioCommandHandler : CommandHandler, IRequestHandler<RegistrarAlunoCommand, ValidationResult>
    {
        private readonly IAlunoRepository _alunoRepository;

        public UsuarioCommandHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarAlunoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var aluno = new Models.Aluno(message.Id, message.Nome, message.DataNascimento, message.Email);

            var alunoExistente = await _alunoRepository.ObterPorEmail(aluno.Email.Endereco);

            if (alunoExistente != null)
            {
                AdicionarErro("Este e-mail já está em uso.");
                return ValidationResult;
            }

            _alunoRepository.Adicionar(aluno);

            return await PersistirDados(_alunoRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarAlunoCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var aluno = new Models.Aluno(message.Id, message.Nome, message.DataNascimento, message.Email);

            var alunoExistente = await _alunoRepository.ObterPorEmail(aluno.Email.Endereco);

            if (alunoExistente != null && aluno.Id != alunoExistente.Id) {
                AdicionarErro("Este e-mail já está em uso.");
                return ValidationResult;
            }

            _alunoRepository.Atualizar(aluno);

            return await PersistirDados(_alunoRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverAlunoCommand message, CancellationToken cancellationToken) {
            if (!message.EhValido()) return message.ValidationResult;

            var aluno = await _alunoRepository.ObterPorId(message.Id);

            if (aluno is null) {
                AdicionarErro("Aluno não existe.");
                return ValidationResult;
            }

            aluno.ExcluirAluno();
            _alunoRepository.Atualizar(aluno);

            return await PersistirDados(_alunoRepository.UnitOfWork);
        }
    }
}