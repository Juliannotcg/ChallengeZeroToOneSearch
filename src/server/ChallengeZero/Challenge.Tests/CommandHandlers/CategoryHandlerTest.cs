using AutoMapper;
using Challenge.Api.Controllers;
using Challenge.Api.ViewModel;
using Challenge.Domain.Commands.CategoryCommands;
using Challenge.Domain.Core.Notifications;
using Challenge.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Challenge.Tests.CommandHandlers
{
    [TestClass]
    public class CategoryHandlerTest
    {
        public CategoryController categoryController { get; set; }
        public CategoryViewModel categoryViewModel { get; set; }
        public RegisterCategoryCommand registerCategoryCommand { get; set; }
        public Mock<IMapper> mockMapper { get; set; }
        public Mock<IMediatorHandler> mockMediator { get; set; }
        public Mock<DomainNotificationHandler> mockNotification { get; set; }

        public CategoryHandlerTest()
        {
            mockMapper = new Mock<IMapper>();
            mockMediator = new Mock<IMediatorHandler>();
            mockNotification = new Mock<DomainNotificationHandler>();

            var mockRepository = new Mock<ICategoryRepository>();

            categoryViewModel = new CategoryViewModel();

            registerCategoryCommand = new RegisterCategoryCommand(Guid.NewGuid(), "Teste");

            categoryController = new CategoryController(
                mockNotification.Object,
                mockRepository.Object,
                mockMapper.Object,
                mockMediator.Object);
        }

        [TestMethod]
        public async void EventosController_RegistrarEvento_RetornarComSucessoAsync()
        {
            //// Arrange
            //mockMapper.Setup(m => m.Map<RegisterCategoryCommand>(categoryViewModel)).Returns(registerCategoryCommand);

            //// Act
            //var result = await categoryController.Post(categoryViewModel);

            //// Assert
            //mockMediator.Verify(m => m.SendCommand(registerCategoryCommand), Times.Once);

            //Assert.IsTrue(result);
        }
    }
}