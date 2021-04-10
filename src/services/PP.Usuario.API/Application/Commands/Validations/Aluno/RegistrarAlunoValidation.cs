using PP.Usuario.API.Application.Commands.Aluno;

namespace PP.Usuario.API.Application.Commands.Validations.Aluno
{
    public class RegistrarAlunoValidation : AlunoValidation<RegistrarAlunoCommand>
    {
        public RegistrarAlunoValidation()
        {
            ValidateProfessorId();
            ValidateEmail();
            ValidateNome();
            ValidateDataNascimento();
            ValidateCep();
            ValidateLogradouro();
            ValidateNumero();
            ValidateBairro();
            ValidateComplemento();
            ValidateCidade();
            ValidateEstadoId();
        }
    }
}