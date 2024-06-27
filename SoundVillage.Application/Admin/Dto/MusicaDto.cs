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
        public string Artista { get; set; }
        public string Album { get; set; }
        public string Duracao { get; set; }
    }
}
