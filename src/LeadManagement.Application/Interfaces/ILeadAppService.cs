using FluentValidation.Results;
using LeadManagement.Application.EventSourcedNormalizers.Lead;
using LeadManagement.Application.ViewModels.v1.Lead;

namespace LeadManagement.Application.Interfaces
{
    public interface ILeadAppService : IDisposable
    {
        Task<IEnumerable<LeadViewModel>> GetAll();
        Task<IEnumerable<LeadViewModel>> GetAllInvited();
        Task<IEnumerable<LeadViewModel>> GetAllAccepted();
        Task<object> GetById(Guid id);
        Task<object> Register(RegisterNewLeadViewModel leadViewModel);
        Task<ValidationResult> Remove(Guid id);
        Task<ValidationResult> Accept(Guid id);
        Task<ValidationResult> Decline(Guid id);
        Task<IList<LeadHistoryData>> GetAllHistory(Guid id);
    }
}