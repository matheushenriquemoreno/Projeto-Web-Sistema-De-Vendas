using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_SistemaWeb.Models;

namespace Projeto_SistemaWeb.Data
{
    public class Projeto_SistemaWebContext : DbContext
    {
        public Projeto_SistemaWebContext (DbContextOptions<Projeto_SistemaWebContext> options)
            : base(options)
        {
        }

        public DbSet<Projeto_SistemaWeb.Models.Department> Department { get; set; }
    }
}
