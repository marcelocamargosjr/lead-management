using FluentValidation;

namespace LeadManagement.Domain.Commands.Lead.Validations
{
    public abstract class LeadValidation<T> : AbstractValidator<T> where T : LeadCommand
    {
        protected void ValidateId()
        {
            RuleFor(l => l.Id)
                .NotEqual(Guid.Empty).WithMessage("O campo identificação é obrigatório.");
        }

        protected void ValidateContactFirstName()
        {
            RuleFor(l => l.ContactFirstName)
                .NotEmpty().WithMessage("O campo primeiro nome é obrigatório.")
                .Length(2, 255).WithMessage("O campo primeiro nome deve ter entre 2 e 255 caracteres.");
        }

        protected void ValidateContactFullName()
        {
            RuleFor(l => l.ContactFullName)
                .NotEmpty().WithMessage("O campo nome completo é obrigatório.")
                .Length(2, 255).WithMessage("O campo nome completo deve ter entre 2 e 255 caracteres.");
        }

        protected void ValidateContactPhoneNumber()
        {
            RuleFor(l => l.ContactPhoneNumber)
                .NotEmpty().WithMessage("O campo número de telefone é obrigatório.");
        }

        protected void ValidateContactEmail()
        {
            RuleFor(l => l.ContactEmail)
                .NotEmpty().WithMessage("O campo e-mail é obrigatório.")
                .EmailAddress().WithMessage("O campo e-mail está inválido.");
        }

        protected void ValidateSuburb()
        {
            RuleFor(l => l.Suburb)
                .NotEmpty().WithMessage("O campo subúrbio é obrigatório.")
                .Length(2, 255).WithMessage("O campo subúrbio deve ter entre 2 e 255 caracteres.");
        }

        protected void ValidateCategory()
        {
            RuleFor(l => l.Category)
                .NotEmpty().WithMessage("O campo categoria é obrigatório.")
                .Length(2, 255).WithMessage("O campo categoria deve ter entre 2 e 255 caracteres.");
        }

        protected void ValidateDescription()
        {
            RuleFor(l => l.Description)
                .NotEmpty().WithMessage("O campo descrição é obrigatório.")
                .Length(2, 255).WithMessage("O campo descrição deve ter entre 2 e 255 caracteres.");
        }

        protected void ValidatePrice()
        {
            RuleFor(l => l.Price)
                .GreaterThan(0).WithMessage("O campo preço deve ser maior que zero.");
        }
    }
}