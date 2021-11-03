using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_SistemaWeb.Services;
using Projeto_SistemaWeb.Models;
using Projeto_SistemaWeb.Models.ViewMoldes;

namespace Projeto_SistemaWeb.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerServices _seller;
        private readonly DepartmentService _departmentService;

       public SellersController(SellerServices sellerServices, DepartmentService departamento)
        {
            _seller = sellerServices;
            _departmentService = departamento;
        }


        public IActionResult Index()
        {
            var list = _seller.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var listdepartments = _departmentService.FindAll();
            var viewMoldel = new SellerFormViewMoldel { Departments = listdepartments };
            return View(viewMoldel);
        }

        [HttpPost] // indica ação de Post não de Get
        [ValidateAntiForgeryToken] // previne ataques csrf
        public IActionResult Create(Seller seller) // pega o vendedor que veio da requisição de cadastro
        {
            _seller.Inserir(seller);
            return RedirectToAction(nameof(Index)); // redirecinando para tela principal nameof = melhora a manuntenção do sistema
        }
    }
}
