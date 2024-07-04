using Microsoft.AspNetCore.Mvc;
using Moq;
using SoundVillage.Application.Dto;
using SoundVillage.Application.Streaming;
using SoundVillage.Admin.Controllers;
using System;
using System.Collections.Generic;
using Xunit;
using SoundVillage.Application.Admin.Dto;
using SoundVillage.Application.Interface;

namespace SoundVillage.Tests.Admin.Controllers
{
    public class ArtistaControllerTests
    {
        private readonly Mock<IArtistaService> mockArtistaService;
        private readonly ArtistaController controller;

        public ArtistaControllerTests()
        {
            mockArtistaService = new Mock<IArtistaService>(MockBehavior.Strict);
            controller = new ArtistaController(mockArtistaService.Object);
        }

        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var expectedArtistas = new List<ArtistaItemDto>();
            mockArtistaService.Setup(service => service.ObterTodos()).Returns(expectedArtistas);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ArtistaItemDto>>(viewResult.ViewData.Model);
            Assert.Equal(expectedArtistas, model);
        }

        [Fact]
        public void Criar_WithoutModelStateValid_ReturnsViewResult()
        {
            // Arrange
            controller.ModelState.AddModelError("Error", "Simulating model error");
            var artistaFormDto = new ArtistaDto();

            // Act
            var result = controller.Salvar(artistaFormDto);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Criar", viewResult.ViewName);
        }

        [Fact]
        public void Criar_WithValidModelState_CallsSalvarAndRedirectsToIndex()
        {
            // Arrange
            var artistaFormDto = new ArtistaDto { Id = Guid.NewGuid(), Nome = "Teste" };
            mockArtistaService.Setup(service => service.Salvar(artistaFormDto));
            // Act
            var result = controller.Salvar(artistaFormDto);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockArtistaService.Verify(service => service.Salvar(artistaFormDto), Times.Once);
        }

        [Fact]
        public void Editar_WithNullId_ReturnsNotFound()
        {
            // Arrange
            Guid? id = null;

            // Act
            var result = controller.Editar(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Editar_WithValidId_ReturnsViewResult()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var artistaDto = new ArtistaDto { Id = id, Nome = "Teste" };
            mockArtistaService.Setup(service => service.Obter(id)).Returns(artistaDto);

            // Act
            var result = controller.Editar(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ArtistaDto>(viewResult.ViewData.Model);
            Assert.Equal(artistaDto, model);
        }

        [Fact]
        public void Editar_Post_WithMismatchedIds_ReturnsNotFound()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var artistaDto = new ArtistaDto { Id = Guid.NewGuid(), Nome = "Teste" };

            // Act
            var result = controller.Editar(id, artistaDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Editar_Post_WithValidModel_CallsSalvarAndRedirectsToIndex()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var artistaDto = new ArtistaDto { Id = id, Nome = "Teste" };
            mockArtistaService.Setup(service => service.Salvar(artistaDto));

            // Act
            var result = controller.Editar(id, artistaDto);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockArtistaService.Verify(service => service.Salvar(artistaDto), Times.Once);
        }

        [Fact]
        public void Excluir_WithNullId_ReturnsNotFound()
        {
            // Arrange
            Guid? id = null;

            // Act
            var result = controller.Excluir(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Excluir_WithValidId_ReturnsViewResult()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var artistaDto = new ArtistaDto { Id = id, Nome = "Teste" };
            mockArtistaService.Setup(service => service.Obter(id)).Returns(artistaDto);

            // Act
            var result = controller.Excluir(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ArtistaDto>(viewResult.ViewData.Model);
            Assert.Equal(artistaDto, model);
        }

        [Fact]
        public void ConfirmarExclusao_CallsExcluirAndRedirectsToIndex()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            mockArtistaService.Setup(service => service.Excluir(id));

            // Act
            var result = controller.ConfirmarExclusao(id);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockArtistaService.Verify(service => service.Excluir(id), Times.Once);
        }
    }
}
