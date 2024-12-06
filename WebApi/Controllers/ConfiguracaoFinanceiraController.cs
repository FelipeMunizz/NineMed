using Domain.InterfacesServices.IConfiguracaoFinanceiraService;
using Entities.Models;
using Entities.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class ConfiguracaoFinanceiraController : ControllerBase
{
    private readonly InterfaceConfiguracaoFinanceiraService _service;

    public ConfiguracaoFinanceiraController(InterfaceConfiguracaoFinanceiraService service)
    {
        _service = service;
    }

    [HttpGet("ListarConfiguracaoFinanceiraClinica/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListarConfiguracaoFinanceiraClinica(int idClinica) => await _service.ListarConfiguracaoFinanceiraClinica(idClinica);

    [HttpGet("ObterConfiguracaoFinanceira/{idConfiguracaoFinanceira:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<ConfiguracaoFinanceira>> ObterConfiguracaoFinanceira(int idConfiguracaoFinanceira) => await _service.ObterConfiguracaoFinanceira(idConfiguracaoFinanceira);

    [HttpPost("AdicionarConfiguracaoFinanceira")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<ConfiguracaoFinanceira>>> AdicionarConfiguracaoFinanceira(ConfiguracaoFinanceira configuracaoFinanceira) => await _service.AdicionarConfiguracaoFinanceira(configuracaoFinanceira);

    [HttpPut("AtualizarConfiguracaoFinanceira")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarConfiguracaoFinanceira(ConfiguracaoFinanceira configuracaoFinanceira)
    {
        await _service.AtualizarConfiguracaoFinanceira(configuracaoFinanceira);

        return Ok();
    }

    [HttpDelete("DeletarConfiguracaoFinanceira/{idConfiguracaoFinanceira:int}")]
    [Produces("application/json")]
    public async Task<RetornoGenerico<object>> DeletarConfiguracaoFinanceira(int idConfiguracaoFinanceira) => await _service.DeletarConfiguracaoFinanceira(idConfiguracaoFinanceira);
}
