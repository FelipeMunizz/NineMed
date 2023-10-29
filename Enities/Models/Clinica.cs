using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Clinica : Base
{
    public string CNPJ {  get; set; }
    [ForeignKey("Endereco")]
    [Column(Order = 1)]
    public int IdEndereco { get; set; }
    public Endereco Endereco { get; set; }
    public List<Contato> Contatos { get; set; } = new List<Contato>();
}
