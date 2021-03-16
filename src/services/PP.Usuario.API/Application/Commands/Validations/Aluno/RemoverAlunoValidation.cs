using PP.Usuario.API.Application.Commands.Aluno;

namespace PP.Usuario.API.Application.Commands.Validations.Aluno
{
    public class RemoverAlunoValidation : AlunoValidation<RemoverAlunoCommand>
    {
        public RemoverAlunoValidation()
        {
            ValidateId();
        }
    }
}