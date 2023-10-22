using Domain.Interfaces.ISenhaToten;
using Domain.InterfacesServices;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SenhaTotenController : ControllerBase
{
    private readonly InterfaceSenhaTotenService _service;
    private readonly InterfaceSenhaToten _repository;

    public SenhaTotenController(InterfaceSenhaTotenService service, InterfaceSenhaToten repository)
    {
        _service = service;
        _repository = repository;
    }

    [HttpGet("ListarSenhasToten")]
    [Produces("application/json")]
    public async Task<ActionResult<List<SenhaToten>>> ListarSenhasToten() => await _repository.List();

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

    [HttpDelete("DeletarSenhasTotenDiarias")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarSenhasTotenDiarias()
    {
        await _service.DeletarSenhasTotenDiarias();
        return Ok();
    }
}
