using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_SistemaWeb.Services;
using Projeto_SistemaWeb.Models;
using Projeto_SistemaWeb.Models.ViewMoldes;
using Projeto_SistemaWeb.Services.Exceptions;

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

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _seller.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _seller.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _seller.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if( id == null)
            {
                return NotFound();
            }
            var obj = _seller.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            List<Department> listdepartamentos = _departmentService.FindAll();
            SellerFormViewMoldel viewModel = new SellerFormViewMoldel { Seller = obj, Departments = listdepartamentos };
            return View(viewModel);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if(id != seller.Id)
            {
                return BadRequest();
            }
            try
            {
                _seller.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFounException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }

    }
}
