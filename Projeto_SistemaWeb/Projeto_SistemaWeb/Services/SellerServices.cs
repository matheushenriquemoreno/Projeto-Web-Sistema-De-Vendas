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

        public void Inserir(Seller vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }


    }
}
