using LeadManagement.Domain.Enums;
using NetDevPack.Domain;
using Entity = LeadManagement.Domain.Core.Models.Entity;

namespace LeadManagement.Domain.Models
{
    public class Lead : Entity, IAggregateRoot
    {
        public Lead(Guid id, string contactFirstName, string contactFullName, string contactPhoneNumber, string contactEmail,
            string suburb, string category, string description, decimal price)
        {
            Id = id;
            ContactFirstName = contactFirstName;
            ContactFullName = contactFullName;
            ContactPhoneNumber = contactPhoneNumber;
            ContactEmail = contactEmail;
            Suburb = suburb;
            Category = category;
            JobId = RandomNumberGenerator();
            Description = description;
            Price = price;
            Status = LeadStatus.Invited;
        }

        // Empty constructor for EF
        protected Lead()
        {
        }

        public string ContactFirstName { get; }
        public string ContactFullName { get; }
        public string ContactPhoneNumber { get; }
        public string ContactEmail { get; }
        public string Suburb { get; }
        public string Category { get; }
        public long JobId { get; }
        public string Description { get; }
        public decimal Price { get; private set; }
        public LeadStatus Status { get; private set; }

        private static long RandomNumberGenerator()
        {
            var generator = new Random();
            return generator.Next(0, 1000000);
        }

        public void Accepted()
        {
            if (Price > 500)
                Price -= Price / 100 * 10;

            Status = LeadStatus.Accepted;
        }

        public void Declined()
        {
            Status = LeadStatus.Declined;
        }
    }
}