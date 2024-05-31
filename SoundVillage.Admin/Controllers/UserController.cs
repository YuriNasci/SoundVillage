using Microsoft.AspNetCore.Mvc;
using SoundVillage.Application.Admin;

namespace SoundVillage.Admin.Controllers
{
    public class UserController : Controller
    {
        private UsuarioAdminService usuarioAdminService;

        public UserController(UsuarioAdminService usuarioAdminService)
        {
            this.usuarioAdminService = usuarioAdminService;
        }

        public IActionResult Index()
        {
            var result = this.usuarioAdminService.ObterTodos();

            return View(result);
        }
    }
}
