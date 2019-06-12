using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoPET.Models;
using ProjetoPET.repository;

namespace ProjetoPET.Controllers
{
    public class EventoController : Controller
    {
        private readonly IGenericRepository<Eventos> _repo;
        public EventoController(IGenericRepository<Eventos> repo)
        {
            _repo = repo;
        }

        // GET: Evento
        public async Task<IActionResult> Index()
        {
            return View(await _repo.ListarTodos());
        }

        // GET: Evento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventos = await _repo.BuscarPorId((int)id);
            if (eventos == null)
            {
                return NotFound();
            }

            return View(eventos);
        }

        // GET: Evento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Descricao,Id,CreatedDate,Local,UpdatedData")] Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                eventos.CreatedDate = DateTime.Now;
                await _repo.Inserir(eventos);
                return RedirectToAction(nameof(Index));
            }
            return View(eventos);
        }

        // GET: Evento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventos = await _repo.BuscarPorId((int)id);
            if (eventos == null)
            {
                return NotFound();
            }
            return View(eventos);
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Descricao,Id,CreatedDate,Local,UpdatedData")] Eventos eventos)
        {
            if (id != eventos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var eventoDb = _repo.Editar(id, eventos);
                }
                catch (Exception)
                {
                    if (!await EventosExists(eventos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(eventos);
        }

        // GET: Evento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventos = await _repo.BuscarPorId((int)id);
            if (eventos == null)
            {
                return NotFound();
            }

            return View(eventos);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _repo.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task <bool> EventosExists(int id)
        {
            return await _repo.Existe(id);
        }
    }
}
