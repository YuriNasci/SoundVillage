using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Streaming.Aggregates
{
    public class Artista
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("nome")]
        public String Nome { get; set; }
        [JsonProperty("descricao")]
        public String Descricao { get; set; }
        [JsonProperty("backdrop")]
        public String Backdrop { get; set; }
        [JsonProperty("albuns")]
        public virtual IList<Album> Albums { get; set; } = new List<Album>();
        [JsonProperty("artistaKey")]
        public String ArtistaKey = "artista-partition";

        public void AdicionarAlbum(Album album) =>
            this.Albums.Add(album);
    }
}
