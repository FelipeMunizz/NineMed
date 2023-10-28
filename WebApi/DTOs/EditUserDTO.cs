using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs;

public class EditUserDTO
{
    [Required(ErrorMessage = "Informe email")]
    [EmailAddress]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Informe o Documento (CPF ou CNPJ)")]
    public string? Documento { get; set; }
}
