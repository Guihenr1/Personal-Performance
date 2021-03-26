using System;
using FluentValidation;
using PP.Usuario.API.Application.Commands.Biometria;

namespace PP.Usuario.API.Application.Commands.Validations.Biometria
{
    public class BiometriaValidation<T> : AbstractValidator<T> where T : BiometriaCommand {
        protected void ValidateId() {
            RuleFor(a => a.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da biometria inválido");
        }

        protected void ValidatePeso()
        {
            RuleFor(a => a.Peso)
                .LessThan(300)
                .GreaterThan(50)
                .WithMessage("Peso inválido");
        }

        protected void ValidateAltura() {
            RuleFor(a => a.Altura)
                .LessThan(300)
                .GreaterThan(50)
                .WithMessage("Altura inválida");
        }

        protected void ValidateBracoDireito() {
            RuleFor(a => a.BracoDireito)
                .LessThan(300)
                .GreaterThan(50)
                .WithMessage("Braço direito inválido");
        }

        protected void ValidateBracoEsquerdo() {
            RuleFor(a => a.BracoEsquerdo)
                .LessThan(300)
                .GreaterThan(50)
                .WithMessage("Braco esquerdo inválido");
        }

        protected void ValidateTorax() {
            RuleFor(a => a.Torax)
                .LessThan(300)
                .GreaterThan(50)
                .WithMessage("Torax inválido");
        }

        protected void ValidateCintura() {
            RuleFor(a => a.Cintura)
                .LessThan(300)
                .GreaterThan(50)
                .WithMessage("Cintura inválida");
        }

        protected void ValidateQuadril() {
            RuleFor(a => a.Quadril)
                .LessThan(300)
                .GreaterThan(50)
                .WithMessage("Quadril inválido");
        }

        protected void ValidateCoxaDireita() {
            RuleFor(a => a.CoxaDireita)
                .LessThan(300)
                .GreaterThan(50)
                .WithMessage("Coxa direita inválida");
        }

        protected void ValidateCoxaEsquerda() {
            RuleFor(a => a.CoxaEsquerda)
                .LessThan(300)
                .GreaterThan(50)
                .WithMessage("Coxa esquerda inválida");
        }

        protected void ValidateGemeoDireito() {
            RuleFor(a => a.GemeoDireito)
                .LessThan(300)
                .GreaterThan(50)
                .WithMessage("Gemeo direito inválido");
        }

        protected void ValidateGemeoEsquerdo() {
            RuleFor(a => a.GemeoEsquerdo)
                .LessThan(300)
                .GreaterThan(50)
                .WithMessage("Gemeo esquerdo inválido");
        }

        protected void ValidateAntebracoDireito() {
            RuleFor(a => a.AntebracoDireito)
                .LessThan(300)
                .GreaterThan(50)
                .WithMessage("Antebraço direito inválido");
        }

        protected void ValidateAntebracoEsquerdo() {
            RuleFor(a => a.AntebracoEsquerdo)
                .LessThan(300)
                .GreaterThan(50)
                .WithMessage("Antebraco esquerdo inválido");
        }

        protected void ValidateDataCadastro() {
            RuleFor(a => a.DataCadastro)
                .NotEmpty()
                .WithMessage("Data cadastro inválida");
        }
    }
}