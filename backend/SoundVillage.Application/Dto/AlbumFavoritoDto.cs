using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SoundVillage.Application.Dto.AlbumDto;

namespace SoundVillage.Application.Dto
{
    public class AlbumFavoritoDto
    {
        public Guid Id { get; set; }

        [Required]
        public Guid ArtistaId { get; set; }

        [Required]
        public string Nome { get; set; }
        public List<MusicFavoritaDto> Musicas { get; set; } = new List<MusicFavoritaDto>();

        public class MusicFavoritaDto: MusicDto
        {
            public bool Favorita { get; set; }
        }
    }
}
