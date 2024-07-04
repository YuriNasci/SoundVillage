using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SoundVillage.Admin.Controllers;
using SoundVillage.Admin.Models;
using SoundVillage.Application.Admin;
using SoundVillage.Domain.Admin.Aggregates;
using Xunit;

namespace SoundVillage.Tests.Admin.Controllers
{
    public class AccountControllerTests
    {
        private readonly AccountController controller;
        private readonly Mock<IUsuarioAdminService> mockUsuarioAdminService;

        public AccountControllerTests()
        {
            mockUsuarioAdminService = new Mock<IUsuarioAdminService>();
            controller = new AccountController(mockUsuarioAdminService.Object);
        }

        [Fact]
        public async Task Login_InvalidCredentials_ReturnsViewWithError()
        {
            // Arrange
            var loginRequest = new LoginRequest { Email = "invalid@test.com", Password = "wrongpassword" };
            mockUsuarioAdminService.Setup(service => service.Authenticate(loginRequest.Email, loginRequest.Password)).Returns((UsuarioAdmin)null);

            // Act
            var result = await controller.Login(loginRequest);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.False(viewResult.ViewData.ModelState.IsValid);
            Assert.Equal("Email ou senha incorreta", viewResult.ViewData.ModelState["login_failed"].Errors[0].ErrorMessage);
        }
    }
}
