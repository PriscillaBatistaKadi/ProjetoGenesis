namespace B3.WebApi.Domain.Services.Interfaces;

public interface ICalcularCdbService
{
    void CalcularCdbService(double valorInicial, double cdi, double taxaBanco, int meses);
}