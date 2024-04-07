using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace SoundVillage.Api.Controllers.Request
{
    public class FavoritarMusicaRequest
    {
        [Required(ErrorMessage = "Campo IdMusica é obrigatório")]
        public string IdMusica { get; set; }
        [Required(ErrorMessage = "Campo IdUsuario é obrigatório")]
        public string IdUsuario { get; set; }
    }
}
