namespace Entities.Models;

public class Clinica : Base
{
    public string CNPJ { get; set; }
    public string RazaoSocial { get; set; }
    public string? Fantasia { get; set; }
    public string InscricaoEstadual { get; set; }
    public string? InscricaoMunicipal { get; set; }
    public bool SimplesNacional { get; set; }
    public string? Logo { get; set; }
}
