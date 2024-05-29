using SoundVillage.Domain.Conta.Agreggates;
using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Streaming.Aggregates;

namespace SoundVillage.Domain.Conta
{
    public class Playlist: BaseEntity
    {
        public string Nome {  get; set; }
        public virtual List<Musica> Musicas { get; set; }
        //public virtual ContaStreaming Conta { get; set; }
        public virtual Usuario Usuario { get; internal set; }
    }
}
