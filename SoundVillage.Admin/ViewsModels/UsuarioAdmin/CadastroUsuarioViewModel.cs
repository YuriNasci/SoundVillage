using System.ComponentModel.DataAnnotations;

namespace SoundVillage.Admin.ViewsModels.UsuarioAdmin
{
    public class CadastroUsuarioViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Campo Email não está em um formato correto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Password é obrigatório")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Campo Perfil é obrigatório")]
        public int? Perfil { get; set; }
    }
}
