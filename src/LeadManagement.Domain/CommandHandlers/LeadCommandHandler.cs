using FluentValidation.Results;
using LeadManagement.Domain.Commands.Lead;
using LeadManagement.Domain.Events.Lead;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Domain.Models;
using MediatR;
using NetDevPack.Messaging;

namespace LeadManagement.Domain.CommandHandlers
{
    public class LeadCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewLeadCommand, object>,
        IRequestHandler<RemoveLeadCommand, ValidationResult>,
        IRequestHandler<AcceptLeadCommand, ValidationResult>,
        IRequestHandler<DeclineLeadCommand, ValidationResult>
    {
        private readonly ILeadRepository _leadRepository;

        public LeadCommandHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<object> Handle(RegisterNewLeadCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var lead = new Lead(Guid.NewGuid(), message.ContactFirstName, message.ContactFullName, message.ContactPhoneNumber, message.ContactEmail,
                message.Suburb, message.Category, message.Description, message.Price);

            lead.AddDomainEvent(new LeadRegisteredEvent(lead.Id, lead.ContactFirstName, lead.ContactFullName, lead.ContactPhoneNumber, lead.ContactEmail,
                lead.Suburb, lead.Category, lead.JobId, lead.Description, lead.Price,
                lead.Status));

            _leadRepository.Add(lead);

            var result = await Commit(_leadRepository.UnitOfWork);

            return result.IsValid ? lead : result;
        }

        public async Task<ValidationResult> Handle(RemoveLeadCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var lead = await _leadRepository.GetById(message.Id);

            if (lead is null)
            {
                AddError("O registro não existe.");
                return ValidationResult;
            }

            lead.AddDomainEvent(new LeadRemovedEvent(message.Id));

            _leadRepository.Remove(lead);

            return await Commit(_leadRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AcceptLeadCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var lead = await _leadRepository.GetById(message.Id);

            if (lead is null)
            {
                AddError("O registro não existe.");
                return ValidationResult;
            }

            lead.Accepted();

            lead.AddDomainEvent(new LeadAcceptedEvent(lead.Id, lead.ContactFirstName, lead.ContactFullName, lead.ContactPhoneNumber, lead.ContactEmail,
                lead.Suburb, lead.Category, lead.JobId, lead.Description, lead.Price,
                lead.Status));

            _leadRepository.Update(lead);

            return await Commit(_leadRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeclineLeadCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var lead = await _leadRepository.GetById(message.Id);

            if (lead is null)
            {
                AddError("O registro não existe.");
                return ValidationResult;
            }

            lead.Declined();

            lead.AddDomainEvent(new LeadDeclinedEvent(lead.Id, lead.ContactFirstName, lead.ContactFullName, lead.ContactPhoneNumber, lead.ContactEmail,
                lead.Suburb, lead.Category, lead.JobId, lead.Description, lead.Price,
                lead.Status));

            _leadRepository.Update(lead);

            return await Commit(_leadRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _leadRepository.Dispose();
        }
    }
}