using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoPET.Models;
using ProjetoPET.repository.Interfaces;
using ProjetoPET.ViewModel;

namespace ProjetoPET.Controllers
{
    public class LojasController : Controller
    {
        private readonly ILojaRepository _lojasRepository;
        private readonly IHostingEnvironment host;
        private readonly BancoContext _context;
        private readonly IMapper _mapper;

        public LojasController(IHostingEnvironment hostingEnvironment, ILojaRepository lojasRepository, BancoContext bancoContext, IMapper mapper)
        {
            _lojasRepository = lojasRepository;
            this.host = hostingEnvironment;
            _context = bancoContext;
            _mapper = mapper;

        }

        // GET: Lojas
        public async Task<IActionResult> Index()
        {
            return View(await _lojasRepository.GetAll());
        }

        // GET: Lojas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var loja = await _lojasRepository.GetById(id);
            var lojaViewModel = _mapper.Map<Lojas, LojasViewModel>(loja);
            return View(lojaViewModel);
        }


        // GET: Lojas/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(_context.Set<Estado>(), "Id", "Nome");
            ViewBag.CidadeId = new SelectList(_context.Set<Cidade>().Where(p => p.Estado.Nome == "Acre"), "Id", "Nome");

            return View();
        }

        public IActionResult GetCidades(int id)
        {
            return Json(_context.Cidade.Where(p => p.Estado.Id == id).ToList());
        }

        // POST: Lojas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LojasViewModel lojaViewModel)
        {
            if (ModelState.IsValid)
            {
                if (lojaViewModel.Photo != null)
                {
                    string uniqueFileName =  _lojasRepository.ConverterFoto(lojaViewModel.Photo, host.WebRootPath);
                    var loja = _mapper.Map<LojasViewModel, Lojas>(lojaViewModel);
                    loja.ImagePath = uniqueFileName;
                    await _lojasRepository.Add(loja);
                }

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Lojas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var loja = await _lojasRepository.GetById(id);
            var lojaViewModel = _mapper.Map<Lojas, LojasViewModel>(loja);

            ViewBag.EstadoId = new SelectList(_context.Set<Estado>(), "Id", "Nome");
            ViewBag.CidadeId = new SelectList(_context.Set<Cidade>(), "Id", "Nome"); ;

            return View(lojaViewModel);
        }

        // POST: Lojas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Lojas lojas)
        {

            if (id != lojas.Id)
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {
                var lojaVm = new LojasViewModel
                {
                    NomeLoja = lojas.NomeLoja,
                    RazaoSocial = lojas.RazaoSocial,
                    CNPj = lojas.CNPj,
                    Endereco = lojas.Endereco,
                    Numero = lojas.Numero,
                    Bairro = lojas.Bairro,
                    Complemento = lojas.Complemento,
                    CEP = lojas.CEP,
                    CidadeId = lojas.CidadeId,
                    Telefone = lojas.Telefone,
                    Email = lojas.Email,


                };

                try
                {
                    _context.Update(lojas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LojasExists(lojas.Id))
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

            return View(lojas);
        }

        // GET: Lojas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var loja = await _lojasRepository.GetById(id);
            var lojaViewModel = _mapper.Map<Lojas, LojasViewModel>(loja);

            return View(lojaViewModel);
        }

        // POST: Lojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lojas = await _context.Lojas.FindAsync(id);
            _context.Lojas.Remove(lojas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LojasExists(int id)
        {
            return _context.Lojas.Any(e => e.Id == id);
        }
    }
}
