using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoPET.Models;

namespace ProjetoPET.Controllers
{
    public class TelaDeAdocaoController : Controller
    {
        private readonly ProjetoPETContext _context;

        public TelaDeAdocaoController(ProjetoPETContext context)
        {
            _context = context;
        }

        // GET: TelaDeAdocao
        public async Task<IActionResult> Index()
        {
            return View(await _context.TelaDeAdocao.ToListAsync());
        }

        // GET: TelaDeAdocao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telaDeAdocao = await _context.TelaDeAdocao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telaDeAdocao == null)
            {
                return NotFound();
            }

            return View(telaDeAdocao);
        }

        // GET: TelaDeAdocao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TelaDeAdocao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Raca,Descricao,Foto,Telefone,Endereco,Preco")] TelaDeAdocao telaDeAdocao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telaDeAdocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(telaDeAdocao);
        }

        // GET: TelaDeAdocao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telaDeAdocao = await _context.TelaDeAdocao.FindAsync(id);
            if (telaDeAdocao == null)
            {
                return NotFound();
            }
            return View(telaDeAdocao);
        }

        // POST: TelaDeAdocao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Raca,Descricao,Foto,Telefone,Endereco,Preco")] TelaDeAdocao telaDeAdocao)
        {
            if (id != telaDeAdocao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telaDeAdocao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelaDeAdocaoExists(telaDeAdocao.Id))
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
            return View(telaDeAdocao);
        }

        // GET: TelaDeAdocao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telaDeAdocao = await _context.TelaDeAdocao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telaDeAdocao == null)
            {
                return NotFound();
            }

            return View(telaDeAdocao);
        }

        // POST: TelaDeAdocao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telaDeAdocao = await _context.TelaDeAdocao.FindAsync(id);
            _context.TelaDeAdocao.Remove(telaDeAdocao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelaDeAdocaoExists(int id)
        {
            return _context.TelaDeAdocao.Any(e => e.Id == id);
        }
    }
}
