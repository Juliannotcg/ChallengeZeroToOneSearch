using Challenge.Domain.Core.Notifications;
using Challenge.Domain.Handlers;
using Challenge.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Domain.Commands.CategoryCommands
{
    public class CategoryCommandHandler : CommandHandler,
        IRequestHandler<RegisterCategoryCommand>,
        IRequestHandler<RemoveCategoryCommand>,
        IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediatorHandler _mediator;

        public CategoryCommandHandler(ICategoryRepository categoryRepository,
                                    IUnitOfWork uow,
                                    INotificationHandler<DomainNotification> notifications,
                                    IMediatorHandler mediator) : base(uow, mediator, notifications)
        {
            _categoryRepository = categoryRepository;
            _mediator = mediator;
        }

        public Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(RegisterCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
