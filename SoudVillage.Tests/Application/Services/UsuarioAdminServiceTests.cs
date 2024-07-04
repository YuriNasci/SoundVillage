using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using SoundVillage.Application.Admin;
using SoundVillage.Application.Admin.Dto;
using SoundVillage.Domain.Admin.Aggregates;
using SoundVillage.Repository.Interfaces;
using System.Collections.Generic;
using Xunit;
using SoundVillage.Domain.Core.Extension;

namespace SoudVillage.Tests.Application.Services
{
    public class UsuarioAdminServiceTests
    {
        private readonly Mock<IUsuarioAdminRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UsuarioAdminService _service;

        public UsuarioAdminServiceTests()
        {
            _repositoryMock = new Mock<IUsuarioAdminRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new UsuarioAdminService(_repositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void ObterTodos_ShouldReturnMappedUsuarios()
        {
            // Arrange
            var usuarios = new List<UsuarioAdmin>
            {
                new UsuarioAdmin { Id = Guid.NewGuid(), Nome = "User1" },
                new UsuarioAdmin { Id = Guid.NewGuid(), Nome = "User2" }
            };

            var usuarioDtos = new List<UsuarioAdminDto>
            {
                new UsuarioAdminDto { Id = usuarios[0].Id, Nome = "User1" },
                new UsuarioAdminDto { Id = usuarios[1].Id, Nome = "User2" }
            };

            _repositoryMock.Setup(repo => repo.GetAll()).Returns(usuarios);
            _mapperMock.Setup(m => m.Map<IEnumerable<UsuarioAdminDto>>(It.IsAny<IEnumerable<UsuarioAdmin>>())).Returns(usuarioDtos);

            // Act
            var result = _service.ObterTodos();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            _repositoryMock.Verify(repo => repo.GetAll(), Times.Once);
            _mapperMock.Verify(m => m.Map<IEnumerable<UsuarioAdminDto>>(usuarios), Times.Once);
        }

        [Fact]
        public void Salvar_ShouldSaveUsuarioWithEncryptedPassword()
        {
            var usuarioDto = new UsuarioAdminDto { Id = Guid.NewGuid(), Nome = "User1", Password = "password" };
            var usuario = new UsuarioAdmin { Id = usuarioDto.Id, Nome = "User1", Password = "password" };

            _mapperMock.Setup(m => m.Map<UsuarioAdmin>(usuarioDto)).Returns(usuario);
            _repositoryMock.Setup(repo => repo.Save(It.IsAny<UsuarioAdmin>()));

            _service.Salvar(usuarioDto);

            _mapperMock.Verify(m => m.Map<UsuarioAdmin>(usuarioDto), Times.Once);
            _repositoryMock.Verify(repo => repo.Save(It.Is<UsuarioAdmin>(u => u.Password != "password")), Times.Once);
        }

        [Fact]
        public void Authenticate_ShouldReturnUserWhenCredentialsAreValid()
        {
            var email = "user@example.com";
            var password = "password";
            var hashedPassword = password.HashSHA256();
            var usuario = new UsuarioAdmin { Id = Guid.NewGuid(), Nome = "User1", Email = email, Password = hashedPassword };

            _repositoryMock.Setup(repo => repo.GetUsuarioAdminByEmailAndPassword(email, hashedPassword)).Returns(usuario);

            var result = _service.Authenticate(email, password);

            Assert.NotNull(result);
            Assert.Equal(usuario.Id, result.Id);
            _repositoryMock.Verify(repo => repo.GetUsuarioAdminByEmailAndPassword(email, hashedPassword), Times.Once);
        }

        [Fact]
        public void Authenticate_ShouldReturnNullWhenCredentialsAreInvalid()
        {
            var email = "user@example.com";
            var password = "wrongpassword";
            var hashedPassword = password.HashSHA256();

            _repositoryMock.Setup(repo => repo.GetUsuarioAdminByEmailAndPassword(email, hashedPassword)).Returns((UsuarioAdmin)null);

            var result = _service.Authenticate(email, password);

            Assert.Null(result);
            _repositoryMock.Verify(repo => repo.GetUsuarioAdminByEmailAndPassword(email, hashedPassword), Times.Once);
        }
    }
}
