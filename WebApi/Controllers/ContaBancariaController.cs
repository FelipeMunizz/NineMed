using Domain.Interfaces.IBanco;
using Domain.InterfacesServices.IContaBancariaService;
using Entities.Models;
using Entities.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class ContaBancariaController : ControllerBase
{
    private readonly InterfaceContaBancariaService _service;

    public ContaBancariaController(InterfaceContaBancariaService service)
    {
        _service = service;
    }

    [HttpGet("ListaContasBancariaBanco/{idBanco:int}")]
    [Produces("application/json")]
    public async Task<object> ListaContasBancariaBanco(int idBanco) => await _service.ListaContasBancariaBanco(idBanco);

    [HttpGet("ObterContaBancaria/{idContaBancaria:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<ContaBancaria>> ObterContaBancaria(int idContaBancaria) => await _service.ObterContaBancaria(idContaBancaria);

    [HttpPost("AdicionarContaBancaria")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<ContaBancaria>>> AdicionarContaBancaria(ContaBancaria contaBancaria) => await _service.AdicionarContaBancaria(contaBancaria);

    [HttpPut("AtualizarContaBancaria")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarContaBancaria(ContaBancaria contaBancaria)
    {
        await _service.AtualizarContaBancaria(contaBancaria);

        return Ok();
    }

    [HttpDelete("DeletarContaBancaria/{idContaBancaria:int}")]
    [Produces("application/json")]
    public async Task<RetornoGenerico<object>> DeletarContaBancaria(int idContaBancaria) => await _service.DeletarContaBancaria(idContaBancaria);
}
