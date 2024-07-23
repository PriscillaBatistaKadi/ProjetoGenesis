using B3.WebApi.Domain.Model;
using B3.WebApi.Domain.Services.Interfaces;

namespace B3.WebApi.Domain.Services;

public class CalculoCdbServiceWrapper : ICalculoCdbService
{
    public CalculoCdbResponse CalculaCdb(double valorInicial, int meses)
    {
        return CalculoCdbService.CalculaCdb(valorInicial, meses);
    }
}