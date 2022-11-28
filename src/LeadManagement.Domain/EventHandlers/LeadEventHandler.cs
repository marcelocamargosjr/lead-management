using LeadManagement.Domain.Events.Lead;
using MediatR;

namespace LeadManagement.Domain.EventHandlers
{
    public class LeadEventHandler :
        INotificationHandler<LeadRegisteredEvent>,
        INotificationHandler<LeadRemovedEvent>,
        INotificationHandler<LeadAcceptedEvent>,
        INotificationHandler<LeadDeclinedEvent>
    {
        public Task Handle(LeadRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(LeadRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }

        public Task Handle(LeadAcceptedEvent notification, CancellationToken cancellationToken)
        {
            // Send e-mail

            return Task.CompletedTask;
        }

        public Task Handle(LeadDeclinedEvent notification, CancellationToken cancellationToken)
        {
            // Send e-mail

            return Task.CompletedTask;
        }
    }
}