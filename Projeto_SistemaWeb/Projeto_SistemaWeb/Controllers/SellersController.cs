using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_SistemaWeb.Services;
using Projeto_SistemaWeb.Models;
using Projeto_SistemaWeb.Models.ViewMoldes;
using Projeto_SistemaWeb.Services.Exceptions;
using System.Diagnostics;

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

        /*
         
         */

        [HttpPost] // indica ação de Post não de Get
        [ValidateAntiForgeryToken] // previne ataques csrf
        public IActionResult Create(Seller seller) // pega o vendedor que veio da requisição de cadastro
        {
            /*
             http://www.macoratti.net/15/09/mvc_mdlst1.htm => sobre o ModelState.IsValid
             */

            if (!ModelState.IsValid) // previne que o usuario faça a criação  de um novo usuario sem as regras de negocios inposta.
            {
                var departamento = _departmentService.FindAll();
                var viewModel = new SellerFormViewMoldel { Seller = seller, Departments = departamento };
                return View(viewModel);
            }

            _seller.Inserir(seller);
            return RedirectToAction(nameof(Index)); // redirecinando para tela principal nameof = melhora a manuntenção do sistema
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }

            var obj = _seller.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não exite!" });
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
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }

            var obj = _seller.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não exite" });
            }

            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if( id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não providenciado!" });
            }
            var obj = _seller.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não exite!" });
            }

            List<Department> listdepartamentos = _departmentService.FindAll();
            SellerFormViewMoldel viewModel = new SellerFormViewMoldel { Seller = obj, Departments = listdepartamentos };
            return View(viewModel);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid) // previne que o usuario faça a edição dos dados sem as regras de negocios inpostas
            {
                var departamento = _departmentService.FindAll();
                var viewModel = new SellerFormViewMoldel { Seller = seller, Departments = departamento };
                return View(viewModel);
            }

            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ids não correspondem!" });
            }
            try
            {
                _seller.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e) // por meio de upcasting as 2 excessoes criadas passam
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier // pega o id interno da requisição
            };
            return View(viewModel);
        }

    }
}
