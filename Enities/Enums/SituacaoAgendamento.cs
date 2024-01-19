namespace Entities.Enums;

public enum SituacaoAgendamento
{
    AguardandoConfirmacao,
    Confirmado,
    PacienteCompareceu,
    PacienteNaoCompareceu,
    Cancelado = 99
}

public enum SituacaoAgendamentoPagamento
{
    EmAberto,
    PagoParcial,
    PagoTotal,
    Cancelado
}
