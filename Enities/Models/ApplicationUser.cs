using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;
public class ApplicationUser : IdentityUser
{
    [Column("USR_DOCUMENTO")]
    public string Documento { get; set; }
}