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

        protected void ValidateEmail() {
            RuleFor(a => a.Email)
                .Must(TerEmailValido)
                .WithMessage("O e-mail informado não é valido");
        }

        protected void ValidateNome() {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("Informe o nome")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 100 caracteres");
        }

        protected void ValidateDataNascimento() {
            RuleFor(c => c.DataNascimento)
                .NotEmpty()
                .Must(terIdadeMinima)
                .WithMessage("O aluno deve ter no mínimo 18 anos");
        }

        protected static bool terIdadeMinima(DateTime dataNascimento) {
            return dataNascimento <= DateTime.Now.AddYears(-18);
        }

        public static bool TerEmailValido(string email) {
            return Core.DomainObjects.Email.Validar(email);
        }
    }
}