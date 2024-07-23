using B3.WebApi.Domain.Services;
using Xunit;

namespace B3.WebApi.Teste
{
    public class CalculoCdbServiceTestes
    {
        private readonly CalculoCdbServiceWrapper _calculoCdbService = new();

        [Theory]
        [InlineData(10000, 2, 10195.34)]
        public void ValorBrutoCalculadoCorretamente(double valorInicial, int meses, double expectedValorFinal)
        {
            // Arrange
            var response = _calculoCdbService.CalculaCdb(valorInicial, meses);

            // Act
            var valorBruto = response.ValorBruto;

            // Assert
            Assert.Equal(expectedValorFinal, valorBruto);
        }

        [Theory]
        [InlineData(100.50,6,105.15)]
        [InlineData(100.50,12,110.40)]
        [InlineData(100.50,24,122.17)]
        [InlineData(100.50,50,153.63)]
        public void ValorLiquidoCalculadoCorretamente(double valorInicial, int meses, double expectedValorLiquido)
        {
            // Arrange
            var response = _calculoCdbService.CalculaCdb(valorInicial, meses);

            // Act
            var valorLiquido = response.ValorLiquido;

            // Assert
            Assert.Equal(expectedValorLiquido, valorLiquido);
        }
    }

}
