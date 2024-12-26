using Entities.Enums;

namespace Entities.ModelsReports;

public class AtestadoModelReport
{
    public string NomeFuncionario { get; set; }
    public string NomeEmpresa { get; set; }
    public string NomePaciente { get; set; }
    public DateTime DataInicial { get; set; }
    public DateTime DataFinal { get; set; }
    public string Descricao { get; set; }
    public string CRM { get; set; }
    public EstadosBrasil UF { get; set; }
    public string Endereco { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Telefone { get; set; }
    public DateTime DataEmissao { get; set; } = DateTime.Now;
    public byte[] LogoEmpresa { get; set; }
}
