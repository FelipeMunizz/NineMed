using Domain.InterfacesServices.IAgendamentoService;
using Entities.Models;
using Entities.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class AgendamentoController : ControllerBase
{
    private readonly InterfaceAgendamentoService _service;

    public AgendamentoController(InterfaceAgendamentoService service)
    {
        _service = service;
    }

    [HttpPost("AdicionarAgendamento")]
    [Produces("application/json")]
    public async Task<ActionResult<object>> AdicionarAgendamento(Agendamento agendamento)
    {
        RetornoGenerico<Agendamento> retorno = await _service.AdicionarAgendamento(agendamento);

        if (retorno.Success)
            return Ok(retorno);
        else
            return BadRequest(retorno);
    }

    [HttpPut("ConfirmarAgendamento/{idAgendamento:int}")]
    [Produces("application/json")]
    public async Task<object> ConfirmarAgendamento(int idAgendamento)
    {
        RetornoGenerico<Agendamento> retorno = await _service.ConfirmarAgendamento(idAgendamento);

        if (retorno.Success)
            return Ok(retorno);
        else
            return BadRequest(retorno);
    }

    [HttpPut("AtualizarAgendamento")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarAgendamento(Agendamento agendamento)
    {
        await _service.AtualizarAgendamento(agendamento);
        return Ok();
    }

    [HttpGet("ListaAgendamentoPaciente/{idPaciente:int}")]
    [Produces("application/json")]
    public async Task<object> ListaAgendamentoPaciente(int idPaciente) => await _service.ListaAgendamentosPaciente(idPaciente);

    [HttpGet("ListaAgendamentosClinica/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListaAgendamentosClinica(int idClinica) => await _service.ListaAgendamentosClinica(idClinica);

    [HttpGet("ListaAgendamentosDia/{idClinica:int}/{dia:datetime}")]
    [Produces("application/json")]
    public async Task<object> ListaAgendamentosDia(int idClinica, DateTime dia) => await _service.ListaAgendamentosDia(idClinica, dia);

    [HttpGet("ListaAgendamentosFuncionario/{idFuncionario:int}")]
    [Produces("application/json")]
    public async Task<object> ListaAgendamentosFuncionario(int idFuncionario) => await _service.ListaAgendamentosFuncionario(idFuncionario);

    [HttpGet("ObterAgendamento/{idAgendamento:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<Agendamento>> ObterAgendamento(int idAgendamento) =>
        await _service.ObterAgendamento(idAgendamento);

    [HttpGet("GraficoAgendamento/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<object>>> GraficoAgendamento(int idClinica) => 
        await _service.GraficoAgendamento(idClinica);

    [HttpGet("AgendamentoPacienteDiario/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<object>>> AgendamentoPacienteDiario(int idClinica) =>
        await _service.AgendamentoPacienteDiario(idClinica);

    [HttpGet("AgendamentosAtendimento/{idFuncionario:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<object>>> AgendamentosAtendimento(int idFuncionario) =>
        await _service.AgendamentosAtendimento(idFuncionario);
}
