using System.Threading.Tasks;

namespace Slice.Services.Identity.Application.Services.Contracts
{
    public interface IMessageBroker
    {
        Task PublishAsync(params IEvent[] events);
    }
}
