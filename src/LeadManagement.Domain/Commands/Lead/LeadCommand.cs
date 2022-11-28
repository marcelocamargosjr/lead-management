using LeadManagement.Domain.Core.Commands;

namespace LeadManagement.Domain.Commands.Lead
{
    public abstract class LeadCommand : Command
    {
        public Guid Id { get; protected set; }
        public string ContactFirstName { get; protected set; }
        public string ContactFullName { get; protected set; }
        public string ContactPhoneNumber { get; protected set; }
        public string ContactEmail { get; protected set; }
        public string Suburb { get; protected set; }
        public string Category { get; protected set; }
        public string Description { get; protected set; }
        public decimal Price { get; protected set; }
    }
}