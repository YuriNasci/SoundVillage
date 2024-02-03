using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundVillage.Domain.Streaming.Agreggates;
using SoundVillage.Repository;

namespace SoundVillage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        private SoundVillageContext Context { get; set; }
        
        public ArtistaController(SoundVillageContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetArtistas()
        {
            var result = this.Context.Artistas.ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetArtistas(Guid id) {
            var result = this.Context.Artistas.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult SaveArtistas([FromBody] Artista artista) { 
            this.Context.Artistas.Add(artista);
            this.Context.SaveChanges();

            return Created($"/artista//{artista.Id}", artista);
        }

    }
}
