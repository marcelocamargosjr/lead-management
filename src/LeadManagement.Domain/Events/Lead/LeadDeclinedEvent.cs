using LeadManagement.Domain.Enums;
using NetDevPack.Messaging;

namespace LeadManagement.Domain.Events.Lead
{
    public class LeadDeclinedEvent : Event
    {
        public LeadDeclinedEvent(Guid id, string contactFirstName, string contactFullName, string contactPhoneNumber, string contactEmail,
            string suburb, string category, long jobId, string description, decimal price,
            LeadStatus status)
        {
            Id = id;
            ContactFirstName = contactFirstName;
            ContactFullName = contactFullName;
            ContactPhoneNumber = contactPhoneNumber;
            ContactEmail = contactEmail;
            Suburb = suburb;
            Category = category;
            JobId = jobId;
            Description = description;
            Price = price;
            Status = status;
            AggregateId = id;
        }

        public Guid Id { get; }
        public string ContactFirstName { get; }
        public string ContactFullName { get; }
        public string ContactPhoneNumber { get; }
        public string ContactEmail { get; }
        public string Suburb { get; }
        public string Category { get; }
        public long JobId { get; }
        public string Description { get; }
        public decimal Price { get; }
        public LeadStatus Status { get; }
    }
}