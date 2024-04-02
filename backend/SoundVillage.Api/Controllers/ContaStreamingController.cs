using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using SoundVillage.Application.Conta;
using SoundVillage.Application.Conta.Request;

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
        public IActionResult Criar(ContaStreamingDto dto)
        {
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

        [HttpPost("login")]
        public IActionResult Login([FromBody] Request.LoginRequest login)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var result = this._contaStreamingService.Autenticar(login.Email, login.Senha);

            if (result == null)
            {
                return BadRequest(new
                {
                    Error = "email ou senha inválidos"
                });
            }

            return Ok(result);

        }
    }
}
