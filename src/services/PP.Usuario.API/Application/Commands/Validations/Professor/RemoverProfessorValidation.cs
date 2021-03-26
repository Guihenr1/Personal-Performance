using PP.Usuario.API.Application.Commands.Professor;

namespace PP.Usuario.API.Application.Commands.Validations.Professor
{
    public class RemoverProfessorValidation : ProfessorValidation<RemoverProfessorCommand> {
        public RemoverProfessorValidation()
        {
            ValidateId();
        }
    }
}