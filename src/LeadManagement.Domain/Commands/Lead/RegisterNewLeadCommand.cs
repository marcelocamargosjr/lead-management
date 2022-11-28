using LeadManagement.Domain.Commands.Lead.Validations;
using MediatR;

namespace LeadManagement.Domain.Commands.Lead
{
    public class RegisterNewLeadCommand : LeadCommand, IRequest<object>
    {
        public RegisterNewLeadCommand(string contactFirstName, string contactFullName, string contactPhoneNumber, string contactEmail,
            string suburb, string category, string description, decimal price)
        {
            ContactFirstName = contactFirstName;
            ContactFullName = contactFullName;
            ContactPhoneNumber = contactPhoneNumber;
            ContactEmail = contactEmail;
            Suburb = suburb;
            Category = category;
            Description = description;
            Price = price;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewLeadCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}