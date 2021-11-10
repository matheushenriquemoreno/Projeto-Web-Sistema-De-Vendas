using Microsoft.AspNetCore.Mvc;
using Projeto_SistemaWeb.Models;
using System.Diagnostics;


namespace Projeto_SistemaWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() // o nome do metodo e mapeado para ação
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
