﻿using Microsoft.EntityFrameworkCore;
using SoundVillage.Domain.Conta.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public SoundVillageContext Context { get; set; }

        public UsuarioRepository(SoundVillageContext context) : base(context)
        {
            Context = context;
        }

        //public Usuario GetById(Guid id)
        //{
        //    return this.Context.Usuarios
        //               .Include(x => x.Assinaturas) //Caso não esteja usando lazy loading
        //               .Include(x => x.Playlists)
        //               .Include(x => x.Notificacoes)
        //               //.AsSplitQuery() //Quebra a consulta por cada tipo
        //               .FirstOrDefault(x => x.Id == id);
        //}


    }
}
