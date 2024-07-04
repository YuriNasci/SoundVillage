using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SoundVillage.Admin.Controllers;
using SoundVillage.Admin.ViewModels.Musica;
using SoundVillage.Admin.ViewsModels.Musica;
using SoundVillage.Application.Admin.Dto;
using SoundVillage.Application.Dto;
using SoundVillage.Application.Interface;
using SoundVillage.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using Xunit;

namespace SoundVillage.Tests.Admin.Controllers
{
    public class MusicaControllerTests
    {
        private readonly Mock<IMusicaService> mockMusicaService;
        private readonly Mock<IArtistaService> mockArtistaService;
        private readonly Mock<IAlbumService> mockAlbumService;
        private readonly Mock<IMapper> mockMapper;
        private readonly MusicaController controller;

        public MusicaControllerTests()
        {
            mockMusicaService = new Mock<IMusicaService>();
            mockArtistaService = new Mock<IArtistaService>();
            mockAlbumService = new Mock<IAlbumService>();
            mockMapper = new Mock<IMapper>();
            controller = new MusicaController(
                mockMusicaService.Object,
                mockArtistaService.Object,
                mockAlbumService.Object,
                mockMapper.Object
            );
        }

        [Fact]
        public void Index_ReturnsViewWithMusicaList()
        {
            // Arrange
            var musicas = new List<MusicaDto> { new MusicaDto { Id = Guid.NewGuid(), Nome = "Musica 1" } };
            mockMusicaService.Setup(service => service.ObterTodas()).Returns(musicas);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<MusicaDto>>(viewResult.Model);
            Assert.Equal(musicas, model);
        }

        [Fact]
        public void Criar_GET_ReturnsViewWithArtistasAndAlbuns()
        {
            // Arrange
            var artistas = new List<ArtistaItemDto> { new ArtistaItemDto { Id = Guid.NewGuid(), Nome = "Artista 1" } };
            var albuns = new List<Album> { new Album { Id = Guid.NewGuid(), Nome = "Album 1" } };
            mockArtistaService.Setup(service => service.ObterTodos()).Returns(artistas);
            mockAlbumService.Setup(service => service.ObterTodos()).Returns(albuns);

            // Act
            var result = controller.Criar();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<CadastroMusicaViewModel>(viewResult.Model);
            Assert.NotNull(viewModel);
            Assert.Equal(artistas, viewResult.ViewData["Artistas"]);
            Assert.Equal(albuns, viewResult.ViewData["Albuns"]);
        }

        [Fact]
        public void Criar_POST_WithValidModel_RedirectsToIndex()
        {
            // Arrange
            var musicaViewModel = new CadastroMusicaViewModel { Nome = "Musica Teste" };
            var musicaDto = new MusicaDto { Id = Guid.NewGuid(), Nome = "Musica Teste" };
            mockMapper.Setup(mapper => mapper.Map<Musica>(musicaViewModel)).Returns(new Musica());
            mockMapper.Setup(mapper => mapper.Map<MusicaDto>(It.IsAny<Musica>())).Returns(musicaDto);

            // Act
            var result = controller.Criar(musicaViewModel);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockMusicaService.Verify(service => service.Salvar(It.IsAny<Musica>()), Times.Once);
        }

        [Fact]
        public void Editar_GET_ReturnsViewWithMusicaAndArtistasAndAlbuns()
        {
            // Arrange
            var id = Guid.NewGuid();
            var musicaDto = new MusicaDto { Id = id, Nome = "Musica Teste" };
            mockMusicaService.Setup(service => service.Obter(id)).Returns(musicaDto);
            var artistas = new List<ArtistaItemDto> { new ArtistaItemDto { Id = Guid.NewGuid(), Nome = "Artista 1" } };
            var albuns = new List<Album> { new Album { Id = Guid.NewGuid(), Nome = "Album 1" } };
            mockArtistaService.Setup(service => service.ObterTodos()).Returns(artistas);
            mockAlbumService.Setup(service => service.ObterTodos()).Returns(albuns);

            // Act
            var result = controller.Editar(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<MusicaDto>(viewResult.Model);
            Assert.Equal(musicaDto, viewModel);
            Assert.Equal(artistas, viewResult.ViewData["Artistas"]);
            Assert.Equal(albuns, viewResult.ViewData["Albuns"]);
        }

        [Fact]
        public void ConfirmarExclusao_POST_RedirectsToIndex()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var result = controller.ConfirmarExclusao(id);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockMusicaService.Verify(service => service.Excluir(id), Times.Once);
        }
    }
}
