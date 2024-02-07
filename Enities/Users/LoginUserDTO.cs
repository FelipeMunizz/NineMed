using System.ComponentModel.DataAnnotations;

namespace Entities.Users;

public class LoginUserDTO
{
    [Required(ErrorMessage = "Informe email")]
    [EmailAddress]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Informe senha")]
    public string? Password { get; set; }
}
