using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundVillage.Application.Admin.Dto;
using SoundVillage.Application.Streaming;

namespace SoundVillage.Admin.Controllers
{
    public class MusicaController : Controller
    {
        private MusicaService musicaService { get; set; }
        private ArtistaService artistaService { get; set; }
        private AlbumService albumService { get; set; }
        public MusicaController(MusicaService musicaService, ArtistaService artistaService, AlbumService albumService)
        {
            this.musicaService = musicaService;
            this.artistaService = artistaService;
            this.albumService = albumService;
        }
        // GET: MusicaController1
        public ActionResult Index()
        {
            var musicas = musicaService.ObterTodas();

            return View(musicas);
        }

        // GET: MusicaController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MusicaController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusicaController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusicaController1/Edit/5
        public ActionResult Editar(Guid id)
        {
            var musica = musicaService.Obter(id);
            if (musica == null)
            {
                return NotFound();
            }
            ViewBag.Artistas = artistaService.ObterTodos();
            ViewBag.Albuns = albumService.ObterTodos();
            return View(musica);
        }

        // POST: MusicaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(MusicaDto musica)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    musicaService.Atualizar(musica);
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Artistas = artistaService.ObterTodos();
                ViewBag.Albuns = albumService.ObterTodos();
                return View(musica);
            }
            catch
            {
                return View();
            }
        }

        // GET: MusicaController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MusicaController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
