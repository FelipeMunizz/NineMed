using System.ComponentModel.DataAnnotations;

namespace Entities.Users;

public class RegisterUserDTO
{
    [Required(ErrorMessage = "Informe email")]
    [EmailAddress]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Informe senha")]
    public string? Password { get; set; }
    [Required(ErrorMessage = "Informe o Documento (CPF ou CNPJ)")]
    public string? Documento { get; set; }
}
