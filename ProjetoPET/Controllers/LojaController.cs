using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoPET.Areas.Identity.Data;
using ProjetoPET.Models;
using ProjetoPET.Repository.Interfaces;
using ProjetoPET.ViewModel;

namespace ProjetoPET.Controllers
{
    public class LojaController : Controller
    {
        private readonly ILojaRepository _lojasRepository;
        private readonly IHostingEnvironment host;
        private readonly BancoContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;

        public LojaController(IHostingEnvironment hostingEnvironment, ILojaRepository lojasRepository,
            BancoContext bancoContext, IMapper mapper, UserManager<Usuario> userManager)
        {
            _lojasRepository = lojasRepository;
            this.host = hostingEnvironment;
            _context = bancoContext;
            _mapper = mapper;
            _userManager = userManager;

        }

        public async Task<IActionResult> Index()
        {
            var lojas = await _lojasRepository.GetAll();
            var lojasViewModel = _mapper.Map<IEnumerable<Loja>, IEnumerable<LojaViewModel>>(lojas);
            return View(lojasViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var loja = await _lojasRepository.GetById(id);
            var lojaViewModel = _mapper.Map<Loja, LojaViewModel>(loja);
            return View(lojaViewModel);
        }

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

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LojaViewModel lojaViewModel)
        {
            var _currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                if (lojaViewModel.Photo != null)
                {
                    string uniqueFileName = _lojasRepository.ConverterFoto(lojaViewModel.Photo, host.WebRootPath);
                    var loja = _mapper.Map<LojaViewModel, Loja>(lojaViewModel);
                    loja.ImagePath = uniqueFileName;
                    loja.UsuarioId = _currentUser.Id;
                    await _lojasRepository.Add(loja);
                }

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var loja = await _lojasRepository.GetById(id);
            var lojaViewModel = _mapper.Map<Loja, LojaViewModel>(loja);

            ViewBag.EstadoId = new SelectList(_context.Set<Estado>(), "Id", "Nome");
            ViewBag.CidadeId = new SelectList(_context.Set<Cidade>(), "Id", "Nome"); ;

            return View(lojaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LojaViewModel lojaViewModel)
        {
            string uniqueFileName = _lojasRepository.ConverterFoto(lojaViewModel.Photo, host.WebRootPath);
            var loja = _mapper.Map<LojaViewModel, Loja>(lojaViewModel);
            loja.ImagePath = uniqueFileName;
            await _lojasRepository.Update(loja);

            return View(lojaViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var loja = await _lojasRepository.GetById(id);
            var lojaViewModel = _mapper.Map<Loja, LojaViewModel>(loja);

            return View(lojaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lojas = await _context.Lojas.FindAsync(id);
            _context.Lojas.Remove(lojas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> MinhasLojas()
        {
            var _currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var lojas = _lojasRepository.MinhasLojas(_currentUser.Id);
            return  View(lojas);
        }

        private bool LojasExists(int id)
        {
            return _context.Lojas.Any(e => e.Id == id);
        }
    }
}
