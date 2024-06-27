using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundVillage.Application.Streaming;

namespace SoundVillage.Admin.Controllers
{
    public class MusicaController : Controller
    {
        private MusicaService musicaService { get; set; }
        public MusicaController(MusicaService musicaService)
        {
            this.musicaService = musicaService;
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MusicaController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
