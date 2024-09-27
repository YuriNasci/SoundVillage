using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoundVillage.Application.Conta;
using SoundVillage.Application.Conta.Dto;

namespace SoundVillage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UserController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Criar(UsuarioFormDto usuarioForm)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._usuarioService.Criar(usuarioForm);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult Obter(Guid id)
        {
            var result = this._usuarioService.Obter(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("login")] 
        public IActionResult Login(Request.LoginRequest login)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var result = this._usuarioService.Autenticar(login.Email, login.Senha);

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
