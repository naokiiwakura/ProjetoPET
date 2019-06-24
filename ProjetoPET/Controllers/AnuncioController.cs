using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoPET.Areas.Identity.Data;
using ProjetoPET.Models;
using ProjetoPET.ViewModel;

namespace ProjetoPET.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly BancoContext _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly IHostingEnvironment hostingEnvironment;

        public AnuncioController(BancoContext context, UserManager<Usuario> userManager, IHostingEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            hostingEnvironment = environment;
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
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.PetId = new SelectList(_context.Set<Pet>(), "Id", "Nome");
            ViewBag.EstadoId = new SelectList(_context.Set<Estado>(), "Id", "Nome");
            ViewBag.TipoAnuncioId = new SelectList(_context.Set<TipoAnuncio>(), "Id", "Descricao");
            ViewBag.CidadeId = new SelectList(_context.Set<Cidade>().Where(p => p.Estado.Nome == "Acre"), "Id", "Nome");
            
            return View();
        }

        public IActionResult GetCidades(int id)
        {
            return Json(_context.Cidade.Where(p => p.Estado.Id == id).ToList());
        }

        
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }


        // POST: Anuncio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnuncioViewModel anuncio)
        {
            //TODO - tratar a gravação da imagem na pasta correta e armazenar apenas o caminho da foto no banco de dados.
            var img = anuncio.Foto;

            var uniqueFileName = GetUniqueFileName(img.FileName);
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, uniqueFileName);
            img.CopyTo(new FileStream(filePath, FileMode.Create));

            if (ModelState.IsValid)
            {
                var anuncioInsert = new Anuncio
                {
                    CreatedDate = DateTime.Now,
                    Titulo = anuncio.Titulo,
                    CorpoAnuncio = anuncio.CorpoAnuncio,
                    Foto = img.FileName,
                    Anunciante = await _userManager.GetUserAsync(HttpContext.User),
                    TipoAnuncioId = anuncio.TipoAnuncioId,
                    PetId = anuncio.PetId,
                    Endereco = new Endereco
                    {
                        Bairro = anuncio.Bairro,
                        Cep = anuncio.Cep,
                        Numero = anuncio.Numero,
                        Rua = anuncio.Rua
                    }
            };

                _context.Add(anuncioInsert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.PetId = new SelectList(_context.Set<Pet>(), "Id", "Nome");
            ViewBag.EstadoId = new SelectList(_context.Set<Estado>(), "Id", "Nome");
            ViewBag.TipoAnuncioId = new SelectList(_context.Set<TipoAnuncio>(), "Id", "Descricao");
            ViewBag.CidadeId = new SelectList(_context.Set<Cidade>().Where(p => p.Estado.Id == anuncio.EstadoId), "Id", "Nome");

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
            ViewBag.PetId = new SelectList(_context.Set<Pet>(), "Id", "Nome");
            ViewBag.EstadoId = new SelectList(_context.Set<Estado>(), "Id", "Nome");
            ViewBag.TipoAnuncioId = new SelectList(_context.Set<TipoAnuncio>(), "Id", "Descricao");
            ViewBag.CidadeId = new SelectList(_context.Set<Cidade>(), "Id", "Nome");
            
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
