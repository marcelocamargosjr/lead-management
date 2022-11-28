using FluentValidation.Results;
using LeadManagement.Domain.Commands.Lead.Validations;
using MediatR;

namespace LeadManagement.Domain.Commands.Lead
{
    public class RemoveLeadCommand : LeadCommand, IRequest<ValidationResult>
    {
        public RemoveLeadCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveLeadCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}