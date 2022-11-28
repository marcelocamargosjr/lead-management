namespace LeadManagement.Domain.Commands.Lead.Validations
{
    public class RemoveLeadCommandValidation : LeadValidation<RemoveLeadCommand>
    {
        public RemoveLeadCommandValidation()
        {
            ValidateId();
        }
    }
}