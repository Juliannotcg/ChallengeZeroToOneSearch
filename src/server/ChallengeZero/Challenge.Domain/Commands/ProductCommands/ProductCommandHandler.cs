using Challenge.Domain.Core.Notifications;
using Challenge.Domain.Handlers;
using Challenge.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Domain.Commands.ProductCommands
{
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<RegisterProductCommand>,
        IRequestHandler<RemoveProductCommand>,
        IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler _mediator;

        public ProductCommandHandler(IProductRepository productRepository,
                                    IUnitOfWork uow,
                                    INotificationHandler<DomainNotification> notifications,
                                    IMediatorHandler mediator) : base(uow, mediator, notifications)
        {
            _productRepository = productRepository;
            _mediator = mediator;
        }

        public Task<Unit> Handle(RegisterProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
