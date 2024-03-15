using Domain.InterfacesServices.IFormaPagamentoService;
using Entities.Models;
using Entities.Retorno;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FormaPagamentoController : ControllerBase
{
    private readonly InterfaceFormaPagamentoService _service;

    public FormaPagamentoController(InterfaceFormaPagamentoService service)
    {
        _service = service;
    }

    [HttpGet("ListarFormaPagamentoClinica/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListarFormaPagamentoClinica(int idClinica) => await _service.ListarFormaPagamentoClinica(idClinica);

    [HttpGet("ObterFormaPagamento/{idFormaPagamento:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<FormaPagamento>> ObterFormaPagamento(int idFormaPagamento) => await _service.ObterFormaPagamento(idFormaPagamento);

    [HttpPost("AdicionarFormaPagamento")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<FormaPagamento>>> AdicionarFormaPagamento(FormaPagamento formaPagamento) => await _service.AdicionarFormaPagamento(formaPagamento);

    [HttpPut("AtualizarFormaPagamento")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarFormaPagamento(FormaPagamento formaPagamento)
    {
        await _service.AtualizarFormaPagamento(formaPagamento);

        return Ok();
    }

    [HttpDelete("DeletarFormaPagamento/{idFormaPagamento:int}")]
    [Produces("application/json")]
    public async Task<RetornoGenerico<object>> DeletarFormaPagamento(int idFormaPagamento) => await _service.DeletarFormaPagamento(idFormaPagamento);
}
