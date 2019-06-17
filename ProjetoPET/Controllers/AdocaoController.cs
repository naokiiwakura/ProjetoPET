using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoPET.Models;
using ProjetoPET.ViewModel;

namespace ProjetoPET.Controllers
{
    public class AdocaoController : Controller
    {
        private readonly BancoContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public AdocaoController(BancoContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Adocao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Set<Adocao>().ToListAsync());
        }

        // GET: Adocao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adocao = await _context.Set<Adocao>()
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

            return View();
        }

        // POST: Adocao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdocaoViewModel model)
        {
            if (ModelState.IsValid)
            {

                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images/AdocaoPhotos");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Adocao newAdocao = new Adocao
                {
                    Nome = model.Nome,
                    Raca = model.Raca,
                    Descricao = model.Descricao,
                    Endereco = model.Endereco,
                    Numero = model.Numero,
                    Bairo= model.Bairo,
                    Telefone = model.Telefone,
                    Photo = uniqueFileName
                   

                };
                _context.Add(newAdocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Adocao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adocao = await _context.Set<Adocao>().FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Raca,Descricao,Endereco,Numero,Bairo,Telefone,Photo,UsuarioId,Id,CreatedDate,UpdatedData")] Adocao adocao)
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
            return View(adocao);
        }

        // GET: Adocao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adocao = await _context.Set<Adocao>()
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
            var adocao = await _context.Set<Adocao>().FindAsync(id);
            _context.Set<Adocao>().Remove(adocao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdocaoExists(int id)
        {
            return _context.Set<Adocao>().Any(e => e.Id == id);
        }
    }
}
