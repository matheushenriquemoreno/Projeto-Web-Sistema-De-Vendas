using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_SistemaWeb.Models;

namespace Projeto_SistemaWeb.Models
{
    public class Projeto_SistemaWebContext : DbContext
    {
        public Projeto_SistemaWebContext (DbContextOptions<Projeto_SistemaWebContext> options)
            : base(options)
        {
        }
        // DbSet<TEntity>: representa a coleção de entidades de um dado tipo em cum contexto. tipicamente corresponde a uma tabela do banco de dados.

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<RegistroDeVenda> RegistroDeVendas { get; set; }

    }
}
