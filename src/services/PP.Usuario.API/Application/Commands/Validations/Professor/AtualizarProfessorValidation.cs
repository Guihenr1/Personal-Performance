using PP.Usuario.API.Application.Commands.Professor;

namespace PP.Usuario.API.Application.Commands.Validations.Professor
{
    public class AtualizarProfessorValidation : ProfessorValidation<AtualizarProfessorCommand> {
        public AtualizarProfessorValidation()
        {
            ValidateId();
            ValidateEmail();
            ValidateCREF();
            ValidateNome();
        }
    }
}