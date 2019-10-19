using Challenge.Domain.Core.Notifications;
using Challenge.Domain.Handlers;
using Challenge.Domain.Interfaces;
using Challenge.Domain.Models;
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
            var product = Product.ProductFactory.NewProductFull(request.Id, request.Name, request.Price, request.CategoryId);

            if (!ProductValid(product)) return Task.FromResult(Unit.Value);

            _productRepository.Add(product);

            if (Commit())
            {
                //Event Sourcing
                //Event after saving product.
            }

            return Task.FromResult(Unit.Value);
        }

        public Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var productCurrent = _productRepository.GetById(request.Id);

            if (productCurrent != null)
            {
                _mediator.Publish(new DomainNotification(request.MessageType, "Product not found."));
                return Task.FromResult(Unit.Value);
            }

            _productRepository.Remove(request.Id);

            if (Commit())
            {
                //Event Sourcing
                //Event after update product.
            }

            return Task.FromResult(Unit.Value);
        }

        public Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productCurrent = _productRepository.GetById(request.Id);

            if (productCurrent != null)
            {
                _mediator.Publish(new DomainNotification(request.MessageType, "Category not found."));
                return Task.FromResult(Unit.Value);
            }

            var product = Product.ProductFactory.NewProductFull(request.Id, request.Name, request.Price, request.CategoryId);

            if (!ProductValid(product)) return Task.FromResult(Unit.Value);

            _productRepository.UpDate(product);

            if (Commit())
            {
                //Event Sourcing
                //Event after update product.
            }

            return Task.FromResult(Unit.Value);
        }

        private bool ProductValid(Product product)
        {
            if (product.IsValid()) return true;

            NotificarValidacoesErro(product.ValidationResult);
            return false;
        }
    }
}
