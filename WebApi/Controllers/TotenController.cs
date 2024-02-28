using Domain.Interfaces.IToten;
using Domain.InterfacesServices.ITotenService;
using Entities.Models;
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

    [HttpGet("ObterSenhaToten/{idSenha:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<SenhaToten>> ObterSenhaToten(int idSenha) => await _repositorySenhas.GetEntityById(idSenha);

    [HttpGet("ListarSenhasToten")]
    [Produces("application/json")]
    public async Task<ActionResult<List<SenhaToten>>> ListarSenhasToten() => await _repositorySenhas.List();

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

    [HttpPost("AdicionarSenhaToten")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarSenhaToten(SenhaToten senhaToten)
    {
        await _service.AdicionarSenhaToten(senhaToten);
        return Ok();
    }

    [HttpPut("AtualizarSenhaToten")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarSenhaToten(SenhaToten senhaToten)
    {
        await _service.AtualizarSenhaToten(senhaToten);
        return Ok();
    }

    [HttpDelete("DeletarSenhasTotenDiarias/{idToten:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarSenhasTotenDiarias(int idToten)
    {
        await _service.DeletarSenhasTotenDiarias(idToten);
        return Ok();
    }
}
