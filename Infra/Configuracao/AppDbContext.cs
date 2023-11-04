using Entities.Models;
using Helper.Configuracoes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Configuracao;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    #region Models
    public DbSet<SenhaToten> SenhaToten { get; set; }
    public DbSet<Clinica> Clinica { get; set; }
    public DbSet<ConfiguracaoClinica> ConfiguracaoClinica { get; set; }
    public DbSet<ContatoClinica> ContatoClinica { get; set; }
    public DbSet<EnderecoClinica> EnderecoClinica { get; set; }
    public DbSet<ContatoPaciente> ContatoPaciente { get; set; }
    public DbSet<EnderecoPaciente> EnderecoPaciente { get; set; }
    public DbSet<Agendamento> Agendamento { get; set; }
    public DbSet<Convenio> Convenio { get; set; }
    public DbSet<Paciente> Paciente { get; set; }
    public DbSet<PacienteConvenio> PacienteConvenio { get; set; }
    public DbSet<PacienteFamiliar> PacienteFamiliar { get; set; }
    public DbSet<Procedimento> Procedimento { get; set; }
    public DbSet<Funcionario> Funcionario { get; set; }
    public DbSet<HorarioFuncionario> HorarioFuncionario { get; set; }
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
