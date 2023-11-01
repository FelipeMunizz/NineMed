using Microsoft.AspNetCore.Identity;

namespace Entities.Models;
public class ApplicationUser : IdentityUser
{
    public string Documento { get; set; }
}