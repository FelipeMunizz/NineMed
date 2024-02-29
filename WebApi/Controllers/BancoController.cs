using Domain.InterfacesServices.IBancoService;
using Entities.Models;
using Entities.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class BancoController : ControllerBase
{
    private readonly InterfaceBancoService _service;

    public BancoController(InterfaceBancoService service)
    {
        _service = service;
    }

    [HttpGet("ListarBancosClinica/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListarBancosClinica(int idClinica) => await _service.ListarBancosClinica(idClinica);

    [HttpGet("ObterBanco/{idBanco:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<Banco>> ObterBanco(int idBanco) => await _service.ObterBanco(idBanco);

    [HttpPost("AdicionarBanco")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<Banco>>> AdicionarBanco(Banco banco) => await _service.AdicionarBanco(banco);

    [HttpPut("AtualizarBanco")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarBanco(Banco banco)
    {
        await _service.AtualizarBanco(banco);

        return Ok();
    }

    [HttpDelete("DeletarBanco/{idBanco:int}")]
    [Produces("application/json")]
    public async Task<RetornoGenerico<object>> DeletarBanco(int idBanco) => await _service.DeletarBanco(idBanco);
}
