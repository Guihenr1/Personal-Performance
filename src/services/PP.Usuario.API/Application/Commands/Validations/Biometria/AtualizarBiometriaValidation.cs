using PP.Usuario.API.Application.Commands.Biometria;

namespace PP.Usuario.API.Application.Commands.Validations.Biometria
{
    public class AtualizarBiometriaValidation : BiometriaValidation<AtualizarBiometriaCommand>
    {
        public AtualizarBiometriaValidation()
        {
            ValidateId();
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