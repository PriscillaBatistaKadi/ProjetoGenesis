using B3.WebApi.Controllers;
using B3.WebApi.Domain.Model;
using B3.WebApi.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace B3.WebApi.Teste;

public class CalculoCdbControllerTestes
{
    private readonly Mock<ICalculoCdbService> _mockCalculoCdbService;
    private readonly CalculoCdbController _controller;

    public CalculoCdbControllerTestes()
    {
        _mockCalculoCdbService = new Mock<ICalculoCdbService>();
        _controller = new CalculoCdbController(_mockCalculoCdbService.Object);
    }
    
    [Fact]
    public void EntradaParametrosCorretos3()
    {
        // Arrange
        double valorInicial = 0;
        int meses = 2;
        
        // Act
        var response = _controller.GetCalculo(valorInicial, meses);
    
        // Assert
        Assert.NotNull(response);
        Assert.IsType<BadRequestObjectResult>(response);
    }
    
    [Fact]
    public void EntradaParametrosCorretos4()
    {
        // Arrange
        double valorInicial = 10000;
        int meses = 1;
        
        // Act
        var response = _controller.GetCalculo(valorInicial, meses);
    
        // Assert
        Assert.NotNull(response);
        Assert.IsType<BadRequestObjectResult>(response);
    }
    
    [Fact]
    public void EntradaParametrosCorretos()
    {
        // Arrange
        double valorInicial = 10000;
        int meses = 2;
    
        _mockCalculoCdbService.Setup(service => service.CalculaCdb(valorInicial, meses))
            .Returns(new CalculoCdbResponse { ValorBruto = 100.3, ValorLiquido = 90});
        
        // Act
        var response = _controller.GetCalculo(valorInicial, meses);
    
        // Assert
        Assert.NotNull(response);
        Assert.IsType<OkObjectResult>(response);
    }
    
    [Fact]
    public void EntradaParametrosCorretos2()
    {
        // Arrange
        double valorInicial = 10000;
        int meses = 2;
    
        _mockCalculoCdbService.Setup(service => service.CalculaCdb(valorInicial, meses))
            .Throws(new Exception());
        
        // Act
        var response = _controller.GetCalculo(valorInicial, meses);
    
        // Assert
        Assert.NotNull(response);
        Assert.IsType<BadRequestObjectResult>(response);
    }
}