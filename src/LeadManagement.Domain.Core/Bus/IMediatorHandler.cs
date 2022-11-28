using NetDevPack.Messaging;
using Command = LeadManagement.Domain.Core.Commands.Command;

namespace LeadManagement.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<object?> SendCommand<T>(T command) where T : Command;
    }
}