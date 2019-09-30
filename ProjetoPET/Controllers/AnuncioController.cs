using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoPET.Controllers
{
    public class AnuncioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}