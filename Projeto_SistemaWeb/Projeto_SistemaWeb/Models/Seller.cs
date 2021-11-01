using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_SistemaWeb.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double SalarioBase { get; set; }
        public Department Departamento { get; set; }
        public ICollection<RegistroDeVenda> Vendas { get; set; } = new List<RegistroDeVenda>();


        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime dataNascimento, double salarioBase, Department departamento)
        {
            Id = id;
            Name = name;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AddVendas(RegistroDeVenda venda)
        {
            Vendas.Add(venda);
        }
        public void RemoveVendas(RegistroDeVenda venda)
        {
            Vendas.Remove(venda);
        }

        public double TotalVendas(DateTime inicial, DateTime final)
        {                      // compara se a data da venda ta dentro do espaço tempo requerido pelo usuario.
            return Vendas.Where(sr => sr.Data >= inicial && sr.Data <= final).Sum(sr => sr.Quantia);
        }

    }
}
