using LeadManagement.Domain.Core.Events;
using LeadManagement.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infra.Data.Repository.EventSourcing
{
    public class EventStoreSqlRepository : IEventStoreRepository
    {
        private readonly EventStoreSqlContext _context;

        public EventStoreSqlRepository(EventStoreSqlContext context)
        {
            _context = context;
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvents.Add(theEvent);
            _context.SaveChanges();
        }

        public async Task<IList<StoredEvent>> All(Guid aggregateId)
        {
            return await (from e in _context.StoredEvents where e.AggregateId == aggregateId select e).ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}