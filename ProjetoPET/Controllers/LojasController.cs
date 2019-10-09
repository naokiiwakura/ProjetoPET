using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoPET.Controllers
{
    public class LojasController : Controller
    {

        private readonly BancoContext _bancoContext;

        public LojasController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }



        //GET 
        public IActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id,NomeFantasia,CNPJ,Cidade,Endereco")] Loja lojas)
        {
            if (ModelState.IsValid)
            {
                _bancoContext.Add(lojas);
                await _bancoContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lojas);
        }

        //GET   
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lojas = await _bancoContext.Lojas.FindAsync(id);
            if (lojas == null)
            {
                return NotFound();
            }
            return View(lojas);
        }
       

    }
}