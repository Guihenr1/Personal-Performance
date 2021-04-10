using System;
using FluentValidation;
using PP.Usuario.API.Application.Commands.Aluno;

namespace PP.Usuario.API.Application.Commands.Validations.Aluno
{
    public class AlunoValidation<T> : AbstractValidator<T> where T : AlunoCommand {
        protected void ValidateId()
        {
            RuleFor(a => a.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do aluno inválido");
        }
        protected void ValidateProfessorId() {
            RuleFor(a => a.ProfessorId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do professor inválido");
        }

        protected void ValidateEmail() {
            RuleFor(a => a.Email)
                .Must(TerEmailValido)
                .WithMessage("O e-mail informado não é valido");
        }

        protected void ValidateNome() {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("Informe o nome")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres");
        }

        protected void ValidateDataNascimento() {
            RuleFor(c => c.DataNascimento)
                .NotEmpty()
                .Must(terIdadeMinima)
                .WithMessage("O aluno deve ter no mínimo 18 anos");
        }

        protected void ValidateCep() {
            RuleFor(a => a.Cep)
                .NotEmpty().WithMessage("Informe o cep")
                .Length(8).WithMessage("O cep ter 8 caracteres");
        }

        protected void ValidateLogradouro() {
            RuleFor(a => a.Logradouro)
                .NotEmpty().WithMessage("Informe o logradouro")
                .Length(2, 100).WithMessage("O logradouro deve ter entre 2 e 100 caracteres");
        }

        protected void ValidateNumero()
        {
            RuleFor(a => a.Numero)
                .GreaterThan(0).WithMessage("Informe o numero");
        }

        protected void ValidateBairro() {
            RuleFor(a => a.Bairro)
                .NotEmpty().WithMessage("Informe o bairro")
                .Length(2, 50).WithMessage("O bairro deve ter entre 2 e 50 caracteres");
        }

        protected void ValidateComplemento() {
            RuleFor(a => a.Complemento)
                .NotEmpty().WithMessage("Informe o complemento")
                .Length(2, 50).WithMessage("O complemento deve ter entre 2 e 50 caracteres");
        }

        protected void ValidateCidade() {
            RuleFor(a => a.Cidade)
                .NotEmpty().WithMessage("Informe a cidade")
                .Length(2, 50).WithMessage("A cidade deve ter entre 2 e 50 caracteres");
        }
        protected void ValidateEstadoId() {
            RuleFor(a => a.EstadoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do estado inválido");
        }

        protected static bool terIdadeMinima(DateTime dataNascimento) {
            return dataNascimento <= DateTime.Now.AddYears(-18);
        }

        public static bool TerEmailValido(string email) {
            return Core.DomainObjects.Email.Validar(email);
        }
    }
}