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
    public class UsuarioBusinessController : Controller
    {
        private readonly DbContext _context;

        public UsuarioBusinessController(DbContext context)
        {
            _context = context;
        }

        // GET: UsuarioBusiness
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsuarioBusiness.ToListAsync());
        }

        // GET: UsuarioBusiness/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioBusiness = await _context.UsuarioBusiness
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioBusiness == null)
            {
                return NotFound();
            }

            return View(usuarioBusiness);
        }

        // GET: UsuarioBusiness/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuarioBusiness/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Id,CreatedDate,UpdatedData")] UsuarioBusiness usuarioBusiness)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioBusiness);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioBusiness);
        }

        // GET: UsuarioBusiness/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioBusiness = await _context.UsuarioBusiness.FindAsync(id);
            if (usuarioBusiness == null)
            {
                return NotFound();
            }
            return View(usuarioBusiness);
        }

        // POST: UsuarioBusiness/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Id,CreatedDate,UpdatedData")] UsuarioBusiness usuarioBusiness)
        {
            if (id != usuarioBusiness.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioBusiness);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioBusinessExists(usuarioBusiness.Id))
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
            return View(usuarioBusiness);
        }

        // GET: UsuarioBusiness/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioBusiness = await _context.UsuarioBusiness
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioBusiness == null)
            {
                return NotFound();
            }

            return View(usuarioBusiness);
        }

        // POST: UsuarioBusiness/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioBusiness = await _context.UsuarioBusiness.FindAsync(id);
            _context.UsuarioBusiness.Remove(usuarioBusiness);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioBusinessExists(int id)
        {
            return _context.UsuarioBusiness.Any(e => e.Id == id);
        }
    }
}
