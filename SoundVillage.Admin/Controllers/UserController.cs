using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoundVillage.Application.Admin;
using SoundVillage.Application.Admin.Dto;

namespace SoundVillage.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUsuarioAdminService usuarioAdminService;

        public UserController(IUsuarioAdminService usuarioAdminService)
        {
            this.usuarioAdminService = usuarioAdminService;
        }

        public IActionResult Index()
        {
            var result = this.usuarioAdminService.ObterTodos();

            return View(result);
        }

        [AllowAnonymous]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Salvar(UsuarioAdminDto dto)
        {
            if (ModelState.IsValid == false)
            {
                return View("Criar");
            }

            this.usuarioAdminService.Salvar(dto);

            return RedirectToAction("Index");
        }
    }
}
