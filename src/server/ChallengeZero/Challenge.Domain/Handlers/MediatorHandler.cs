using System.Threading.Tasks;
using Challenge.Domain.Core.Commands;
using Challenge.Domain.Core.Events;
using Challenge.Domain.Interfaces;
using MediatR;

namespace Challenge.Domain.Handlers
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Publish<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public async Task SendCommand<T>(T comando) where T : Command
        {
            await _mediator.Send(comando);
        }
    }
}