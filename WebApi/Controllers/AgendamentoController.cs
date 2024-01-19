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
}
