using FluentValidation.Results;

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
    }
}