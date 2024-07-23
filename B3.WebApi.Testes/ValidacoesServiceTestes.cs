using B3.WebApi.Controllers;
using B3.WebApi.Domain.Model;
using B3.WebApi.Domain.Services;
using B3.WebApi.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace B3.WebApi.Testes
{
    public class ValidacoesServiceTestes
    {

        private readonly Mock<IValidacoes> _mockValidacoes;
        private readonly ValidacoesService _validacoesService;

        public ValidacoesServiceTestes()
        {
            _mockValidacoes = new Mock<IValidacoes>();
            _validacoesService = new ValidacoesService();
        }

        [Theory]
        [InlineData(0, 5, "O Valor inicial deve ser positivo")]
        [InlineData(-100, 5, "O Valor inicial deve ser positivo")]
        [InlineData(100, 0, "A quantidade de meses deve ser maior que 1")]
        [InlineData(200, -10, "A quantidade de meses deve ser maior que 1")]

        public void ArgumentExceptionQuandoValorInicialMenorOuIgualAZero(double valorInicial, int meses, string mensagemEsperada)
        {
            // Arrange
            _mockValidacoes.Setup(v => v.Validar(valorInicial, meses)).Throws(new ArgumentException(mensagemEsperada));

            // Act + Assert
            var ex = Assert.Throws<ArgumentException>(() => _validacoesService.Validar(valorInicial, meses));
            Assert.Equal(mensagemEsperada, ex.Message);
        }

   
    }
}
