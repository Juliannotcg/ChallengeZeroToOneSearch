using Challenge.Domain.Core.Notifications;
using Challenge.Domain.Handlers;
using Challenge.Domain.Interfaces;
using Challenge.Domain.Models;
using MediatR;
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

        public Task<Unit> Handle(RegisterCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = Category.CategoryFactory.NewCategoryFull(request.Id, request.Name);

            if (!CategoryValid(category)) return Task.FromResult(Unit.Value);

            _categoryRepository.Add(category);

            if (Commit())
            {
                //Event Sourcing
                //Event after saving category.
            }

            return Task.FromResult(Unit.Value);
        }

        public Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryCurrent = _categoryRepository.GetById(request.Id);

            if (categoryCurrent != null)
            {
                _mediator.Publish(new DomainNotification(request.MessageType, "Category not found."));
                return Task.FromResult(Unit.Value);
            }

            var category = Category.CategoryFactory.NewCategoryFull(request.Id, request.Name);

            if (!CategoryValid(category)) return Task.FromResult(Unit.Value);

            _categoryRepository.UpDate(category);
            if (Commit())
            {
                //Event Sourcing
                //Event after update category.
            }

            return Task.FromResult(Unit.Value);
        }

        public Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryCurrent = _categoryRepository.GetById(request.Id);

            if (categoryCurrent != null)
            {
                _mediator.Publish(new DomainNotification(request.MessageType, "Category not found."));
                return Task.FromResult(Unit.Value);
            }

            _categoryRepository.Remove(request.Id);

            if (Commit())
            {
                //Event Sourcing
                //Event after update category.
            }

            return Task.FromResult(Unit.Value);
        }

        private bool CategoryValid(Category category)
        {
            if (category.IsValid()) return true;

            NotificarValidacoesErro(category.ValidationResult);
            return false;
        }
    }
}
