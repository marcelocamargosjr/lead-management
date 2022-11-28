using FluentValidation.Results;
using LeadManagement.Domain.Commands.Lead.Validations;
using MediatR;

namespace LeadManagement.Domain.Commands.Lead
{
    public class AcceptLeadCommand : LeadCommand, IRequest<ValidationResult>
    {
        public AcceptLeadCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new AcceptLeadCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}