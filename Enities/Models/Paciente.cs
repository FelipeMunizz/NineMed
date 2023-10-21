using Enities.Enums;

namespace Enities.Models;

public class Paciente
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public DateTime DataNascimento { get; set; }
    public Generos Genero { get; set; }
    public string NumeroProntuario { get; set; }
    public string NumeroTelefone { get; set; }
    public string Email { get; set; }
}
