using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundVillage.Api.Controllers.Request;
using SoundVillage.Application.Dto;
using SoundVillage.Application.Streaming;
using SoundVillage.Domain.Streaming.Agreggates;
using SoundVillage.Repository;

namespace SoundVillage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "soundvillage-user")]
    public class ArtistaController : ControllerBase
    {
        private ArtistaService _artistaService;
        
        public ArtistaController(ArtistaService artistaService)
        {
           _artistaService = artistaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtistas()
        {
            var result = await this._artistaService.Obter();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistas(Guid id) {
            var result = await this._artistaService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ArtistaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = await this._artistaService.Criar(dto);

            return Created($"/Artista/{result.Id}", result);
        }

        [HttpPost("{id}/albums")]
        public async Task<IActionResult> AssociarAlbum(AlbumDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = await this._artistaService.AssociarAlbum(dto);

            return Created($"/Artista/{result.ArtistaId}/albums/{result.Id}", result);

        }

        [HttpGet("{idArtista}/albums/{id}")]
        public async Task<IActionResult> ObterAlbumPorId(Guid idArtista, Guid id)
        {
            var result = await this._artistaService.ObterAlbumPorId(idArtista, id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{idBanda}/albums")]
        public async Task<IActionResult> ObterAlbuns(Guid idBanda)
        {
            var result = await this._artistaService.ObterAlbum(idBanda);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpGet("{idArtista}/albums/user/{idUsuario}")]
        public IActionResult ObterAlbunsParaUsuario(string idArtista, string idUsuario)
        {
            var result = this._artistaService.ObterAlbum(idUsuario, idArtista);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
