using SoundVillage.Domain.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Streaming.Agreggates
{
    public class Album: BaseEntity
    {
        public string Nome { get; set; }
        public uint Ano { get; set; }
        public List<Musica> Musica { get; set; } = new List<Musica>();

        public void AdicionarMusica(Musica musica) =>
            this.Musica.Add(musica);
        public void AdicionarMusica(List<Musica> musica) =>
            this.Musica.AddRange(musica);

    }
}
