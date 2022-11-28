using FluentValidation.Results;
using LeadManagement.Domain.Commands.Lead.Validations;
using MediatR;

namespace LeadManagement.Domain.Commands.Lead
{
    public class DeclineLeadCommand : LeadCommand, IRequest<ValidationResult>
    {
        public DeclineLeadCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeclineLeadCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}