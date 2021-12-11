using System;
using System.ComponentModel.DataAnnotations;
using Projeto_SistemaWeb.Models.Enums;

namespace Projeto_SistemaWeb.Models
{
    public class RegistroDeVenda
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
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
