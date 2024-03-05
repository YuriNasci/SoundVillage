using SoundVillage.Application.Dto;
using SoundVillage.Domain.Streaming.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Application.Profile
{
    public class ArtistaProfile: AutoMapper.Profile
    {
        public ArtistaProfile()
        {
            CreateMap<ArtistaDto, Artista>()
                .ReverseMap();
        }
    }
}
