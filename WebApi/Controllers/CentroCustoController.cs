using Domain.InterfacesServices.ICentroCustoService;
using Entities.Models;
using Entities.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class CentroCustoController : ControllerBase
{
    private readonly InterfaceCentroCustoService _service;

    public CentroCustoController(InterfaceCentroCustoService service)
    {
        _service = service;
    }

    [HttpGet("ListarCentroCustoClinica/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListarCentroCustoClinica(int idClinica) => await _service.ListarCentroCustoClinica(idClinica);

    [HttpGet("ObterCentroCusto/{idCentroCusto:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<CentroCusto>> ObterCentroCusto(int idCentroCusto) => await _service.ObterCentroCusto(idCentroCusto);

    [HttpPost("AdicionarCentroCusto")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<CentroCusto>>> AdicionarCentroCusto(CentroCusto centroCusto) => await _service.AdicionarCentroCusto(centroCusto);

    [HttpPut("AtualizarCentroCusto")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarCentroCusto(CentroCusto centroCusto)
    {
        await _service.AtualizarCentroCusto(centroCusto);

        return Ok();
    }

    [HttpDelete("DeletarCentroCusto/{idCentroCusto:int}")]
    [Produces("application/json")]
    public async Task<RetornoGenerico<object>> DeletarCentroCusto(int idCentroCusto) => await _service.DeletarCentroCusto(idCentroCusto);
}
