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
    public class TeladeLojasController : Controller
    {
        private readonly ProjetoPETContext _context;

        public TeladeLojasController(ProjetoPETContext context)
        {
            _context = context;
        }

        // GET: TeladeLojas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeladeLojas.ToListAsync());
        }

        // GET: TeladeLojas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teladeLojas = await _context.TeladeLojas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teladeLojas == null)
            {
                return NotFound();
            }

            return View(teladeLojas);
        }

        // GET: TeladeLojas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeladeLojas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Endereco,CNPj")] TeladeLojas teladeLojas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teladeLojas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teladeLojas);
        }

        // GET: TeladeLojas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teladeLojas = await _context.TeladeLojas.FindAsync(id);
            if (teladeLojas == null)
            {
                return NotFound();
            }
            return View(teladeLojas);
        }

        // POST: TeladeLojas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Endereco,CNPj")] TeladeLojas teladeLojas)
        {
            if (id != teladeLojas.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teladeLojas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeladeLojasExists(teladeLojas.ID))
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
            return View(teladeLojas);
        }

        // GET: TeladeLojas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teladeLojas = await _context.TeladeLojas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teladeLojas == null)
            {
                return NotFound();
            }

            return View(teladeLojas);
        }

        // POST: TeladeLojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teladeLojas = await _context.TeladeLojas.FindAsync(id);
            _context.TeladeLojas.Remove(teladeLojas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeladeLojasExists(int id)
        {
            return _context.TeladeLojas.Any(e => e.ID == id);
        }
    }
}
