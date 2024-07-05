using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoundVillage.Admin.ViewModels.Musica;
using SoundVillage.Admin.ViewsModels.UsuarioAdmin;
using SoundVillage.Application.Admin;
using SoundVillage.Application.Admin.Dto;
using SoundVillage.Application.Interface;
using SoundVillage.Application.Streaming;
using SoundVillage.Domain.Admin.Aggregates;
using SoundVillage.Domain.Streaming.Aggregates;

namespace SoundVillage.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUsuarioAdminService usuarioAdminService;
        private readonly IMapper mapper;
        public UserController(IUsuarioAdminService usuarioAdminService, IMapper mapper)
        {
            this.usuarioAdminService = usuarioAdminService;
            this.mapper = mapper;
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

        public ActionResult Editar(Guid id)
        {
            var usuario = usuarioAdminService.Obter(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(mapper.Map<CadastroUsuarioViewModel>(usuario));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CadastroUsuarioViewModel usuarioViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = mapper.Map<UsuarioAdmin>(usuarioViewModel);

                    usuarioAdminService.Atualizar(usuario);
                    return RedirectToAction(nameof(Index));
                }

                return View(usuarioViewModel);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Excluir(Guid id)
        {
            var u = usuarioAdminService.Obter(id);
            if (u == null)
            {
                return NotFound();
            }

            return View(mapper.Map<CadastroUsuarioViewModel>(u));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarExclusao(Guid id)
        {
            usuarioAdminService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
