using B3.WebApi.Domain.Model;

namespace B3.WebApi.Domain.Services.Interfaces;

public interface ICalculoCdbService
{
    CalculoCdbResponse CalculaCdb(double valorInicial, int meses);
}