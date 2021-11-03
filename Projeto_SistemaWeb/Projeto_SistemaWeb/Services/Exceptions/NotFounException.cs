using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_SistemaWeb.Services.Exceptions
{
    public class NotFounException : ApplicationException
    {
        public NotFounException(string message) : base (message)
        {

        }
    }
}
