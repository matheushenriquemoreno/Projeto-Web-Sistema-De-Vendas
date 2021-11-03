using System.Collections.Generic;


namespace Projeto_SistemaWeb.Models.ViewMoldes
{
    public class SellerFormViewMoldel
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
