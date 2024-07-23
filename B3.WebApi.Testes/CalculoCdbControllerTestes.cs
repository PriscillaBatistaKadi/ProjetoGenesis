using B3.WebApi.Controllers;
using B3.WebApi.Domain.Model;
using B3.WebApi.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace B3.WebApi.Testes;

public class CalculoCdbControllerTestes
{
    private readonly Mock<ICalculoCdbService> _mockCalculoCdbService;
    private readonly Mock<IValidacoes> _mockValidacoes;
    private readonly CalculoCdbController _controller;

    public CalculoCdbControllerTestes()
    {
        _mockCalculoCdbService = new Mock<ICalculoCdbService>();
        _mockValidacoes = new Mock<IValidacoes>();
        _controller = new CalculoCdbController(_mockCalculoCdbService.Object, _mockValidacoes.Object);
    }

    [Fact]
    public void GetCalculo_DeveRetornarBadRequest_QuandoValidacoesFalham()
    {
        // Arrange
        double valorInicial = 0;
        int meses = 12;
        var errorMessage = "O Valor inicial deve ser positivo";
        _mockValidacoes.Setup(v => v.Validar(valorInicial, meses)).Throws(new ArgumentException(errorMessage));

        // Act
        var result = _controller.GetCalculo(valorInicial, meses);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal($"Erro encontrado: {errorMessage}", badRequestResult.Value);
    }

    [Fact]
    public void GetCalculo_DeveRetornarBadRequest_QuandoServicoLancaExcecao()
    {
        // Arrange
        double valorInicial = 1000;
        int meses = 12;
        var serviceException = new Exception("Erro no serviço");
        _mockValidacoes.Setup(v => v.Validar(valorInicial, meses)); // Simula validações passando
        _mockCalculoCdbService.Setup(s => s.CalculaCdb(valorInicial, meses)).Throws(serviceException);

        // Act
        var result = _controller.GetCalculo(valorInicial, meses);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal($"Erro encontrado: {serviceException.Message}", badRequestResult.Value);
    }
}