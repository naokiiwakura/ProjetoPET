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

        public AnuncioController(BancoContext context, UserManager<Usuario> userManager, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Anuncio
        public async Task<IActionResult> Index()
        {
            var bancoContext = _context.Set<Anuncio>().Include(a => a.Pet);

            var listaAnuncio = await bancoContext.Select(p => new AnuncioViewModel
            {
                CaminhoDaFoto = "images/LojasPhotos/" + p.Foto,
                Titulo = p.Titulo,
                CorpoAnuncio = p.CorpoAnuncio,
                NomeDoPet = p.Pet.Descricao,
                Id = p.Id
            }).ToListAsync();

            return View(listaAnuncio);
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
            if (ModelState.IsValid)
            {

                string uniqueFileName = null;

                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images/LojasPhotos");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + anuncio.Foto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                anuncio.Foto.CopyTo(new FileStream(filePath, FileMode.Create));

                var newAnuncios = new Anuncio
                {
                    CreatedDate = DateTime.Now,
                    Titulo = anuncio.Titulo,
                    CorpoAnuncio = anuncio.CorpoAnuncio,
                    Foto = uniqueFileName,
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
                _context.Add(newAnuncios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
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


            var anuncioViewModel = new AnuncioViewModel
            {
                Titulo = anuncio.Titulo,
                CorpoAnuncio = anuncio.CorpoAnuncio,
                PetId = anuncio.PetId,
                CaminhoDaFoto = "../../images/LojasPhotos/" + anuncio.Foto
            };

            return View(anuncioViewModel);
        }

        // POST: Anuncio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AnuncioViewModel anuncio)
        {
            if (id != anuncio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = null;

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images/LojasPhotos");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + anuncio.Foto.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    anuncio.Foto.CopyTo(new FileStream(filePath, FileMode.Create));

                    var anuncioBanco = await _context.Set<Anuncio>().FindAsync(id);
                    if (anuncio == null)
                    {
                        return NotFound();
                    }
                                       
                    anuncioBanco.UpdatedData = DateTime.Now;
                    anuncioBanco.Titulo = anuncio.Titulo;
                    anuncioBanco.CorpoAnuncio = anuncio.CorpoAnuncio;
                    anuncioBanco.Foto = uniqueFileName;
                    anuncioBanco.Anunciante = await _userManager.GetUserAsync(HttpContext.User);
                    anuncioBanco.TipoAnuncioId = anuncio.TipoAnuncioId;
                    anuncioBanco.PetId = anuncio.PetId;

                    anuncioBanco.Endereco = new Endereco
                    {
                        Bairro = anuncio.Bairro,
                        Cep = anuncio.Cep,
                        Numero = anuncio.Numero,
                        Rua = anuncio.Rua
                    };

                    _context.Update(anuncioBanco);
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
            ViewBag.PetId = new SelectList(_context.Set<Pet>(), "Id", "Nome");
            ViewBag.EstadoId = new SelectList(_context.Set<Estado>(), "Id", "Nome");
            ViewBag.TipoAnuncioId = new SelectList(_context.Set<TipoAnuncio>(), "Id", "Descricao");
            ViewBag.CidadeId = new SelectList(_context.Set<Cidade>(), "Id", "Nome");

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
