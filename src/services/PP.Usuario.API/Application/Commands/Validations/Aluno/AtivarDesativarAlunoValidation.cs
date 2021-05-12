using PP.Usuario.API.Application.Commands.Aluno;

namespace PP.Usuario.API.Application.Commands.Validations.Aluno
{
    public class AtivarDesativarAlunoValidation : AlunoValidation<AtivarDesativarAlunoCommand>
    {
        public AtivarDesativarAlunoValidation()
        {
            ValidateId();
        }
    }
}