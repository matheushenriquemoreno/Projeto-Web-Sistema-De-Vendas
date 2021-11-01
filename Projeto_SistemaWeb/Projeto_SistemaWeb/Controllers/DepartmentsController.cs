using Microsoft.AspNetCore.Mvc;
using Projeto_SistemaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_SistemaWeb.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department{Id = 1, Name = "Eletronicos"});
            list.Add(new Department { Id = 2, Name = "Fashion" });


            return View(list); // enviando dados pro controler para view
        }
    }
}
