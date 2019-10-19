using AutoMapper;
using Challenge.Api.ViewModel;
using Challenge.Domain.Commands.CategoryCommands;
using Challenge.Domain.Core.Notifications;
using Challenge.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Challenge.Api.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public CategoryController(INotificationHandler<DomainNotification> notifications,
                                 ICategoryRepository eventoRepository,
                                 IMapper mapper,
                                 IMediatorHandler mediator) : base(notifications, mediator)
        {
            _categoryRepository = eventoRepository;
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpGet]
        [Route("categories")]
        public IEnumerable<CategoryViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(_categoryRepository.GetAll());
        }

        [HttpGet]
        [Route("category/{id:guid}")]
        public CategoryViewModel GetById(Guid id)
        {
            return _mapper.Map<CategoryViewModel>(_categoryRepository.GetById(id));
        }

        [HttpPost]
        [Route("category")]
        public IActionResult Post([FromBody]CategoryViewModel categoryViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var categoryCommand = _mapper.Map<RegisterCategoryCommand>(categoryViewModel);
            _mediator.SendCommand(categoryCommand);
            return Response(categoryCommand);
        }

        [HttpPut]
        [Route("category")]
        public IActionResult Put([FromBody]CategoryViewModel categoryViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var categoryCommand = _mapper.Map<UpdateCategoryCommand>(categoryViewModel);

            _mediator.SendCommand(categoryCommand);
            return Response(categoryCommand);
        }

        [HttpDelete]
        [Route("category/{id:guid}")]
        public IActionResult Remove(Guid id)
        {
            var categoryViewModel = new CategoryViewModel { Id = id };
            var categoryCommand = _mapper.Map<RemoveCategoryCommand>(categoryViewModel);
            _mediator.SendCommand(categoryCommand);
            return Response(categoryCommand);
        }

        private bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;
            ReportErroModelInvalid();
            return false;
        }
    }
}
