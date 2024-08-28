using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoundVillage.Api.Controllers.Request;
using SoundVillage.Application.Streaming;

namespace SoundVillage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "soundvillage-user")]
    public class MusicaController : Controller
    {
        private MusicaService _musicaService { get; set; }

        public MusicaController(MusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        [HttpPut]
        public IActionResult FavoritarMusica(FavoritarMusicaRequest request)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            this._musicaService.FavoritarMusica(
                Guid.Parse(request.IdMusica), Guid.Parse(request.IdUsuario));

            return NoContent();
        }
    }
}
