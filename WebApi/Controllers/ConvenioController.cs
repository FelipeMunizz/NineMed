using Domain.Interfaces.IConvenio;
using Domain.InterfacesServices.IConvenioService;
using Entities.Models;
using Entities.Retorno;
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
    public async Task<ActionResult<RetornoGenerico<object>>> AdicionarConvenio(Convenio convenio)
    {
        
        RetornoGenerico<Convenio> retorno = await _service.AdicionarConvenio(convenio);

        if (retorno.Success)
            return Ok(retorno);
        else return BadRequest(retorno);
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

    [HttpGet("ListaPlanosConvenio/{idConvenio:int}")]
    [Produces("application/json")]
    public async Task<object> ListaPlanosConvenio(int idConvenio) => await _service.ListaPlanosConvenio(idConvenio);

    [HttpGet("ObterPlanoConvenio/{idPlano:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<PlanosConvenio>> ObtemPlanoConvenio(int idPlano) => await _service.ObtemPlanoConvenio(idPlano);

    [HttpPost("AdicionarPlanoConvenio")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<object>>> AdicionarPlanoConvenio(PlanosConvenio plano) => await _service.AdicionarPlanoConvenio(plano);

    [HttpPut("AtualizarPlanoConvenio")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarPlanoConvenio(PlanosConvenio plano)
    {
        await _service.AtualizarPlanoConvenio(plano);

        return Ok();
    }

    [HttpDelete("DeletarPlanoConvenio/{idPlano:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarPlanoConvenio(int idPlano)
    {
        await _service.DeletarPlanoConvenio(idPlano);
        return Ok();
    }

    [HttpGet("ListaProfissionalSaudesConvenio/{idConvenio:int}")]
    [Produces("application/json")]
    public async Task<object> ListaProfissionalSaudesConvenio(int idConvenio) => await _service.ListaProfissionaisSaudeConvenio(idConvenio);

    [HttpGet("ObterProfissionalSaudeConvenio/{idProfissionalSaude:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<ProfissionaisSaudeConvenio>> ObtemProfissionalSaudeConvenio(int idProfissionalSaude) => await _service.ObtemProfissionalSaudeConvenio(idProfissionalSaude);

    [HttpPost("AdicionarProfissionalSaudeConvenio")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<object>>> AdicionarProfissionalSaudeConvenio(ProfissionaisSaudeConvenio ProfissionalSaude) => await _service.AdicionarProfissionalSaudeConvenio(ProfissionalSaude);

    [HttpPut("AtualizarProfissionalSaudeConvenio")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarProfissionalSaudeConvenio(ProfissionaisSaudeConvenio ProfissionalSaude)
    {
        await _service.AtualizarProfissionalSaudeConvenio(ProfissionalSaude);

        return Ok();
    }

    [HttpDelete("DeletarProfissionalSaudeConvenio/{idProfissionalSaude:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarProfissionalSaudeConvenio(int idProfissionalSaude)
    {
        await _service.DeletarProfissionalSaudeConvenio(idProfissionalSaude);
        return Ok();
    }
}
