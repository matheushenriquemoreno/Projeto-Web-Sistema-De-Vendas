using System;

namespace Projeto_SistemaWeb.Models.ViewMoldes
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}