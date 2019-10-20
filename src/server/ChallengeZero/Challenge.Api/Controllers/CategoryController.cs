using AutoMapper;
using Challenge.Api.ViewModel;
using Challenge.Domain.Commands.CategoryCommands;
using Challenge.Domain.Core.Notifications;
using Challenge.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Challenge.Api.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public CategoryController(INotificationHandler<DomainNotification> notifications,
                                 ICategoryRepository categoryRepository,
                                 IMapper mapper,
                                 IMediatorHandler mediator) : base(notifications, mediator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpGet]
        [Route("Categories")]
        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            var response = Task.Run(() => _mapper.Map<IEnumerable<CategoryViewModel>>(_categoryRepository.GetAll()));
            return await response;
        }

        [HttpGet]
        [Route("Category/{id:guid}")]
        public async Task<CategoryViewModel> GetById(Guid id)
        {
            var response = Task.Run(() => _mapper.Map<CategoryViewModel>(_categoryRepository.GetById(id)));
            return await response;
        }


        [HttpPost]
        [Route("Category")]
        public async Task<IActionResult> Post([FromBody]CategoryViewModel categoryViewModel)
        {
            if (!ModelStateValida())
            {
                return await Response();
            }

            var categoryCommand = _mapper.Map<RegisterCategoryCommand>(categoryViewModel);
            await _mediator.SendCommand(categoryCommand);
            return await Response();
        }

        [HttpPut]
        [Route("Category")]
        public async Task<IActionResult> Put([FromBody]CategoryViewModel categoryViewModel)
        {
            if (!ModelStateValida())
            {
                return await Response();
            }

            var categoryCommand = _mapper.Map<UpdateCategoryCommand>(categoryViewModel);
            await _mediator.SendCommand(categoryCommand);
            return await Response(categoryCommand);
        }

        [HttpDelete]
        [Route("Category/{id:guid}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var categoryViewModel = new CategoryViewModel { Id = id };
            var categoryCommand = _mapper.Map<RemoveCategoryCommand>(categoryViewModel);
            await _mediator.SendCommand(categoryCommand);
            return await Response(categoryCommand);
        }

        private bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;
            ReportErroModelInvalid();
            return false;
        }
    }
}
