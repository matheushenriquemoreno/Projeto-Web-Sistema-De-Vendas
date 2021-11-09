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
        
        public async Task<List<Seller>> FindAllAsync() //  Encontrar todos os vendedores
        {
            return await _context.Seller.ToListAsync(); 
        }

        public async Task InserirAsync(Seller vendedor)
        {
            _context.Add(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> EncontraPorIDAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                throw new IntegridadeDeAcessoException("Não pode deletar o vendedor pois posue vendas!!");
            }
        }

        public async Task UpdateAsync(Seller vendedor)
        {
            bool TemAlgum = await _context.Seller.AnyAsync(x => x.Id == vendedor.Id);

            if (!TemAlgum)
            {
                throw new NotFounException("Id não encontrado!!");
            }
            try
            {
                _context.Update(vendedor);
               await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e) // pegando uma esseção nivel de acesso a dados
            {
                throw new DbConcurrencyException(e.Message); // relançando a nivel de Serviço
            }
        }

    }
}
