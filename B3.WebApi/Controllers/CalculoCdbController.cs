using B3.WebApi.Domain.Model;
using B3.WebApi.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace B3.WebApi.Controllers;

[Route("api/calculo-cdb")]
[ApiController]
public class CalculoCdbController : ControllerBase
{
    private readonly ICalculoCdbService _calculoCdbService;
    private readonly IValidacoes _validacoes;

    public CalculoCdbController(ICalculoCdbService calculoCdbService, IValidacoes validacoes)
    {
        _calculoCdbService = calculoCdbService;
        _validacoes = validacoes;
    }

    /// <summary>
    /// Cálculo do CDB
    /// </summary>
    /// <param name="valorInicial">Valor inicial do investimento</param>
    /// <param name="meses">Quantos meses irá investir</param>
    /// <response code="200">Success</response>
    /// <response code="400">BadRequest</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CalculoCdbResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public IActionResult GetCalculo(double valorInicial, int meses)
    {
        try
        {
            _validacoes.Validar(valorInicial, meses);

            var response = _calculoCdbService.CalculaCdb(valorInicial, meses);
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro encontrado: {ex.Message}");
        }
    }
}