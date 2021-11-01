using Microsoft.AspNetCore.Mvc;
using Projeto_SistemaWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_SistemaWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() // o nome do metodo e mapeado para ação
        {
            return View();
        }
         
        public IActionResult About()
        {
            ViewData["Message"] = "Salles web MVc app from C# Course";
            ViewData["Professor"] = "Matheus Henrique";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
