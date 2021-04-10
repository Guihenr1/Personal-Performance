using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using PP.Core.Messages;
using PP.Usuario.API.Application.Events.Aluno;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Application.Commands.Aluno {
    public class AlunoCommandHandler : CommandHandler, 
        IRequestHandler<RegistrarAlunoCommand, ValidationResult>,
        IRequestHandler<AtualizarAlunoCommand, ValidationResult>,
        IRequestHandler<RemoverAlunoCommand, ValidationResult> {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;

        public AlunoCommandHandler(IAlunoRepository alunoRepository
            , IProfessorRepository professorRepository)
        {
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarAlunoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var alunoId = Guid.NewGuid();
            var aluno = new Models.Aluno(alunoId, message.Nome, message.DataNascimento, message.Email);

            var alunoExistente = await _alunoRepository.ObterPorEmail(aluno.Email.Endereco);
            if (alunoExistente != null)
            {
                AdicionarErro("Este e-mail já está em uso.");
                return ValidationResult;
            }

            var professor = await _professorRepository.ObterPorId(message.ProfessorId);
            if (professor == null) {
                AdicionarErro("Professor não encontrado.");
                return ValidationResult;
            }

            aluno.AtribuirEndereco(new Models.Endereco(
                Guid.NewGuid(), message.Cep, message.Logradouro, message.Numero, message.Bairro, message.Complemento, message.Cidade, 
                message.EstadoId, alunoId));
            aluno.AtribuirProfessor(professor.Id);
            _alunoRepository.Adicionar(aluno);

            aluno.AdicionarEvento(new AlunoRegistradoEvent(message.Id, message.Nome, message.Email, message.DataNascimento, message.Excluido, message.DataCadastro));

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