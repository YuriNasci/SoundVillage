using AutoMapper;
using SoundVillage.Application.Dto;
using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Repository.Repository;
using static SoundVillage.Application.Dto.AlbumDto;

namespace SoundVillage.Application.Streaming
{
    public class ArtistaService
    {
        private ArtistaRepository ArtistaRepository { get; set; }
        private IMapper Mapper { get; set; }

        public ArtistaService(ArtistaRepository artistaRepository, IMapper mapper)
        {
            ArtistaRepository = artistaRepository;
            Mapper = mapper;
        }

        public ArtistaDto Criar(ArtistaDto dto)
        {
            Artista artista = this.Mapper.Map<Artista>(dto);
            this.ArtistaRepository.Save(artista);
        
            return this.Mapper.Map<ArtistaDto>(artista);
        }

        public ArtistaDto Obter(Guid id)
        {
            var artista = this.ArtistaRepository.GetById(id);
            return this.Mapper.Map<ArtistaDto>(artista);
        }

        public IEnumerable<ArtistaDto> Obter()
        {
            var Artista = this.ArtistaRepository.GetAll();
            return this.Mapper.Map<IEnumerable<ArtistaDto>>(Artista);
        }

        public AlbumDto AssociarAlbum(AlbumDto dto)
        {
            var Artista = this.ArtistaRepository.GetById(dto.ArtistaId);

            if (Artista == null)
            {
                throw new Exception("Artista não encontrada");
            }

            var novoAlbum = this.AlbumDtoParaAlbum(dto);

            Artista.AdicionarAlbum(novoAlbum);

            this.ArtistaRepository.Update(Artista);

            var result = this.AlbumParaAlbumDto(novoAlbum);

            return result;

        }

        public AlbumDto ObterAlbum(Guid idArtista, Guid id)
        {
            var Artista = this.ArtistaRepository.GetById(idArtista);

            if (Artista == null)
            {
                throw new Exception("Artista não encontrada");
            }

            var album = Artista.Albums.FirstOrDefault(x => x.Id == id);

            var result = AlbumParaAlbumDto(album);
            result.ArtistaId = Artista.Id;

            return result;

        }

        private Album AlbumDtoParaAlbum(AlbumDto dto)
        {
            Album album = new Album()
            {
                Id = dto.Id,
                Nome = dto.Nome
            };

            foreach (MusicDto item in dto.Musicas)
            {
                album.AdicionarMusica(new Musica
                {
                    Nome = item.Nome,
                    Duracao = new SoundVillage.Domain.Streaming.ValueObject.Duracao(item.Duracao)
                });
            }

            return album;
        }

        private AlbumDto AlbumParaAlbumDto(Album album)
        {
            AlbumDto dto = new AlbumDto();
            dto.Id = album.Id;
            dto.Nome = album.Nome;

            foreach (var item in album.Musica)
            {
                var musicaDto = new MusicDto()
                {
                    Id = item.Id,
                    Duracao = item.Duracao,
                    Nome = item.Nome
                };

                dto.Musicas.Add(musicaDto);
            }

            return dto;
        }
    }
}
