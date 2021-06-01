using PP.Usuario.API.Application.Commands.Professor;

namespace PP.Usuario.API.Application.Commands.Validations.Professor
{
    public class RegistrarProfessorValidation : ProfessorValidation<RegistrarProfessorCommand> {
        public RegistrarProfessorValidation()
        {
            ValidateId();
            ValidateEmail();
            ValidateCREF();
            ValidateNome();
        }
    }
}