using System;
using FluentValidation;
using PP.Usuario.API.Application.Commands.Professor;

namespace PP.Usuario.API.Application.Commands.Validations.Professor
{
    public class ProfessorValidation<T> : AbstractValidator<T> where T : ProfessorCommand {
        protected void ValidateId() {
            RuleFor(a => a.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do professor inválido");
        }

        protected void ValidateEmail() {
            RuleFor(a => a.Email)
                .Must(TerEmailValido)
                .WithMessage("O e-mail informado não é valido");
        }

        protected void ValidateCREF() {
            RuleFor(a => a.CREF)
                .NotEmpty()
                .WithMessage("CREF do professor inválido");
        }

        protected void ValidateNome() {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("Informe o nome")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres");
        }

        protected void ValidateDataCadastro() {
            RuleFor(a => a.DataCadastro)
                .NotEmpty()
                .WithMessage("Data cadastro do professor inválido");
        }

        public static bool TerEmailValido(string email) {
            return Core.DomainObjects.Email.Validar(email);
        }
    }
}