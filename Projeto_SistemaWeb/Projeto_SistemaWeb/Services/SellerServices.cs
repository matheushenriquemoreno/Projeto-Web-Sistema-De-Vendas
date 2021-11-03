using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_SistemaWeb.Models;
using Microsoft.EntityFrameworkCore;
using Projeto_SistemaWeb.Services.Exceptions;

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
            return _context.Seller.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller vendedor)
        {
            if(!_context.Seller.Any(x => x.Id == vendedor.Id))
            {
                throw new NotFounException("Id não encontrado!!");
            }
            try
            {
                _context.Update(vendedor);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e) // pegando uma esseção nivel de acesso a dados
            {
                throw new DbConcurrencyException(e.Message); // relaçando a nivel de Serviço
            }
        }

    }
}
