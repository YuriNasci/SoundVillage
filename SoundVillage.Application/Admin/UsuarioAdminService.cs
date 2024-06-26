﻿using AutoMapper;
using SoundVillage.Application.Admin.Dto;
using SoundVillage.Domain.Admin.Aggregates;
using SoundVillage.Domain.Core.Extension;
using SoundVillage.Repository.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Application.Admin
{
    public class UsuarioAdminService
    {
        private UsuarioAdminRepository Repository { get; set; }
        private IMapper mapper { get; set; }
        public UsuarioAdminService(UsuarioAdminRepository repository, IMapper mapper)
        {
            Repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<UsuarioAdminDto> ObterTodos()
        {
            var result = this.Repository.GetAll();

            return this.mapper.Map<IEnumerable<UsuarioAdminDto>>(result);
        }

        public void Salvar(UsuarioAdminDto dto)
        {
            var usuario = this.mapper.Map<UsuarioAdmin>(dto);
            usuario.CriptografaSenha();
            this.Repository.Save(usuario);
        }

        public UsuarioAdmin Authenticate(string email, string password)
        {
            var passwordCipher = password.HashSHA256();
            var user = this.Repository.GetUsuarioAdminByEmailAndPassword(email, passwordCipher);
            return user;
        }
    }
}
