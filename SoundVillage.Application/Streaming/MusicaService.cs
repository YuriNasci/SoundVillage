﻿using AutoMapper;
using SoundVillage.Application.Admin.Dto;
using SoundVillage.Application.Dto;
using SoundVillage.Domain.Conta;
using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Domain.Streaming.ValueObject;
using SoundVillage.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Application.Streaming
{
    public class MusicaService
    {
        private MusicaRepository MusicaRepository { get; set; }
        private PlaylistRepository PlaylistRepository { get; set; }
        private UsuarioRepository UsuarioRepository { get; set; }
        private IMapper Mapper { get; set; }

        public MusicaService(MusicaRepository musicaRepository, PlaylistRepository playlistRepository, UsuarioRepository usuarioRepository
, IMapper mapper)
        {
            this.MusicaRepository = musicaRepository;
            this.PlaylistRepository = playlistRepository;
            this.UsuarioRepository = usuarioRepository;
            Mapper = mapper;
        }

        public void FavoritarMusica(Guid IdMusica, Guid IdUsuario)
        {
            var usuario = UsuarioRepository.GetById(IdUsuario);
            var playlistFavoritas = usuario.Playlists.FirstOrDefault
                (p => p.Nome == "Favoritas");

            if (playlistFavoritas != null)
            {
                Playlist playlistFavoritasAtualizada = playlistFavoritas;
                var musica = MusicaRepository.GetById(IdMusica);

                if (!playlistFavoritasAtualizada.Musicas.Contains(musica))
                    playlistFavoritasAtualizada.Musicas.Add(musica);
                else
                    playlistFavoritasAtualizada.Musicas.Remove(musica);

                this.PlaylistRepository.Update(playlistFavoritasAtualizada);
            }
        }

        public IEnumerable<MusicaDto> ObterTodas()
        {
            var musicas = this.MusicaRepository.GetAll();
            return this.Mapper.Map<IEnumerable<MusicaDto>>(musicas);
        }

        public MusicaDto Obter(Guid id)
        {
            var musica = this.MusicaRepository.GetById(id);
            return this.Mapper.Map<MusicaDto>(musica);
        }

        public void Atualizar(MusicaDto musicaDto)
        {
            var musica = this.MusicaRepository.GetById(musicaDto.Id);

            musica.AlbumId = musicaDto.AlbumId;
            musica.Nome = musicaDto.Nome;
            musica.ArtistaId = musicaDto.ArtistaId;

            //TO DO: DURAÇÃO

            this.MusicaRepository.Update(musica);
        }
    }
}
