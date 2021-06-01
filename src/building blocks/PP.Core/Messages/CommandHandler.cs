using System.Threading.Tasks;
using FluentValidation.Results;
using PP.Core.Data;

namespace PP.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult { get; set; }

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AdicionarErro(string menssagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, menssagem));
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWork uow) {
            if (!await uow.Commit()) AdicionarErro("Houve um erro ao inserir os dados");

            return ValidationResult;
        }
    }
}