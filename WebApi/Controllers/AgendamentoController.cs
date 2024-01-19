using Domain.InterfacesServices.IAgendamentoService;
using Entities.Models;
using Entities.Retorno;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers;

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
    public async Task<ActionResult<object>> AdicionarAgendamento(AgendamentoDTO agendamentoDTO)
    {
        List<AgendamentoProcedimento> procedimentos = new List<AgendamentoProcedimento>();
        Agendamento agendamento = new Agendamento
        {
            DataAgendamento = Convert.ToDateTime(agendamentoDTO.DataAgendamento),
            Repeticao = agendamentoDTO.Repeticao,
            Lembrete = agendamentoDTO.Lembrete,
            SituacaoAgendamento = agendamentoDTO.SituacaoAgendamento,
            IdClinica = agendamentoDTO.IdClinica,
            IdFuncionario = agendamentoDTO.IdFuncionario,
            IdPaciente = agendamentoDTO.IdPaciente
        };

        foreach(var item in agendamentoDTO.Procedimentos)
        {
            AgendamentoProcedimento procedimento = new AgendamentoProcedimento
            {
                Quantidade = item.Quantidade,
                IdProcedimento = item.IdProcedimento,
            };
            procedimentos.Add(procedimento);
        }

        return await _service.AdicionarAgendamento(agendamento, procedimentos);
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
    public async Task<object>  ListaAgendamentosFuncionario(int idFuncionario) => await _service.ListaAgendamentosFuncionario(idFuncionario);

    [HttpPost("AdicionarAgendamentoPagamento")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarAgendamentoPagamento(AgendamentoPagamento agendamentoPagamento)
    {
        await _service.AdicionarAgendamentoPagamento(agendamentoPagamento);
        return Ok();
    }

    [HttpPost("AdicionarAgendamentoProcedimento")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarAgendamentoProcedimento(AgendamentoProcedimento agendamentoProcedimento)
    {
        await _service.AdicionarAgendamentoProcedimento(agendamentoProcedimento);
        return Ok();
    }

    [HttpPut("AtualizarAgendamentoPagamento")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarAgendamentoPagamento(AgendamentoPagamento agendamentoPagamento)
    {
        await _service.AtualizarAgendamentoPagamento(agendamentoPagamento);
        return Ok();
    }

    [HttpPut("AtualizarAgendamentoProcedimento")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarAgendamentoProcedimento(AgendamentoProcedimento agendamentoProcedimento)
    {
        await _service.AtualizarAgendamentoProcedimento(agendamentoProcedimento);
        return Ok();
    }

    [HttpDelete("DeletarAgendamentoProcedimento")]
    [Produces("application/json")]
    public async Task<ActionResult<object>> DeletarAgendamentoProcedimento(int idAgendamentoProcedimento) =>
        await _service.DeletarAgendamentoProcedimento(idAgendamentoProcedimento);

    [HttpGet("ListaAgendamentoPagamento/{idPagamento:int}")]
    [Produces("application/json")]
    public async Task<object> ListaAgendamentoPagamento(int idPagamento) =>
        await _service.ListaAgendamentoPagamento(idPagamento);

    [HttpGet("ListaAgendamentoProcedimento/{idProcedimento:int}")]
    [Produces("application/json")]
    public async Task<object> ListaAgendamentoProcedimento(int idProcedimento) =>
        await _service.ListaAgendamentoProcedimento(idProcedimento);

    [HttpGet("ObterAgendamentoPagamento/{idAgendamentoPagamento:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<AgendamentoPagamento>> ObterAgendamentoPagamento(int idAgendamentoPagamento) =>
        await _service.ObterAgendamentoPagamento(idAgendamentoPagamento);

    [HttpGet("ObterAgendamentoProcedimento/{idAgendamentoProcedimento:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<AgendamentoProcedimento>> ObterAgendamentoProcedimento(int idAgendamentoProcedimento) =>
        await _service.ObterAgendamentoProcedimento(idAgendamentoProcedimento);

    [HttpGet("ObterAgendamento/{idAgendamento:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<Agendamento>> ObterAgendamento(int idAgendamento) =>
        await _service.ObterAgendamento(idAgendamento);
}
