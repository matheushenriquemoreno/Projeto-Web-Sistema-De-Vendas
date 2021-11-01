using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_SistemaWeb.Services;

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
    }
}
