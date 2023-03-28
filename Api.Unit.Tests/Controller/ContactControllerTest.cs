using Api.Controllers;
using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Api.Unit.Tests.Controller
{
    public class ContactControllerTest
    {
        [Fact]
        public void Get()
        {
            // Arrange
            var contacts = new List<ContactDto>{ new ContactDto { Id = 1, Name = "TestName", Email = "test@gmail.com", PhoneNumber = "123" } };
            var studentService = new Mock<IContactService>();
            service.Setup(s => s.GetAll()).ReturnsAsync(contacts);
            var controller = new ContactController(service.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var viewResult = Assert.IsType<IActionResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ContactDto>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
    }
}