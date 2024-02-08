using Domain.Interfaces.IConfiguracaoClinica;
using Domain.InterfacesServices.IConfiguracaoClinicaService;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class ConfiguracaoClinicaController : ControllerBase
{
    private readonly InterfaceConfiguracaoClinica _repositorio;
    private readonly InterfaceConfiguracaoClinicaService _service;

    public ConfiguracaoClinicaController(InterfaceConfiguracaoClinica repositorio, InterfaceConfiguracaoClinicaService service)
    {
        _repositorio = repositorio;
        _service = service;
    }

    [HttpGet("ObterConfiguracaoClinica/{idConfiguracaoClinica:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<ConfiguracaoClinica>> ObterConfiguracaoClinica(int idConfiguracaoClinica)
        => await _repositorio.GetEntityById(idConfiguracaoClinica);

    [HttpGet("ObterConfiguracaoIdClinica/{idClinica:int}")]
    public async Task<ActionResult<ConfiguracaoClinica>> ObterConfiguracaoIdClinica(int idClinica)
        => await _repositorio.ObterConfiguracaoClinica(idClinica);

    [HttpPost("AdicionarConfiguracaoClinica")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarConfiguracaoClinica(ConfiguracaoClinica configuracaoClinica)
    {
        await _service.AdicionarConfiguracaoClinica(configuracaoClinica);
        return Ok();
    }

    [HttpPut("AtualizarConfiguracaoClinica")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarConfiguracaoClinica(ConfiguracaoClinica configuracaoClinica)
    {
        await _service.AtualizarConfiguracaoClinica(configuracaoClinica);
        return Ok();
    }

    [HttpDelete("DeletarConfiguracaoClinica/{idConfiguracaoClinica:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<ConfiguracaoClinica>> DeletarConfiguracaoClinica(int idConfiguracaoClinica)
    {
        await _service.DeletarConfiguracaoClinica(idConfiguracaoClinica);
        return Ok();
    }
}
