using Domain.Interfaces.IAtendimento;
using Domain.InterfacesServices.IAtendimentoService;
using Entities.Models;
using Entities.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class AtendimentoController : ControllerBase
{
    private readonly InterfaceAtendimentoService _service;
    private readonly InterfaceAtendimento _repository;

    public AtendimentoController(InterfaceAtendimentoService service, InterfaceAtendimento repository)
    {
        _service = service;
        _repository = repository;
    }

    [HttpPost("AdicionarAtendimento")]
    [Produces("application/json")]
    public async Task<ActionResult<object>> AdicionarAtendimento(Atendimento atendimento)
    {
        RetornoGenerico<Atendimento> retorno = await _service.AdicionarAtendimento(atendimento);

        if (retorno.Success)
            return Ok(retorno);
        else
            return BadRequest(retorno);
    }

    [HttpPut("AtualizarAtendimento")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarAtendimento(Atendimento Atendimento)
    {
        await _service.AtualizarAtendimento(Atendimento);
        return Ok();
    }

    [HttpGet("ObterAtendimento/{idAtendimento:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<Atendimento>> ObterAtendimento(int idAtendimento) =>
        await _repository.GetEntityById(idAtendimento);


    [HttpGet("ListaAtentedimentoPaciente/{idPaciente:int}")]
    [Produces("application/json")]
    public async Task<object> ListaAtentedimentoPaciente(int idPaciente) => await _repository.ListaAtentedimentoPaciente(idPaciente);
}

