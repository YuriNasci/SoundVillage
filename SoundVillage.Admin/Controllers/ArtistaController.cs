﻿using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoundVillage.Application.Admin.Dto;
using SoundVillage.Application.Dto;
using SoundVillage.Application.Interface;
using SoundVillage.Application.Streaming;

namespace SoundVillage.Admin.Controllers
{
    [Authorize]
    public class ArtistaController : Controller
    {
        private IArtistaService artistaService;

        public ArtistaController(IArtistaService artistaService)
        {
            this.artistaService = artistaService;
        }

        // GET: ArtistaController
        public ActionResult Index()
        {
            var result = artistaService.ObterTodos();
            return View(result);
        }

        // GET: ArtistaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArtistaController/Criar
        public ActionResult Criar()
        {
            return View();
        }

        // POST: ArtistaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(ArtistaDto artistaFormDto)
        {
            if (ModelState.IsValid == false)
            {
                return View("Criar");
            }

            this.artistaService.Salvar(artistaFormDto);

            return RedirectToAction("Index");
        }

        public ActionResult Editar(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artista = artistaService.Obter(id.Value);
            if (artista == null)
            {
                return NotFound();
            }
            return View(artista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Guid id, ArtistaDto artista)
        {
            if (id != artista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                artistaService.Salvar(artista);
                return RedirectToAction(nameof(Index));
            }
            return View(artista);
        }

        public ActionResult Excluir(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artista = artistaService.Obter(id.Value);
            if (artista == null)
            {
                return NotFound();
            }

            return View(artista);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarExclusao(Guid id)
        {
            artistaService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
