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
    public class ImageDataController : Controller
    {
        private readonly BancoContext _context;

        public ImageDataController(BancoContext context)
        {
            _context = context;
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}
