using Entities.Enums;

namespace WebApi.DTOs;

public class PacienteDTO
{
    public int IdClinica { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public EstadoCivil EstadoCivil { get; set; }
    public string? RG { get; set; }
    public string? CPF { get; set; }
    public string? Profissao { get; set; }
    public string? NomeContato { get; set; }
    public string? NumeroContato { get; set; }
    public string? Email { get; set; }
    public TipoContato TipoContato { get; set; }
    public bool HorarioComercial { get; set; }
    public bool Lembretes { get; set; }
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string? CEP { get; set; }
    public EstadosBrasil Estado { get; set; }
    public string? Cidade { get; set; }
    public string NumeroCarterinha { get; set; }
    public DateTime Validade { get; set; }
    public string ContratoPlano { get; set; }
    public string Observacoes { get; set; }
    public int IdConvenio { get; set; }
    public string NomeFamiliar { get; set; }
    public string GrauParentesco { get; set; }
    public string TelefoneFamiliar { get; set; }
}
