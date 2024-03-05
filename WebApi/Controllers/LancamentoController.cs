using Domain.InterfacesServices.ILancamentoService;
using Entities.Models;
using Entities.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class LancamentoController : ControllerBase
{
    private readonly InterfaceLancamentoService _service;

    public LancamentoController(InterfaceLancamentoService service)
    {
        _service = service;
    }

    [HttpGet("ListaLancamentoReceitas/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListaLancamentoReceitas(int idClinica) => await _service.ListaLancamentoReceitas(idClinica);

    [HttpGet("ListaLancamentoDespesas/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListaLancamentoDespesas(int idClinica) => await _service.ListaLancamentoDespesas(idClinica);

    [HttpGet("ObterLancamento/{idLancamento:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<Lancamento>> ObterLancamento(int idLancamento) => await _service.ObterLancamento(idLancamento);

    [HttpGet("RetornoSaldoGeral/{idContaBancaria:int}")]
    public async Task<ActionResult<RetornoGenerico<decimal>>> RetornoSaldoGeral(int idContaBancaria) => await _service.RetornoSaldoGeral(idContaBancaria);

    [HttpPost("AdicionarLancamento")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<Lancamento>>> AdicionarLancamento(Lancamento lancamento) => await _service.AdicionarLancamento(lancamento);

    [HttpPut("AtualizarLancamento")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarLancamento(Lancamento lancamento)
    {
        await _service.AtualizarLancamento(lancamento);

        return Ok();
    }

    [HttpDelete("DeletarLancamento/{idLancamento:int}")]
    [Produces("application/json")]
    public async Task<RetornoGenerico<object>> DeletarLancamento(int idLancamento) => await _service.DeletarLancamento(idLancamento);
}
