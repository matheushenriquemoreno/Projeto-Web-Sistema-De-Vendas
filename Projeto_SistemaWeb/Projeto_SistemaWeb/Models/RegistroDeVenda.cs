using System;
using Projeto_SistemaWeb.Models.Enums;

namespace Projeto_SistemaWeb.Models
{
    public class RegistroDeVenda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Quantia { get; set; }
        public StatusVenda Status { get; set; }
        public Seller Vendedor { get; set; }

        public RegistroDeVenda()
        {

        }
        public RegistroDeVenda(int id, DateTime data, double quantia, StatusVenda status, Seller vendedor)
        {
            Id = id;
            Data = data;
            Quantia = quantia;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
