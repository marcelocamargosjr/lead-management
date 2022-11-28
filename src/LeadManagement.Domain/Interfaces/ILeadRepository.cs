using LeadManagement.Domain.Models;

namespace LeadManagement.Domain.Interfaces
{
    public interface ILeadRepository : IRepository<Lead>
    {
        Task<IList<Lead>> GetAllInvited();
        Task<IList<Lead>> GetAllAccepted();
    }
}