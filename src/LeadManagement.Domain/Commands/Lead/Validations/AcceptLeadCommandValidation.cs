namespace LeadManagement.Domain.Commands.Lead.Validations
{
    public class AcceptLeadCommandValidation : LeadValidation<AcceptLeadCommand>
    {
        public AcceptLeadCommandValidation()
        {
            ValidateId();
        }
    }
}