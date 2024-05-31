using Microsoft.AspNetCore.Mvc;
using SoundVillage.Application.Streaming;
using SoundVillage.Repository;

namespace SoundVillage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoController : Controller
    {
        private PlanoService _planoService;
        public PlanoController(PlanoService planoService) {
            _planoService = planoService;
        }

        [HttpGet]
        public IActionResult GetPlanos()
        {
            var result = this._planoService.GetPlanos();

            return Ok(result);
        }
    }
}
