using Domain.Interfaces.IProcedimento;
using Domain.InterfacesServices.IProcedimentoService;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace WebApi.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class ProcedimentoController : ControllerBase
{
    private readonly InterfaceProcedimento _repository;
    private readonly InterfaceProcedimentoService _service;

    public ProcedimentoController(InterfaceProcedimento repository, InterfaceProcedimentoService service)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet("ListaProcedimentoClinica/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListaProcedimentoClinica(int idClinica) => await _repository.ListaProcedimentoClinica(idClinica);

    [HttpGet("ObterProcedimento/{idProcedimento:int}")]
    public async Task<ActionResult<Procedimento>> ObterProcedimento(int idProcedimento) => await _repository.GetEntityById(idProcedimento);

    [HttpPost("AdicionarProcedimento")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarProcedimento(Procedimento procedimento)
    {
        await _service.AdicionarProcedimento(procedimento);
        return Ok();
    }

    [HttpPut("EditarProcedimento")]
    [Produces("application/json")]
    public async Task<IActionResult> EditarProcedimento(Procedimento procedimento)
    {
        await _service.EditarProcedimento(procedimento);
        return Ok();
    }

    [HttpDelete("DeletarProcedimento/{idProcedimento:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarProcedimento(int idProcedimento)
    {
        await _service.ExcluirProcedimento(idProcedimento); 
        return Ok();
    }
}
