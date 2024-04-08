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
    public class ArtistaController : ControllerBase
    {
        private ArtistaService _artistaService;
        
        public ArtistaController(ArtistaService artistaService)
        {
           _artistaService = artistaService;
        }

        [HttpGet]
        public IActionResult GetArtistas()
        {
            var result = this._artistaService.Obter();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetArtistas(Guid id) {
            var result = this._artistaService.Obter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] ArtistaDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._artistaService.Criar(dto);

            return Created($"/Artista/{result.Id}", result);
        }

        [HttpPost("{id}/albums")]
        public IActionResult AssociarAlbum(AlbumDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._artistaService.AssociarAlbum(dto);

            return Created($"/Artista/{result.ArtistaId}/albums/{result.Id}", result);

        }

        [HttpGet("{idArtista}/albums/{id}")]
        public IActionResult ObterAlbumPorId(Guid idArtista, Guid id)
        {
            var result = this._artistaService.ObterAlbumPorId(idArtista, id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{idBanda}/albums")]
        public IActionResult ObterAlbuns(Guid idBanda)
        {
            var result = this._artistaService.ObterAlbum(idBanda);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        //[HttpGet("{idArtista}/albums/user")]
        //public IActionResult ObterAlbunsParaUsuario([FromBody]ObterAlbumRequest obterAlbumRequest)
        //{
        //    var result = this._artistaService.ObterAlbum(obterAlbumRequest.UsuarioId, obterAlbumRequest.ArtistaId);

        //    if (result == null)
        //        return NotFound();

        //    return Ok(result);
        //}

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
