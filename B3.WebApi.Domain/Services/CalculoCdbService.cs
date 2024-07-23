using B3.WebApi.Domain.Model;
using B3.WebApi.Domain.Utils;

namespace B3.WebApi.Domain.Services;

public static class CalculoCdbService
{
    public static CalculoCdbResponse CalculaCdb(double valorInicial, int meses)
    {
       var valorBruto = GetValorBruto(valorInicial, meses);
       var ganho = valorBruto - valorInicial;
       var valorLiquido = GetValorLiquido(meses, valorBruto, ganho);

       return new CalculoCdbResponse { ValorBruto = valorBruto, ValorLiquido = valorLiquido};
    }

    private static double GetValorLiquido(int meses, double valorBruto, double ganho)
    {
        var percentualImposto = meses switch
        {
            <= 6 => Imposto.SeisMeses,
            <= 12 => Imposto.DozeMeses,
            <= 24 => Imposto.VinteEQuatroMeses,
            _ => Imposto.AcimaVinteEQuatroMeses
        };

        return valorBruto - ganho * percentualImposto;
    }

    private static double GetValorBruto(double valorInicial, int meses)
    {
        var valorAtual = valorInicial;

        for (var i = 0; i < meses; i++) valorAtual = CalculoCdb(valorAtual);

        return valorAtual;
    }
    
    private static double CalculoCdb(double valorInicial)
    {
        return valorInicial * (1 + Taxa.Cdi * Taxa.Banco);
    }
}