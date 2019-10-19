using AutoMapper;
using Challenge.Api.ViewModel;
using Challenge.Domain.Commands.ProductCommands;
using Challenge.Domain.Core.Notifications;
using Challenge.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public IEnumerable<ProductViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(_productRepository.GetAll());
        }

        [HttpGet]
        [Route("product/{id:guid}")]
        public ProductViewModel GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.GetById(id));
        }

        [HttpPost]
        [Route("product")]
        public IActionResult Post([FromBody]ProductViewModel productViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var productCommand = _mapper.Map<RegisterProductCommand>(productViewModel);
            _mediator.SendCommand(productCommand);
            return Response(productCommand);
        }

        [HttpPut]
        [Route("product")]
        public IActionResult Put([FromBody]ProductViewModel productViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var productCommand = _mapper.Map<UpdateProductCommand>(productViewModel);

            _mediator.SendCommand(productCommand);
            return Response(productCommand);
        }

        [HttpDelete]
        [Route("product/{id:guid}")]
        public IActionResult Remove(Guid id)
        {
            var productViewModel = new CategoryViewModel { Id = id };
            var productCommand = _mapper.Map<RemoveProductCommand>(productViewModel);
            _mediator.SendCommand(productCommand);
            return Response(productCommand);
        }

        private bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;
            ReportErroModelInvalid();
            return false;
        }
    }
}
