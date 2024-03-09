using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SoundVillage.Application.Conta.Request;
using SoundVillage.Domain.Conta;

namespace SoundVillage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaStreamingController : ControllerBase
    {
        [HttpPost]
        public IActionResult Criar(ContaStreamingDto dto){
            if (ModelState is { IsValid: false })
                return BadRequest();

            return Ok();
        }
    }
}
