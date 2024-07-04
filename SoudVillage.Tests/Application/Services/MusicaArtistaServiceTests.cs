using AutoMapper;
using Moq;
using SoundVillage.Application.Admin.Dto;
using SoundVillage.Application.Dto;
using SoundVillage.Application.Streaming;
using SoundVillage.Domain.Conta;
using SoundVillage.Domain.Conta.Agreggates;
using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Domain.Streaming.Agreggates;
using SoundVillage.Domain.Streaming.ValueObject;
using SoundVillage.Repository.Interfaces;
using SoundVillage.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SoudVillage.Tests.Application.Services
{
    public class MusicaServiceTests
    {
        private readonly Mock<IMusicaRepository> _musicaRepositoryMock;
        private readonly Mock<IPlaylistRepository> _playlistRepositoryMock;
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly MusicaService _service;

        public MusicaServiceTests()
        {
            _musicaRepositoryMock = new Mock<IMusicaRepository>();
            _playlistRepositoryMock = new Mock<IPlaylistRepository>();
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new MusicaService(
                _musicaRepositoryMock.Object,
                _playlistRepositoryMock.Object,
                _usuarioRepositoryMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public void FavoritarMusica_ShouldAddOrRemoveMusicaFromFavoritas()
        {
            var usuarioId = Guid.NewGuid();
            var musicaId = Guid.NewGuid();
            var musica = new Musica { Id = musicaId, Nome = "Musica1" };
            var playlistFavoritas = new Playlist { Nome = "Favoritas", Musicas = new List<Musica>() };
            var usuario = new Usuario { Id = usuarioId, Playlists = new List<Playlist> { playlistFavoritas } };

            _usuarioRepositoryMock.Setup(repo => repo.GetById(usuarioId)).Returns(usuario);
            _musicaRepositoryMock.Setup(repo => repo.GetById(musicaId)).Returns(musica);

            _service.FavoritarMusica(musicaId, usuarioId);

            _playlistRepositoryMock.Verify(repo => repo.Update(It.IsAny<Playlist>()), Times.Once);
        }

        [Fact]
        public void ObterTodas_ShouldReturnAllMusicas()
        {
            var musicas = new List<Musica>
        {
            new Musica { Id = Guid.NewGuid(), Nome = "Musica1" },
            new Musica { Id = Guid.NewGuid(), Nome = "Musica2" }
        };
            var musicaDtos = new List<MusicaDto>
        {
            new MusicaDto { Id = musicas[0].Id, Nome = "Musica1" },
            new MusicaDto { Id = musicas[1].Id, Nome = "Musica2" }
        };

            _musicaRepositoryMock.Setup(repo => repo.GetAll()).Returns(musicas);
            _mapperMock.Setup(m => m.Map<IEnumerable<MusicaDto>>(musicas)).Returns(musicaDtos);

            var result = _service.ObterTodas();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            _musicaRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _mapperMock.Verify(m => m.Map<IEnumerable<MusicaDto>>(musicas), Times.Once);
        }

        [Fact]
        public void Obter_ShouldReturnMusicaDto()
        {
            var musicaId = Guid.NewGuid();
            var musica = new Musica { Id = musicaId, Nome = "Musica1" };
            var musicaDto = new MusicaDto { Id = musicaId, Nome = "Musica1" };

            _musicaRepositoryMock.Setup(repo => repo.GetById(musicaId)).Returns(musica);
            _mapperMock.Setup(m => m.Map<MusicaDto>(musica)).Returns(musicaDto);

            var result = _service.Obter(musicaId);

            Assert.NotNull(result);
            Assert.Equal(musicaId, result.Id);
            _musicaRepositoryMock.Verify(repo => repo.GetById(musicaId), Times.Once);
            _mapperMock.Verify(m => m.Map<MusicaDto>(musica), Times.Once);
        }

        [Fact]
        public void Atualizar_ShouldUpdateMusica()
        {
            var musicaDto = new MusicaDto
            {
                Id = Guid.NewGuid(),
                Nome = "Musica1",
                AlbumId = Guid.NewGuid(),
                ArtistaId = Guid.NewGuid(),
                Duracao = "03:00"
            };
            var musica = new Musica
            {
                Id = musicaDto.Id,
                Nome = "OldName",
                AlbumId = null,
                ArtistaId = Guid.NewGuid(),
                Duracao = new Duracao("02:00")
            };

            _musicaRepositoryMock.Setup(repo => repo.GetById(musicaDto.Id)).Returns(musica);

            _service.Atualizar(musicaDto);

            _musicaRepositoryMock.Verify(repo => repo.Update(musica), Times.Once);
            Assert.Equal(musicaDto.Nome, musica.Nome);
            Assert.Equal(musicaDto.AlbumId, musica.AlbumId);
            Assert.Equal(musicaDto.ArtistaId, musica.ArtistaId);
            Assert.Equal(musicaDto.Duracao, musica.Duracao.Formatado());
        }

        [Fact]
        public void Salvar_ShouldSaveMusica()
        {
            var musica = new Musica { Id = Guid.NewGuid(), Nome = "Musica1" };

            _service.Salvar(musica);

            _musicaRepositoryMock.Verify(repo => repo.Save(musica), Times.Once);
        }

        [Fact]
        public void Excluir_ShouldDeleteMusica()
        {
            var musicaId = Guid.NewGuid();
            var musica = new Musica { Id = musicaId, Nome = "Musica1" };

            _musicaRepositoryMock.Setup(repo => repo.GetById(musicaId)).Returns(musica);

            _service.Excluir(musicaId);

            _musicaRepositoryMock.Verify(repo => repo.Delete(musica), Times.Once);
        }

        [Fact]
        public void ObterMaisCurtidas_ShouldReturnTopFavoritedMusicas()
        {
            var musicas = new List<Musica>
        {
            new Musica { Id = Guid.NewGuid(), Nome = "Musica1", Favoritadas = new List<MusicaFavorita> { new MusicaFavorita(), new MusicaFavorita() } },
            new Musica { Id = Guid.NewGuid(), Nome = "Musica2", Favoritadas = new List<MusicaFavorita> { new MusicaFavorita() } }
        };

            _musicaRepositoryMock.Setup(repo => repo.GetAll()).Returns(musicas);

            var result = _service.ObterMaisCurtidas(1);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Musica1", result.First().Nome);
            _musicaRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
