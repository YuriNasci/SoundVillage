using SoundVillage.Application.Admin.Dto;
using SoundVillage.Application.Dto;

namespace SoundVillage.Application.Interface
{
    public interface IArtistaService
    {
        AlbumDto AssociarAlbum(AlbumDto dto);
        ArtistaDto Criar(ArtistaDto dto);
        void Excluir(Guid id);
        IEnumerable<ArtistaDto> Obter();
        ArtistaDto Obter(Guid id);
        List<AlbumDto> ObterAlbum(Guid idBanda);
        List<AlbumFavoritoDto> ObterAlbum(string usuarioId, string artistaId);
        AlbumDto ObterAlbumPorId(Guid idArtista, Guid id);
        IEnumerable<ArtistaItemDto> ObterTodos();
        void Salvar(ArtistaDto artistaFormDto);
    }
}