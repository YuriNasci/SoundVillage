using SoundVillage.Admin.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SoundVillage.Admin.ViewsModels.Musica
{
    public class CriarViewModel
    {
        [Required]
        public String Nome { get; set; }
        [Required]
        [Duration]
        public string Duracao { get; set; }
        [Required]
        public Guid ArtistaId { get; set; }
        public Guid? AlbumId { get; set; }
    }
}
