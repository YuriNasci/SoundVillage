using AutoMapper;
using SoundVillage.Admin.ViewModels.Musica;
using SoundVillage.Admin.ViewsModels.Musica;
using SoundVillage.Admin.ViewsModels.UsuarioAdmin;
using SoundVillage.Application.Admin.Dto;
using SoundVillage.Domain.Admin.Aggregates;
using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Domain.Streaming.ValueObject;

namespace SoundVillage.Admin.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapear CriarViewModel para Musica
            CreateMap<CadastroMusicaViewModel, Musica>()
                .ForMember(dest => dest.Duracao, opt => opt.MapFrom(src => new Duracao(src.Duracao)));

            CreateMap<Musica, MusicaMaisCurtidasViewModel>()
                .ForMember(dest => dest.ArtistaNome, opt => opt.MapFrom(src => src.Artista.Nome))
                .ForMember(dest => dest.AlbumNome, opt => opt.MapFrom(src => src.Album != null ? src.Album.Nome: "Single"))
                .ForMember(dest => dest.Curtidas, opt => opt.MapFrom(src => src.Favoritadas.Count))
                ;

            CreateMap<CadastroUsuarioViewModel, UsuarioAdmin>()
                .ForMember(x => x.Perfil, m => m.MapFrom(f => (Perfil)f.Perfil))
                .ReverseMap();
        }
    }
}
