using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Projeto_SistemaWeb.Models.Enums;

namespace Projeto_SistemaWeb.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} Obrigatorio!")]
        [StringLength(60,MinimumLength = 3, ErrorMessage = "{0} Tamanho maximo Entre {2} e {1} caracteres")]
        public string Name { get; set; }

        
        [Required(ErrorMessage = "{0} Obrigatorio!")]
        [EmailAddress(ErrorMessage = "Entre com um email valido.")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Obrigatorio!")]
        [Display(Name = "Data De Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "{0} Obrigatorio!")]
        [Range(100.0, 50000.0, ErrorMessage ="{0} não pode ser menor que {1} e maior que {2}")]
        [Display(Name = "Salario")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double SalarioBase { get; set; }

        public Department Departamento { get; set; }
        
        [Display(Name = "Departamento")]
        public int DepartmentId { get; set; }
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
            return Vendas.Where(venda => venda.Data >= inicial && venda.Data <= final && venda.Status == StatusVenda.Faturado).Sum(venda => venda.Quantia);
        }

    }
}
