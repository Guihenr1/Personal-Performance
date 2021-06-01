using System;
using PP.Usuario.API.Application.Commands.Validations.Ficha;

namespace PP.Usuario.API.Application.Commands.Ficha
{
    public class AtualizarFichaCommand : FichaCommand {
        public AtualizarFichaCommand(Guid id, string objetivo, DateTime dataCadastro, Guid alunoId, Guid anamneseRespostaId)
        {
            Id = id;
            Objetivo = objetivo;
            DataCadastro = dataCadastro;
            AlunoId = alunoId;
            AnamneseRespostaId = anamneseRespostaId;
        }

        public override bool EhValido() {
            ValidationResult = new AtualizarFichaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}