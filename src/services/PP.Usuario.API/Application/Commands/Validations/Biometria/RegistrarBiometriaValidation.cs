using PP.Usuario.API.Application.Commands.Biometria;

namespace PP.Usuario.API.Application.Commands.Validations.Biometria
{
    public class RegistrarBiometriaValidation : BiometriaValidation<RegistrarBiometriaCommand> {
        public RegistrarBiometriaValidation()
        {
            ValidatePeso();
            ValidateAltura();
            ValidateBracoDireito();
            ValidateBracoEsquerdo();
            ValidateTorax();
            ValidateCintura();
            ValidateQuadril();
            ValidateCoxaDireita();
            ValidateCoxaEsquerda();
            ValidateGemeoDireito();
            ValidateGemeoEsquerdo();
            ValidateAntebracoDireito();
            ValidateAntebracoEsquerdo();
            ValidateDataCadastro();
        }
    }
}