using Microsoft.AspNetCore.Mvc;
using Moq;
using SoundVillage.Admin.Controllers;
using SoundVillage.Application.Admin;
using SoundVillage.Application.Admin.Dto;
using System.Collections.Generic;
using Xunit;

namespace SoundVillage.Tests.Admin.Controllers
{
    public class UserControllerTests
    {
        private readonly UserController controller;
        private readonly Mock<IUsuarioAdminService> mockUsuarioAdminService;

        public UserControllerTests()
        {
            mockUsuarioAdminService = new Mock<IUsuarioAdminService>();
            controller = new UserController(mockUsuarioAdminService.Object);
        }

        [Fact]
        public void Index_ReturnsViewWithModel()
        {
            // Arrange
            var usuarios = new List<UsuarioAdminDto>
            {
                new UsuarioAdminDto { Id = new Guid(), Nome = "Usuário 1" },
                new UsuarioAdminDto { Id = new Guid(), Nome = "Usuário 2" }
            };
            mockUsuarioAdminService.Setup(service => service.ObterTodos()).Returns(usuarios);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<UsuarioAdminDto>>(viewResult.Model);
            Assert.Equal(usuarios.Count, model.Count());
        }

        [Fact]
        public void Salvar_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var usuarioDto = new UsuarioAdminDto { Nome = "Novo Usuário", Email = "usuario@teste.com"};

            // Act
            var result = controller.Salvar(usuarioDto);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
