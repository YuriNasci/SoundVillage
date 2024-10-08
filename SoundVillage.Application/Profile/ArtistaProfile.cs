﻿using SoundVillage.Application.Admin.Dto;
using SoundVillage.Application.Dto;
using SoundVillage.Domain.Streaming.Aggregates;

namespace SoundVillage.Application.Profile
{
    public class ArtistaProfile: AutoMapper.Profile
    {
        public ArtistaProfile()
        {
            CreateMap<ArtistaDto, Artista>()
                .ReverseMap();

            CreateMap<AlbumDto, Album>()
                .ReverseMap();

            CreateMap<AlbumDto.MusicDto, Musica>().ReverseMap();
        }
    }
}
