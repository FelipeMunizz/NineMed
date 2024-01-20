using Domain.Interfaces.IConvenio;
using Domain.InterfacesServices.IConvenioService;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class ConvenioController : ControllerBase
{
    private readonly InterfaceConvenioService _service;
    private readonly InterfaceConvenio _repository;

    public ConvenioController(InterfaceConvenioService service, InterfaceConvenio repository)
    {
        _service = service;
        _repository = repository;
    }

    [HttpGet("ListarConveniosClinica/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListarConveniosClinica(int idClinica) => await _repository.ListaConveniosClinica(idClinica);

    [HttpGet("ObterConvenio/{idConvenio:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<Convenio>> ObterConvenio(int idConvenio) => await _repository.GetEntityById(idConvenio);

    [HttpPost("AdicionarConvenio")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarConvenio(Convenio convenio)
    {
        await _service.AdicionarConvenio(convenio);

        return Ok();
    }

    [HttpPut("AtualizarConvenio")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarConvenio(Convenio convenio)
    {
        await _service.AtualizarConvenio(convenio);

        return Ok();
    }

    [HttpDelete("DeletarConvenio/{idConvenio:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarConvenio(int idConvenio)
    {
        await _service.DeletarConvenio(idConvenio);
        return Ok();
    }
}
