namespace LeadManagement.Domain.Commands.Lead.Validations
{
    public class RegisterNewLeadCommandValidation : LeadValidation<RegisterNewLeadCommand>
    {
        public RegisterNewLeadCommandValidation()
        {
            ValidateContactFirstName();
            ValidateContactFullName();
            ValidateContactPhoneNumber();
            ValidateContactEmail();
            ValidateSuburb();
            ValidateCategory();
            ValidateDescription();
            ValidatePrice();
        }
    }
}