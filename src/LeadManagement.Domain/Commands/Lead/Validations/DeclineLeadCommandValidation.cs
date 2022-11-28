namespace LeadManagement.Domain.Commands.Lead.Validations
{
    public class DeclineLeadCommandValidation : LeadValidation<DeclineLeadCommand>
    {
        public DeclineLeadCommandValidation()
        {
            ValidateId();
        }
    }
}