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


        public  async Task<IActionResult> Index()
        {
            var list = await _seller.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var listdepartments = await _departmentService.FindAllAsync();
            var viewMoldel = new SellerFormViewMoldel { Departments = listdepartments };
            return View(viewMoldel);
        }

        [HttpPost] // indica ação de Post não de Get
        [ValidateAntiForgeryToken] // previne ataques csrf
        public async Task<IActionResult> Create(Seller seller) // pega o vendedor que veio da requisição de cadastro
        {
            /*
             http://www.macoratti.net/15/09/mvc_mdlst1.htm => sobre o ModelState.IsValid
             */

            if (!ModelState.IsValid) // previne que o usuario faça a criação  de um novo usuario sem as regras de negocios inposta.
            {
                var departamento = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewMoldel { Seller = seller, Departments = departamento };
                return View(viewModel);
            }

            await _seller.InserirAsync(seller);
            return RedirectToAction(nameof(Index)); // redirecinando para tela principal nameof = melhora a manuntenção do sistema
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }

            var obj = await _seller.EncontraPorIDAsync(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não exite!" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _seller.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }

            var obj = await _seller.EncontraPorIDAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não exite" });
            }

            return View(obj);

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if( id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não providenciado!" });
            }
            var obj = await _seller.EncontraPorIDAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não exite!" });
            }

            List<Department> listdepartamentos = await _departmentService.FindAllAsync();
            SellerFormViewMoldel viewModel = new SellerFormViewMoldel { Seller = obj, Departments = listdepartamentos };
            return View(viewModel);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid) // previne que o usuario faça a edição dos dados sem as regras de negocios inpostas
            {
                var departamento = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewMoldel { Seller = seller, Departments = departamento };
                return View(viewModel);
            }

            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ids não correspondem!" });
            }
            try
            {
                await _seller.UpdateAsync(seller);
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
