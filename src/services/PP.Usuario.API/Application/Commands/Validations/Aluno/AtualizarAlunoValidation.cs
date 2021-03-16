using PP.Usuario.API.Application.Commands.Aluno;

namespace PP.Usuario.API.Application.Commands.Validations.Aluno
{
    public class AtualizarAlunoValidation : AlunoValidation<AtualizarAlunoCommand>
    {
        public AtualizarAlunoValidation()
        {
            ValidateId();
            ValidateEmail();
            ValidateNome();
            ValidateDataNascimento();
        }
    }
}