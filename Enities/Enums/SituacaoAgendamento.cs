using System.ComponentModel;

namespace Entities.Enums;

public enum SituacaoAgendamento
{
    [Description("Aguardando Confirmação")]
    AguardandoConfirmacao,
    Confirmado,
    Cancelado = 99
}
