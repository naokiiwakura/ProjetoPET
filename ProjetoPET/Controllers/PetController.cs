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
    public class PetController : Controller
    {
        private readonly IGenericRepository<Pet> _repo;
        public PetController(IGenericRepository<Pet> repo)
        {
            _repo = repo;
        }

        // GET: Pet
        public async Task<IActionResult> Index()
        {
            return View(await _repo.ListarTodos());
        }

        // GET: Pet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _repo.BuscarPorId((int)id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Raca,Idade,Sexo,Telefone,Descricao,Id,CreatedDate,UpdatedData")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                pet.CreatedDate = DateTime.Now;
                await _repo.Inserir(pet);
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }

        // GET: Pet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _repo.BuscarPorId((int)id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        // POST: Pet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Raca,Idade,Sexo,Telefone,Descricao,Id,CreatedDate,UpdatedData")] Pet pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var Pet = _repo.Editar(id, pet);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await PetExists(pet.Id))
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
            return View(pet);
        }

        // GET: Pet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _repo.BuscarPorId((int)id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _repo.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task <bool> PetExists(int id)
        {
            return await _repo.Existe(id);
        }
    }
}
