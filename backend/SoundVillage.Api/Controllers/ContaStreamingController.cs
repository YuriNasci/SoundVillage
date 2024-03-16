using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SoundVillage.Application.Conta;
using SoundVillage.Application.Conta.Request;
using SoundVillage.Domain.Conta;

namespace SoundVillage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaStreamingController : ControllerBase
    {
        private ContaStreamingService _contaStreamingService;

        public ContaStreamingController(ContaStreamingService contaStreamingService)
        {
            _contaStreamingService = contaStreamingService;
        }

        [HttpPost]
        public IActionResult Criar(ContaStreamingDto dto){
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._contaStreamingService.Criar(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Obter(Guid id)
        {
            var result = this._contaStreamingService.Obter(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
