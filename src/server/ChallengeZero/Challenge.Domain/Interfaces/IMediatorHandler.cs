using Challenge.Domain.Core.Commands;
using Challenge.Domain.Core.Events;
using System.Threading.Tasks;

namespace Challenge.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task Publish<T>(T evento) where T : Event;
        Task SendCommand<T>(T comando) where T : Command;
    }
}
