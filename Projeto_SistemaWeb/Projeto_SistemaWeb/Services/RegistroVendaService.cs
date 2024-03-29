﻿using Projeto_SistemaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Projeto_SistemaWeb.Models.Enums;

namespace Projeto_SistemaWeb.Services
{
    public class RegistroVendaService
    {

        private readonly Projeto_SistemaWebContext _context;

        public RegistroVendaService(Projeto_SistemaWebContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroDeVenda>> BuscaPorDataAsync(DateTime? dataMinima, DateTime? DataMaxima)
        {
            var resultado = from obj in _context.RegistroDeVendas select obj; // pega o registro de venda que o tipo e dbset e constroi um objeto resultado do tipo IQueryable
            
            if (dataMinima.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= dataMinima.Value);
            }
            if (DataMaxima.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= DataMaxima.Value);
            }

            return await resultado
                    .Include(x => x.Vendedor) // fazendo um join com a tabela vendedor
                    .Include(x => x.Vendedor.Departamento) // fazendo um join com a tabela departamento
                    .OrderBy(x => x.Vendedor.Id > 0)
                    .ToListAsync();
        }


        public async Task<List<IGrouping<Department, RegistroDeVenda>>> BuscaPorDataGrupoAsync(DateTime? dataMinima, DateTime? DataMaxima)
        {
            var resultado = from obj in _context.RegistroDeVendas select obj; 

            if (dataMinima.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= dataMinima.Value);
            }
            if (DataMaxima.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= DataMaxima.Value);
            }

            return await resultado
                    .Include(x => x.Vendedor) 
                    .Include(x => x.Vendedor.Departamento) 
                    .OrderByDescending(x => x.Data)
                    .GroupBy(x => x.Vendedor.Departamento)
                    .ToListAsync();
        }
    }
}
