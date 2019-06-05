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
    public class AdocaoController : Controller
    {
        private readonly DbContext _context;

        public AdocaoController(DbContext context)
        {
            _context = context;
        }

        // GET: Adocao
        public async Task<IActionResult> Index()
        {
            var dbContext = _context.Adocao.Include(a => a.Pet);
            return View(await dbContext.ToListAsync());
        }

        // GET: Adocao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adocao = await _context.Adocao
                .Include(a => a.Pet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adocao == null)
            {
                return NotFound();
            }

            return View(adocao);
        }

        // GET: Adocao/Create
        public IActionResult Create()
        {
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Id");
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
                _context.Add(adocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Id", adocao.PetId);
            return View(adocao);
        }

        // GET: Adocao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adocao = await _context.Adocao.FindAsync(id);
            if (adocao == null)
            {
                return NotFound();
            }
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Id", adocao.PetId);
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
                    _context.Update(adocao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdocaoExists(adocao.Id))
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
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Id", adocao.PetId);
            return View(adocao);
        }

        // GET: Adocao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adocao = await _context.Adocao
                .Include(a => a.Pet)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var adocao = await _context.Adocao.FindAsync(id);
            _context.Adocao.Remove(adocao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdocaoExists(int id)
        {
            return _context.Adocao.Any(e => e.Id == id);
        }
    }
}
