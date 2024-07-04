using SoundVillage.Domain.Streaming.Aggregates;

namespace SoundVillage.Application.Interface
{
    public interface IAlbumService
    {
        IEnumerable<Album> ObterTodos();
    }
}