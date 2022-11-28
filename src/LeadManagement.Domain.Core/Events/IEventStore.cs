using NetDevPack.Messaging;

namespace LeadManagement.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}