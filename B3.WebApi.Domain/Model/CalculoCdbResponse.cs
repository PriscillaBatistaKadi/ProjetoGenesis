using System.Diagnostics.CodeAnalysis;

namespace B3.WebApi.Domain.Model;

[ExcludeFromCodeCoverage]
public class CalculoCdbResponse
{
    private double _valorBruto;
    private double _valorLiquido;
    public double ValorBruto
    {
        get => _valorBruto;
        set => _valorBruto = Math.Round(value, 2);
    }
    public double ValorLiquido 
    { 
        get => _valorLiquido;
        set => _valorLiquido = Math.Round(value, 2);
    }
}