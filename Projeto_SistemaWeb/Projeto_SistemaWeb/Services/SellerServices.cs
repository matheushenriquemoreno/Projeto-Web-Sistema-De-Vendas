using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_SistemaWeb.Models;
namespace Projeto_SistemaWeb.Services
{
    public class SellerServices
    {

        private readonly Projeto_SistemaWebContext _context;

        public SellerServices(Projeto_SistemaWebContext context)
        {
            _context = context;
        }
        
        public List<Seller> FindAll() //  Encontrar todos os vendedores
        {
            return _context.Seller.ToList(); 
        }


    }
}
