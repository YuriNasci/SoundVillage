using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Streaming.Aggregates
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public virtual IList<Musica> Musicas { get; set; } = new List<Musica>();

        public void AdicionarMusica(Musica musica) => 
            this.Musicas.Add(musica);
     
        //public void AdicionarMusica(List<Musica> musica) =>
        //    this.Musica.AddRange(musica);


    
    }
}
