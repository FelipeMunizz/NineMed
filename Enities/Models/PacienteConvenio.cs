namespace Entities.Models;

public class PacienteConvenio
{
    public int Id { get; set; }
    public string NumeroCarterinha { get; set; }
    public DateTime Validade { get; set; }
    public string ContratoPlano { get; set; }
    public string Observacoes { get; set; }
    public int IdConvenio { get; set; }
}
