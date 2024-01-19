using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs;

public class LoginUserDTO
{
    [Required(ErrorMessage = "Informe email")]
    [EmailAddress]
    public string? Username { get; set; }
    [Required(ErrorMessage = "Informe senha")]
    public string? Password { get; set; }
}
