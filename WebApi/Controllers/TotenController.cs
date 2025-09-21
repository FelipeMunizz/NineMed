using Domain.Interfaces.IToten;
using Domain.InterfacesServices.ITotenService;
using Entities.Enums;
using Entities.Models;
using Entities.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class TotenController : ControllerBase
{
    private readonly InterfaceTotenService _service;
    private readonly InterfaceSenhaToten _repositorySenhas;
    private readonly InterfaceToten _repositoryToten;

    public TotenController(InterfaceTotenService service, InterfaceSenhaToten repositorySenhas, InterfaceToten repositoryToten)
    {
        _service = service;
        _repositorySenhas = repositorySenhas;
        _repositoryToten = repositoryToten;
    }

    [HttpGet("ListaTotensClinica/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListaTotensClinica(int idClinica) => await _repositoryToten.ListaTotensClinica(idClinica);

    [HttpGet("ObterToten/{idToten:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<Toten>> ObterToten(int idToten) => await _repositoryToten.GetEntityById(idToten);

    [AllowAnonymous]
    [HttpGet("ListarSenhasPainel/{idToten:int}")]
    [Produces("application/json")]
    public async Task<object> ListarSenhasPainel(int idToten) => await _repositorySenhas.ListaSenhasPainel(idToten);

    [HttpGet("ListaSenhaTotenTipoAtendimento/{tipoAtendimento:int}/{idToten:int}")]
    [Produces("application/json")]
    public async Task<object> ListaSenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento, int idToten)
        => await _service.ListaSenhaTotenTipoAtendimento(tipoAtendimento, idToten);

    [HttpPost("AdicionarToten")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarToten(Toten toten)
    {
        await _service.AdicionarToten(toten);
        return Ok();
    }

    [HttpPut("AtualizarToten")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarToten(Toten toten)
    {
        await _service.AtualizarToten(toten);
        return Ok();
    }

    [HttpDelete("DeletarToten/{idToten:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarToten(int idToten)
    {
        await _service.DeletarToten(idToten);
        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("AdicionarSenhaToten")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<SenhaToten>>> AdicionarSenhaToten(SenhaToten senhaToten) 
        => await _service.AdicionarSenhaToten(senhaToten);

    [HttpPut("AtualizarSenhaToten")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarSenhaToten(SenhaToten senhaToten)
    {
        await _service.AtualizarSenhaToten(senhaToten);
        return Ok();
    }
}
