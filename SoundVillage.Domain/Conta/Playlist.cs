using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Streaming.Aggregates;

namespace SoundVillage.Domain.Conta
{
    public class Playlist: BaseEntity
    {
        public string Nome {  get; set; }
        public List<Musica> Musicas { get; set; }
        public ContaStreaming Conta { get; internal set; }
    }
}
