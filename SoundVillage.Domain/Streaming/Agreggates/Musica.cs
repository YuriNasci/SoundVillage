using SoundVillage.Domain.Conta;
using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Streaming.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Streaming.Agreggates
{
    public class Musica: BaseEntity
    {
        public String Nome { get; set; }
        public Duracao Duracao { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
}
