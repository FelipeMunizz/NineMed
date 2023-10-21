using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enities.Models;
public class ApplicationUser : IdentityUser
{
    [Column("USR_CPF")]
    public string? CPF { get; set; }
}