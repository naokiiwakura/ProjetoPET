using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoPET.ViewModel;

namespace ProjetoPET.Controllers
{
    public class ReacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ReacaoViewModel reacaos)
        {
            return View();
        }
    }
}