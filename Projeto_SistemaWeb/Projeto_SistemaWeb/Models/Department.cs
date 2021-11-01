using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_SistemaWeb.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Vendedores { get; set; } = new List<Seller>(); // implementação da associação do departamento com os "muitos" vendedores

        public Department()
        {

        }
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddVendedor(Seller vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public double TotalDeVendas(DateTime inicio, DateTime final) // do departamento
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVendas(inicio,final)); // to pegando cada vendedor do departamento, e na função totalvenda pego o quanto cada um vendeu e somo na minha lista de vededores do departamento.
        }
    }
}
