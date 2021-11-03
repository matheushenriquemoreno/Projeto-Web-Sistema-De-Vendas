using Projeto_SistemaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_SistemaWeb.Services
{
    public class DepartmentService // metodo que retorna todos os departamentos
    {

        private readonly Projeto_SistemaWebContext _context;

        public DepartmentService(Projeto_SistemaWebContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

    }
}
