using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Domain.Models;
using LeadManagement.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infra.Data.Repository
{
    public class LeadRepository : Repository<Lead>, ILeadRepository
    {
        public LeadRepository(LeadManagementContext context) : base(context)
        {
        }

        public override async Task<IList<Lead>> GetAll()
        {
            return await DbSet.OrderByDescending(l => l.CreationDate).ToListAsync();
        }

        public async Task<IList<Lead>> GetAllInvited()
        {
            return await DbSet.Where(l => l.Status.Equals(LeadStatus.Invited)).OrderByDescending(l => l.CreationDate).ToListAsync();
        }

        public async Task<IList<Lead>> GetAllAccepted()
        {
            return await DbSet.Where(l => l.Status.Equals(LeadStatus.Accepted)).OrderByDescending(l => l.CreationDate).ToListAsync();
        }
    }
}