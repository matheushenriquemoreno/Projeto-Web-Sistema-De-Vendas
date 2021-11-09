using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_SistemaWeb.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BuscaSimples()
        {
            return View();
        }

        public IActionResult BuscaEmGrupo()
        {
            return View();
        }
    }
}
