using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Projeto_SistemaWeb.Services;
using System.Linq;

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

            if(!dataMinima.HasValue) // HasValue verifica se o resultado e de outro tipo do comparado se for retorna false 
            {
                dataMinima = new DateTime(2018, 1, 1);
            }
            if (!dataMaxima.HasValue)
            {
                dataMaxima = DateTime.Now;
            }

            ViewData["dataMinima"] = dataMinima.Value.ToString("yyyy-MM-dd");
            ViewData["dataMaxima"] = dataMaxima.Value.ToString("yyyy-MM-dd");

            var resultado = await _registroVendaService.BuscaPorDataAsync(dataMinima, dataMaxima);

            return View(resultado);
        }

        public async Task<IActionResult> BuscaEmGrupo(DateTime? dataMinima, DateTime? dataMaxima)
        {

            if (!dataMinima.HasValue)
            {
                dataMinima = new DateTime(2018, 1, 1);
            }
            if (!dataMaxima.HasValue)
            {
                dataMaxima = DateTime.Now;
            }

            ViewData["dataMinima"] = dataMinima.Value.ToString("yyyy-MM-dd");
            ViewData["dataMaxima"] = dataMaxima.Value.ToString("yyyy-MM-dd");

            var resultado = await _registroVendaService.BuscaPorDataGrupoAsync(dataMinima, dataMaxima);
            return View(resultado);
        }
  
    }
}
