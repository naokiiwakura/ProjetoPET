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
    public class AdocaoController : Controller
    {
        private readonly IGenericRepository<Adocao> _repo;
        public AdocaoController(IGenericRepository<Adocao> repo)
        {
            _repo = repo;
        }

        // GET: Adocao
        public async Task<IActionResult> Index()
        {
            return View(await _repo.ListarTodos());
        }

        // GET: Adocao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adocao = await _repo.BuscarPorId((int)id);
            if (adocao == null)
            {
                return NotFound();
            }

            return View(adocao);
        }

        // GET: Adocao/Create
        public IActionResult Create()
        {
        
            return View();
        }

        // POST: Adocao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Contato,PetId,UsuarioId,Id,CreatedDate,UpdatedData")] Adocao adocao)
        {
            if (ModelState.IsValid)
            {

                adocao.CreatedDate = DateTime.Now;
                await _repo.Inserir(adocao);
                return RedirectToAction(nameof(Index));
            }
           
            return View(adocao);
        }

        // GET: Adocao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adocao = await _repo.BuscarPorId((int)id);
            if (adocao == null)
            {
                return NotFound();
            }
            
            return View(adocao);
        }

        // POST: Adocao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Contato,PetId,UsuarioId,Id,CreatedDate,UpdatedData")] Adocao adocao)
        {
            if (id != adocao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var adocaoDb = _repo.Editar(id, adocao);
                   
                }
                catch (Exception)
                {
                    if (! await AdocaoExists(adocao.Id))
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
         
            return View(adocao);
        }

        // GET: Adocao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adocao = await _repo.BuscarPorId((int)id);
                
            if (adocao == null)
            {
                return NotFound();
            }

            return View(adocao);
        }

        // POST: Adocao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _repo.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task <bool> AdocaoExists(int id)
        {
            return await _repo.Existe(id);
        }
    }
}
