using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Streaming.Aggregates;

namespace SoundVillage.Domain.Conta
{
    public class Playlist: BaseEntity
    {
        public string Nome {  get; set; }
        public virtual List<Musica> Musicas { get; set; }
        public virtual ContaStreaming Conta { get; set; }
    }
}
