using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.WebApi.Domain.Services.Interfaces
{
    public interface IValidacoes
    {
        void Validar(double valorInicial, int meses);
    }
}

