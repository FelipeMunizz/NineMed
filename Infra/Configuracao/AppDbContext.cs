using Enities.Models;
using Helper.Configuracoes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Infra.Configuracao;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    #region Models
    public DbSet<SenhaToten> SenhaToten { get; set; }
    #endregion

    #region Metodos Override
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Config.ConectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

        base.OnModelCreating(builder);
    }
    #endregion
}
