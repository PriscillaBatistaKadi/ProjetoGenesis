using B3.WebApi.Domain.Services;
using B3.WebApi.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace B3.WebApi.Controllers;

[Route("api/calculo-cdb")]
[ApiController]
public class CalculoCdbController : ControllerBase
{
    private readonly ICalculoCdbService _calculoCdbService;
    
    public CalculoCdbController(ICalculoCdbService calculoCdbService)
    {
        _calculoCdbService = calculoCdbService;
    }

    /// <summary>
    /// Cálculo do CDB
    /// </summary>
    /// <param name="valorInicial">Valor inicial do investimento</param>
    /// <param name="meses">Quantos meses irá investir</param>
    /// <response code="200">Success</response>
    /// <response code="400">BadRequest</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetCalculo(double valorInicial, int meses)
    {
        try
        {
            if (valorInicial <= 0)
                return BadRequest("O Valor inicial deve ser positivo");
            
            if (meses <= 1)
                return BadRequest("A quantidade de meses deve ser maior que 1");
            
            var response = _calculoCdbService.CalculaCdb(valorInicial, meses);
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro encontrado: {ex.Message}");
        }
    }
}