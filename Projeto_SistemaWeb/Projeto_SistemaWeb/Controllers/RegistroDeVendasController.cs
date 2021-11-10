using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Projeto_SistemaWeb.Services;

namespace Projeto_SistemaWeb.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        private readonly RegistroVendaService _registroVendaService; // declanrando dependencia
        
        public RegistroDeVendasController(RegistroVendaService servicevendas) 
        {
            _registroVendaService = servicevendas;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> BuscaSimples(DateTime? dataMinima, DateTime? dataMaxima)
        {

            if(!dataMinima.HasValue)
            {
                dataMinima = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataMaxima.HasValue)
            {
                dataMaxima = DateTime.Now;
            }
            ViewData["dataMinima"] = dataMinima.Value.ToString("yyyy-MM-dd");
            ViewData["dataMaxima"] = dataMaxima.Value.ToString("yyyy-MM-dd");

            var rerultado = await _registroVendaService.BuscaPorDataAsync(dataMinima, dataMaxima);
            return View(rerultado);
        }

        public async Task<IActionResult> BuscaEmGrupo(DateTime? dataMinima, DateTime? dataMaxima)
        {

            if (!dataMinima.HasValue)
            {
                dataMinima = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataMaxima.HasValue)
            {
                dataMaxima = DateTime.Now;
            }
            ViewData["dataMinima"] = dataMinima.Value.ToString("yyyy-MM-dd");
            ViewData["dataMaxima"] = dataMaxima.Value.ToString("yyyy-MM-dd");

            var rerultado = await _registroVendaService.BuscaPorDataGrupoAsync(dataMinima, dataMaxima);
            return View(rerultado);
        }
  
    }
}
