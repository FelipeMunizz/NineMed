using Entities.Enums;
using Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.DTOs;

public class AgendamentoDTO
{
    public int Id { get; set; }
    public string DataAgendamento { get; set; }
    public RepeticaoAgendamento Repeticao { get; set; }
    public SituacaoAgendamento SituacaoAgendamento { get; set; }
    public bool Lembrete { get; set; }
    public string? Observacao { get; set; }
    public int IdClinica { get; set; }
    public int IdPaciente { get; set; }
    public int IdFuncionario { get; set; }
    public List<AgendamentoProcedimentoDTO> Procedimentos { get; set; }
}

public class AgendamentoProcedimentoDTO
{
    public int Quantidade { get; set; }
    public int IdProcedimento { get; set; }
}