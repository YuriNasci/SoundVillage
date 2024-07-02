using SoundVillage.Domain.Streaming.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Application.Admin.Dto
{
    public class MusicaDto
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public string NomeArtista { get; set; }
        public string NomeAlbum { get; set; }
        public Guid? AlbumId { get; set; }
        public string Duracao { get; set; }
    }
}
