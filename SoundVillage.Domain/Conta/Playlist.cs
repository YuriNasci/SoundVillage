using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Streaming.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Conta
{
    public class Playlist: BaseEntity
    {
        public string Nome {  get; set; }
        public List<Musica> Musicas { get; set; }
        public ContaStreaming Conta { get; internal set; }
    }
}
