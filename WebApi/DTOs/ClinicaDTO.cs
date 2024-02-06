using Entities.Enums;

namespace WebApi.DTOs;

public class ClinicaDTO
{
    public string CNPJ { get; set; }
    public string RazaoSocial { get; set; }
    public string? Fantasia { get; set; }
    public string InscricaoEstadual { get; set; }
    public string? InscricaoMunicipal { get; set; }
    public bool SimplesNacional { get; set; }
    public string? Logo { get; set; }
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string? CEP { get; set; }
    public EstadosBrasil Estado { get; set; }
    public string? Cidade { get; set; }
    public string? CodMunicipio { get; set; }   
    public string? NomeContato { get; set; }
    public string? NumeroContato { get; set; }
    public string? Email { get; set; }
    public TipoContato TipoContato { get; set; }
    public bool HorarioComercial { get; set; }
    public bool Lembretes { get; set; }
}
