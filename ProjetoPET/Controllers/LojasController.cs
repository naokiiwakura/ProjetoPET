﻿using System;
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
    public class LojasController : Controller
    {
        private readonly ProjetoPETContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public LojasController(ProjetoPETContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
            
        }

        // GET: Lojas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lojas.ToListAsync());
        }

        // GET: Lojas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lojas = await _context.Lojas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lojas == null)
            {
                return NotFound();
            }

            return View(lojas);
        }

        // GET: Lojas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lojas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LojasViewModel model)
        {
              if (ModelState.IsValid)
            {

                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images/LojasPhotos");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Lojas newLojas = new Lojas
                {
                    NomeLoja = model.NomeLoja,
                    RazaoSocial = model.RazaoSocial,
                    CNPj = model.CNPj,
                    Endereco = model.Endereco,
                    Numero = model.Numero,
                    Complemento = model.Complemento,
                    CEP = model.CEP,
                    Estado = model.Estado,
                    Cidade = model.Cidade,
                    Telefone = model.Telefone,
                    Email = model.Email,
                    ImagePath = uniqueFileName
                    
                };
                _context.Add(newLojas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Lojas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lojas = await _context.Lojas.FindAsync(id);
            if (lojas == null)
            {
                return NotFound();
            }
            return View(lojas);
        }

        // POST: Lojas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NomeLoja,RazaoSocial,CNPj,Endereco,Numero,Bairro,Complemento,CEP,Estado,Cidade,Telefone,Email,ImagePath,Id,CreatedDate,ModifiedDate")] Lojas lojas)
        {
            if (id != lojas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lojas = await _context.Lojas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lojas == null)
            {
                return NotFound();
            }

            return View(lojas);
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