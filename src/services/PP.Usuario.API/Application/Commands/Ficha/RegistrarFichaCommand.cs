using System;
using PP.Usuario.API.Application.Commands.Validations.Ficha;

namespace PP.Usuario.API.Application.Commands.Ficha
{
    public class RegistrarFichaCommand : FichaCommand {
        public RegistrarFichaCommand(string objetivo, DateTime dataCadastro, Guid alunoId, Guid anamneseRespostaId) {
            Objetivo = objetivo;
            DataCadastro = dataCadastro;
            AlunoId = alunoId;
            AnamneseRespostaId = anamneseRespostaId;
        }

        public override bool EhValido() {
            ValidationResult = new RegistrarFichaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}