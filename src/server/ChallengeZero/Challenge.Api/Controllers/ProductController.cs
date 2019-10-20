using AutoMapper;
using Challenge.Api.ViewModel;
using Challenge.Domain.Commands.ProductCommands;
using Challenge.Domain.Core.Notifications;
using Challenge.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Api.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public ProductController(INotificationHandler<DomainNotification> notifications,
                                 IProductRepository productRepository,
                                 IMapper mapper,
                                 IMediatorHandler mediator) : base(notifications, mediator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpGet]
        [Route("products")]
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var response = Task.Run(() => 
            _mapper.Map<IEnumerable<ProductViewModel>>(_productRepository.GetAllProductsCategories()));
            return await response;
        }

        [HttpGet]
        [Route("product/{id:guid}")]
        public async Task<ProductViewModel> GetById(Guid id)
        {
            var response = Task.Run(() => _mapper.Map<ProductViewModel>(_productRepository.GetById(id)));
            return await response;
        }

        [HttpPost]
        [Route("product")]
        public async Task<IActionResult> Post([FromBody]AddOrUpdateProductViewModel productViewModel)
        {
            if (!ModelStateValida())
            {
                return await Response();
            }

            var productCommand = _mapper.Map<RegisterProductCommand>(productViewModel);
            await _mediator.SendCommand(productCommand);
            return await Response(productCommand);
        }

        [HttpPut]
        [Route("product")]
        public async Task<IActionResult> Put([FromBody]AddOrUpdateProductViewModel productViewModel)
        {
            if (!ModelStateValida())
            {
                return await Response();
            }

            var productCommand = _mapper.Map<UpdateProductCommand>(productViewModel);

            await _mediator.SendCommand(productCommand);
            return await Response(productCommand);
        }

        [HttpDelete]
        [Route("product/{id:guid}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var productViewModel = new ProductViewModel { Id = id };
            var productCommand = _mapper.Map<RemoveProductCommand>(productViewModel);
            await _mediator.SendCommand(productCommand);
            return await Response(productCommand);
        }

        private bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;
            ReportErroModelInvalid();
            return false;
        }
    }
}
