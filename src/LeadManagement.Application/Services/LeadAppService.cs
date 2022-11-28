using AutoMapper;
using FluentValidation.Results;
using LeadManagement.Application.EventSourcedNormalizers.Lead;
using LeadManagement.Application.Interfaces;
using LeadManagement.Application.ViewModels.v1.Lead;
using LeadManagement.Domain.Commands.Lead;
using LeadManagement.Domain.Core.Bus;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Domain.Models;
using LeadManagement.Infra.Data.Repository.EventSourcing;

namespace LeadManagement.Application.Services
{
    public class LeadAppService : AppService, ILeadAppService
    {
        private readonly IMapper _mapper;
        private readonly ILeadRepository _leadRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public LeadAppService(
            IMapper mapper,
            ILeadRepository leadRepository,
            IEventStoreRepository eventStoreRepository,
            IMediatorHandler mediator)
        {
            _mapper = mapper;
            _leadRepository = leadRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<LeadViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<LeadViewModel>>(await _leadRepository.GetAll());
        }

        public async Task<IEnumerable<LeadViewModel>> GetAllInvited()
        {
            return _mapper.Map<IEnumerable<LeadViewModel>>(await _leadRepository.GetAllInvited());
        }

        public async Task<IEnumerable<LeadViewModel>> GetAllAccepted()
        {
            return _mapper.Map<IEnumerable<LeadViewModel>>(await _leadRepository.GetAllAccepted());
        }

        public async Task<object> GetById(Guid id)
        {
            var lead = await _leadRepository.GetById(id);

            if (lead is null)
            {
                AddError("O registro não existe.");
                return ValidationResult;
            }

            return _mapper.Map<LeadViewModel>(lead);
        }

        public async Task<object> Register(RegisterNewLeadViewModel leadViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewLeadCommand>(leadViewModel);
            var registerResult = await _mediator.SendCommand(registerCommand);

            return registerResult is not Lead ? (ValidationResult)registerResult! : _mapper.Map<LeadViewModel>(registerResult);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveLeadCommand(id);

            return (ValidationResult)(await _mediator.SendCommand(removeCommand))!;
        }

        public async Task<ValidationResult> Accept(Guid id)
        {
            var acceptCommand = new AcceptLeadCommand(id);

            return (ValidationResult)(await _mediator.SendCommand(acceptCommand))!;
        }

        public async Task<ValidationResult> Decline(Guid id)
        {
            var declineCommand = new DeclineLeadCommand(id);

            return (ValidationResult)(await _mediator.SendCommand(declineCommand))!;
        }

        public async Task<IList<LeadHistoryData>> GetAllHistory(Guid id)
        {
            return LeadHistory.ToJavaScriptLeadHistory(await _eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}