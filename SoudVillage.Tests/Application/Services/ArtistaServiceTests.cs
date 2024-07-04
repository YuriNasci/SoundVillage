using AutoMapper;
using Moq;
using SoundVillage.Application.Dto;
using SoundVillage.Application.Streaming;
using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Repository.Interfaces;
using SoundVillage.Repository.Repository;
using System;
using System.Collections.Generic;
using Xunit;

namespace SoudVillage.Tests.Application.Services
{
    public class ArtistaServiceTests
    {
        private readonly Mock<IArtistaRepository> _artistaRepositoryMock;
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ArtistaService _service;

        public ArtistaServiceTests()
        {
            _artistaRepositoryMock = new Mock<IArtistaRepository>();
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new ArtistaService(_artistaRepositoryMock.Object, _mapperMock.Object, _usuarioRepositoryMock.Object);
        }

        [Fact]
        public void Criar_ShouldSaveArtistaAndReturnDto()
        {
            var artistaDto = new ArtistaDto { Id = Guid.NewGuid(), Nome = "Artista1" };
            var artista = new Artista { Id = artistaDto.Id, Nome = "Artista1" };

            _mapperMock.Setup(m => m.Map<Artista>(artistaDto)).Returns(artista);
            _mapperMock.Setup(m => m.Map<ArtistaDto>(artista)).Returns(artistaDto);

            var result = _service.Criar(artistaDto);

            Assert.NotNull(result);
            Assert.Equal(artistaDto.Id, result.Id);
            _artistaRepositoryMock.Verify(repo => repo.Save(artista), Times.Once);
            _mapperMock.Verify(m => m.Map<Artista>(artistaDto), Times.Once);
            _mapperMock.Verify(m => m.Map<ArtistaDto>(artista), Times.Once);
        }

        [Fact]
        public void Obter_ShouldReturnMappedArtistaDto()
        {
            var artistaId = Guid.NewGuid();
            var artista = new Artista { Id = artistaId, Nome = "Artista1" };
            var artistaDto = new ArtistaDto { Id = artistaId, Nome = "Artista1" };

            _artistaRepositoryMock.Setup(repo => repo.GetById(artistaId)).Returns(artista);
            _mapperMock.Setup(m => m.Map<ArtistaDto>(artista)).Returns(artistaDto);

            var result = _service.Obter(artistaId);

            Assert.NotNull(result);
            Assert.Equal(artistaId, result.Id);
            _artistaRepositoryMock.Verify(repo => repo.GetById(artistaId), Times.Once);
            _mapperMock.Verify(m => m.Map<ArtistaDto>(artista), Times.Once);
        }

        [Fact]
        public void ObterTodos_ShouldReturnMappedArtistaDtos()
        {
            var artistas = new List<Artista>
            {
                new Artista { Id = Guid.NewGuid(), Nome = "Artista1" },
                new Artista { Id = Guid.NewGuid(), Nome = "Artista2" }
            };

            var artistaDtos = new List<ArtistaDto>
            {
                new ArtistaDto { Id = artistas[0].Id, Nome = "Artista1" },
                new ArtistaDto { Id = artistas[1].Id, Nome = "Artista2" }
            };

            _artistaRepositoryMock.Setup(repo => repo.GetAll()).Returns(artistas);
            _mapperMock.Setup(m => m.Map<IEnumerable<ArtistaDto>>(artistas)).Returns(artistaDtos);

            var result = _service.Obter();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            _artistaRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _mapperMock.Verify(m => m.Map<IEnumerable<ArtistaDto>>(artistas), Times.Once);
        }

        [Fact]
        public void AssociarAlbum_ShouldAddAlbumToArtistaAndReturnAlbumDto()
        {
            var artistaId = Guid.NewGuid();
            var albumDto = new AlbumDto { Id = Guid.NewGuid(), Nome = "Album1", ArtistaId = artistaId };
            var artista = new Artista { Id = artistaId, Nome = "Artista1" };
            var album = new Album { Id = albumDto.Id, Nome = "Album1" };

            _artistaRepositoryMock.Setup(repo => repo.GetById(artistaId)).Returns(artista);
            _artistaRepositoryMock.Setup(repo => repo.Update(artista));
            _mapperMock.Setup(m => m.Map<Album>(albumDto)).Returns(album);
            _mapperMock.Setup(m => m.Map<AlbumDto>(album)).Returns(albumDto);

            var result = _service.AssociarAlbum(albumDto);

            Assert.NotNull(result);
            Assert.Equal(albumDto.Id, result.Id);
            _artistaRepositoryMock.Verify(repo => repo.GetById(artistaId), Times.Once);
            _artistaRepositoryMock.Verify(repo => repo.Update(artista), Times.Once);
            _mapperMock.Verify(m => m.Map<Album>(albumDto), Times.Once);
            _mapperMock.Verify(m => m.Map<AlbumDto>(album), Times.Once);
        }


    }
}
