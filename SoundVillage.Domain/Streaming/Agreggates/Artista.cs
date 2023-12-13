using SoundVillage.Domain.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Streaming.Agreggates
{
    public class Artista: BaseEntity
    {
        public string Nome { get; set; }
        public List<Album> Discografia { get; set; }
    }
}
