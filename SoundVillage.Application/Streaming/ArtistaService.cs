using AutoMapper;
using SoundVillage.Application.Admin.Dto;
using SoundVillage.Application.Dto;
using SoundVillage.Application.Interface;
using SoundVillage.Application.Streaming.Storage;
using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Repository.Interfaces;
using SoundVillage.Repository.Migrations;
using SoundVillage.Repository.Repository;
using System.Diagnostics.Eventing.Reader;
using static SoundVillage.Application.Dto.AlbumDto;
using Album = SoundVillage.Domain.Streaming.Aggregates.Album;
using Artista = SoundVillage.Domain.Streaming.Aggregates.Artista;

namespace SoundVillage.Application.Streaming
{
    public class ArtistaService
    {
        private ArtistaRepository ArtistaRepository { get; set; }
        private IUsuarioRepository UsuarioRepository { get; set; }
        private IMapper Mapper { get; set; }
        private AzureStorageAccount AzureStorageAccount { get; set; }

        public ArtistaService(ArtistaRepository artistaRepository, IMapper mapper, IUsuarioRepository usuarioRepository, AzureStorageAccount azureStorageAccount)
        {
            ArtistaRepository = artistaRepository;
            Mapper = mapper;
            UsuarioRepository = usuarioRepository;
            AzureStorageAccount = azureStorageAccount;
        }

        public async Task<ArtistaDto> Criar(ArtistaDto dto)
        {
            Domain.Streaming.Aggregates.Artista artista = this.Mapper.Map<Domain.Streaming.Aggregates.Artista>(dto);
            var urlBackdrop = await this.AzureStorageAccount.UploadImage(dto.Backdrop);
            artista.Backdrop = urlBackdrop;

            await this.ArtistaRepository.SaveOrUpate(artista, artista.ArtistaKey);
            return this.Mapper.Map<ArtistaDto>(artista);
        }

        public async Task<ArtistaDto> Obter(Guid id)
        {
            var artista = await this.ArtistaRepository.ReadItem<Artista>(id.ToString());
            return this.Mapper.Map<ArtistaDto>(artista);
        }

        public async Task<IEnumerable<ArtistaDto>> Obter()
        {
            var Artista = await this.ArtistaRepository.ReadAllItem<Artista>();
            return this.Mapper.Map<IEnumerable<ArtistaDto>>(Artista);
        }

        public async Task<AlbumDto> AssociarAlbum(AlbumDto dto)
        {
            var Artista = await this.ArtistaRepository.ReadItem<Artista>(dto.ArtistaId.ToString());

            if (Artista == null)
            {
                throw new Exception("Artista não encontrada");
            }

            var novoAlbum = this.Mapper.Map<Album>(dto);

            Artista.AdicionarAlbum(novoAlbum);

            await this.ArtistaRepository.SaveOrUpate<Artista>(Artista, Artista.ArtistaKey);

            var result = this.Mapper.Map<AlbumDto>(novoAlbum);

            return result;

        }

        public async Task<AlbumDto> ObterAlbumPorId(Guid idArtista, Guid id)
        {
            var Artista = await this.ArtistaRepository.ReadItem<Artista>(idArtista.ToString());

            if (Artista == null)
            {
                throw new Exception("Artista não encontrada");
            }

            var album = Artista.Albums.FirstOrDefault(x => x.Id == id);

            if (album == null) return null;

            var result = this.Mapper.Map<AlbumDto>(album);
            result.ArtistaId = Artista.Id;

            return result;

        }

        public async Task<List<AlbumDto>> ObterAlbum(Guid idBanda)
        {
            var banda = await this.ArtistaRepository.ReadItem<Artista>(idBanda.ToString());

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

        public async Task<List<AlbumFavoritoDto>> ObterAlbum(string usuarioId, string artistaId)
        {
            Artista banda = await ArtistaRepository.ReadItem<Artista>(artistaId.ToString());

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

        public async Task<IEnumerable<ArtistaItemDto>> ObterTodos()
        {
            var result = await this.ArtistaRepository.ReadAllItem<Artista>();

            return Mapper.Map<IEnumerable<ArtistaItemDto>>(result);
        }

        public void Salvar(ArtistaDto artistaFormDto)
        {
            var artista = this.Mapper.Map<Domain.Streaming.Aggregates.Artista>(artistaFormDto);
            Task.WaitAll(this.ArtistaRepository.SaveOrUpate<Artista>(artista, artista.ArtistaKey));
        }

        public void Excluir(Guid id)
        {
            Task.WaitAll(this.ArtistaRepository.Delete<Artista>(id.ToString(), new Artista().ArtistaKey));
        }
    }
}
