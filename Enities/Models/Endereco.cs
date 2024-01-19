using Entities.Enums;

namespace Entities.Models;

public class Endereco
{
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string? CEP { get; set; }
    public string? CodMunicipio { get; set; }
    public EstadosBrasil Estado { get; set; }
    public string? Cidade { get; set; }
}
