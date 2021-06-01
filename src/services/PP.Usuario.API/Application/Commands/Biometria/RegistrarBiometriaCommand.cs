using System;
using PP.Usuario.API.Application.Commands.Validations.Biometria;

namespace PP.Usuario.API.Application.Commands.Biometria
{
    public class RegistrarBiometriaCommand : BiometriaCommand {
        public RegistrarBiometriaCommand(int peso, double altura, int bracoDireito, int bracoEsquerdo, int torax, int cintura, int quadril, int coxaDireita, int coxaEsquerda, int gemeoDireito, int gemeoEsquerdo, int antebracoDireito, int antebracoEsquerdo) {
            Peso = peso;
            Altura = altura;
            BracoDireito = bracoDireito;
            BracoEsquerdo = bracoEsquerdo;
            Torax = torax;
            Cintura = cintura;
            Quadril = quadril;
            CoxaDireita = coxaDireita;
            CoxaEsquerda = coxaEsquerda;
            GemeoDireito = gemeoDireito;
            GemeoEsquerdo = gemeoEsquerdo;
            AntebracoDireito = antebracoDireito;
            AntebracoEsquerdo = antebracoEsquerdo;
            DataCadastro = DateTime.Now;
        }

        public override bool EhValido() {
            ValidationResult = new RegistrarBiometriaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}