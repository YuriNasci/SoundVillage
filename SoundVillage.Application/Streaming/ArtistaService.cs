using AutoMapper;
using SoundVillage.Application.Admin.Dto;
using SoundVillage.Application.Dto;
using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Repository.Migrations;
using SoundVillage.Repository.Repository;
using System.Diagnostics.Eventing.Reader;
using static SoundVillage.Application.Dto.AlbumDto;

namespace SoundVillage.Application.Streaming
{
    public class ArtistaService
    {
        private ArtistaRepository ArtistaRepository { get; set; }
        private UsuarioRepository UsuarioRepository { get; set; }
        private IMapper Mapper { get; set; }

        public ArtistaService(ArtistaRepository artistaRepository, IMapper mapper, UsuarioRepository usuarioRepository)
        {
            ArtistaRepository = artistaRepository;
            Mapper = mapper;
            UsuarioRepository = usuarioRepository;
        }

        public ArtistaDto Criar(ArtistaDto dto)
        {
            Domain.Streaming.Aggregates.Artista artista = this.Mapper.Map<Domain.Streaming.Aggregates.Artista>(dto);
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

        public AlbumDto ObterAlbumPorId(Guid idArtista, Guid id)
        {
            var Artista = this.ArtistaRepository.GetById(idArtista);

            if (Artista == null)
            {
                throw new Exception("Artista não encontrada");
            }

            var album = Artista.Albums.FirstOrDefault(x => x.Id == id);

            if (album == null) return null;

            var result = AlbumParaAlbumDto(album);
            result.ArtistaId = Artista.Id;

            return result;

        }

        public List<AlbumDto> ObterAlbum(Guid idBanda)
        {
            var banda = this.ArtistaRepository.GetById(idBanda);

            if (banda == null)
            {
                throw new Exception("Banda não encontrada");
            }

            var result = new List<AlbumDto>();

            foreach (var item in banda.Albums)
            {
                result.Add(AlbumParaAlbumDto(item));
            }

            return result;

        }

        private Domain.Streaming.Aggregates.Album AlbumDtoParaAlbum(AlbumDto dto)
        {
            Domain.Streaming.Aggregates.Album album = new Domain.Streaming.Aggregates.Album()
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

        private AlbumDto AlbumParaAlbumDto(Domain.Streaming.Aggregates.Album album)
        {
            AlbumDto dto = new AlbumDto();
            dto.Id = album.Id;
            dto.Nome = album.Nome;

            foreach (var item in album.Musicas)
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

        public List<AlbumFavoritoDto> ObterAlbum(string usuarioId, string artistaId)
        {
            var banda = this.ArtistaRepository.GetById(Guid.Parse(artistaId));

            if (banda == null)
            {
                throw new Exception("Banda não encontrada");
            }

            var result = new List<AlbumFavoritoDto>();

            foreach (var item in banda.Albums)
            {
                result.Add(AlbumParaAlbumDto(item, usuarioId));
            }

            return result;
        }

        private AlbumFavoritoDto AlbumParaAlbumDto(Domain.Streaming.Aggregates.Album album, string usuarioId)
        {
            var dto = new AlbumFavoritoDto();
            dto.Id = album.Id;
            dto.Nome = album.Nome;

            var musicasfavoritas = this.UsuarioRepository.GetById(Guid.Parse(usuarioId)).GetFavoritas().Musicas;
            var musicasFavoritasDoAlbum = album.Musicas.Intersect(musicasfavoritas);

            foreach (var item in album.Musicas)
            {
                var musicaDto = new AlbumFavoritoDto.MusicFavoritaDto()
                {
                    Id = item.Id,
                    Duracao = item.Duracao,
                    Nome = item.Nome,
                    Favorita = musicasFavoritasDoAlbum.Any(m => m.Id == item.Id),
                };

                dto.Musicas.Add(musicaDto);
            }

            return dto;
        }

        public IEnumerable<ArtistaItemDto> ObterTodos()
        {
            var result = ArtistaRepository.GetAll();

            return Mapper.Map<IEnumerable<ArtistaItemDto>>(result);
        }

        public void Salvar(ArtistaDto artistaFormDto)
        {
            var artista = this.Mapper.Map<Domain.Streaming.Aggregates.Artista>(artistaFormDto);
            if (artistaFormDto.Id == Guid.Empty) {
                this.ArtistaRepository.Save(artista);
            } else {
                this.ArtistaRepository.Update(artista);
            }
        }

        public void Excluir(Guid id)
        {
            var artista = this.ArtistaRepository.GetById(id);
            this.ArtistaRepository.Delete(artista);
        }
    }
}
