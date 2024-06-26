using System.ComponentModel.DataAnnotations;

namespace SoundVillage.Application.Dto
{
    public class ArtistaDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo Descrição é obrigatório")]
        public String Descricao { get; set; }

        public String? Backdrop { get; set; }
    }
}
