using AutoMapper;
using SoundVillage.Admin.ViewsModels.Musica;
using SoundVillage.Application.Admin.Dto;
using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Domain.Streaming.ValueObject;

namespace SoundVillage.Admin.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapear CriarViewModel para Musica
            CreateMap<CriarViewModel, Musica>()
                .ForMember(dest => dest.Duracao, opt => opt.MapFrom(src => new Duracao(src.Duracao)));
        }
    }
}
