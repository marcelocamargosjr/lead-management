using NetDevPack.Messaging;

namespace LeadManagement.Domain.Events.Lead
{
    public class LeadRemovedEvent : Event
    {
        public LeadRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; }
    }
}