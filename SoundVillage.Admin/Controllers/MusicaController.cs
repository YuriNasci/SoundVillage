using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundVillage.Admin.ViewModels.Musica;
using SoundVillage.Admin.ViewsModels.Musica;
using SoundVillage.Application.Admin.Dto;
using SoundVillage.Application.Interface;
using SoundVillage.Application.Streaming;
using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Domain.Streaming.ValueObject;

namespace SoundVillage.Admin.Controllers
{
    public class MusicaController : Controller
    {
        private IMusicaService musicaService { get; set; }
        private IArtistaService artistaService { get; set; }
        private IAlbumService albumService { get; set; }
        private readonly IMapper mapper;
        public MusicaController(IMusicaService musicaService, IArtistaService artistaService, IAlbumService albumService, IMapper mapper)
        {
            this.musicaService = musicaService;
            this.artistaService = artistaService;
            this.albumService = albumService;
            this.mapper = mapper;
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

        public ActionResult Criar()
        {
            ViewBag.Artistas = artistaService.ObterTodos();
            ViewBag.Albuns = albumService.ObterTodos();

            return View(new CadastroMusicaViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(CadastroMusicaViewModel musicaViewModel)
        {
                if (ModelState.IsValid)
                {
                    var musica = mapper.Map<Musica>(musicaViewModel);
                    musicaService.Salvar(musica);
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Artistas = artistaService.ObterTodos();
                ViewBag.Albuns = albumService.ObterTodos();
                return View(musicaViewModel);
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

        public ActionResult Excluir(Guid id)
        {
            var musica = musicaService.Obter(id);
            if (musica == null)
            {
                return NotFound();
            }

            return View(musica);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarExclusao(Guid id)
        {
            musicaService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult MaisCurtidas()
        {
            var musicas = musicaService.ObterMaisCurtidas();
            var musicaViewModels = mapper.Map<IEnumerable<MusicaMaisCurtidasViewModel>>(musicas);
            return View(musicaViewModels);
        }
    }
}
