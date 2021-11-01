using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_SistemaWeb.Services;
using Projeto_SistemaWeb.Models;

namespace Projeto_SistemaWeb.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerServices _seller;
        
       public SellersController(SellerServices sellerServices)
        {
            _seller = sellerServices;
        }


        public IActionResult Index()
        {
            var list = _seller.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) // pega o vendedor que veio da requisição de cadastro
        {
            _seller.Inserir(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
