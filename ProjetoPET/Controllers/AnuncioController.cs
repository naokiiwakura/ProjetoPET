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
    public class AnuncioController : Controller
    {
        private readonly BancoContext _context;

        public AnuncioController(BancoContext context)
        {
            _context = context;
        }

        // GET: Anuncio
        public async Task<IActionResult> Index()
        {
            var bancoContext = _context.Set<Anuncio>().Include(a => a.Pet);
            return View(await bancoContext.ToListAsync());
        }

        // GET: Anuncio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Set<Anuncio>()
                .Include(a => a.Pet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        // GET: Anuncio/Create
        public IActionResult Create()
        {
            ViewData["PetId"] = new SelectList(_context.Set<Pet>(), "Id", "Id");
            return View();
        }

        // POST: Anuncio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Anuncio anuncio)
        {
            //TODO - tratar a gravação da imagem na pasta correta e armazenar apenas o caminho da foto no banco de dados.
            if (ModelState.IsValid)
            {
                _context.Add(anuncio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PetId"] = new SelectList(_context.Set<Pet>(), "Id", "Id", anuncio.PetId);
            return View(anuncio);
        }

        // GET: Anuncio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Set<Anuncio>().FindAsync(id);
            if (anuncio == null)
            {
                return NotFound();
            }
            ViewData["PetId"] = new SelectList(_context.Set<Pet>(), "Id", "Id", anuncio.PetId);
            return View(anuncio);
        }

        // POST: Anuncio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Titulo,CorpoAnuncio,Foto,PetId,Id,CreatedDate,UpdatedData")] Anuncio anuncio)
        {
            if (id != anuncio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anuncio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnuncioExists(anuncio.Id))
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
            ViewData["PetId"] = new SelectList(_context.Set<Pet>(), "Id", "Id", anuncio.PetId);
            return View(anuncio);
        }

        // GET: Anuncio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Set<Anuncio>()
                .Include(a => a.Pet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        // POST: Anuncio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anuncio = await _context.Set<Anuncio>().FindAsync(id);
            _context.Set<Anuncio>().Remove(anuncio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnuncioExists(int id)
        {
            return _context.Set<Anuncio>().Any(e => e.Id == id);
        }
    }
}
