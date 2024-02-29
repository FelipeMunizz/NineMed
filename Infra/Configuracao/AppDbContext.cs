using Entities.Models;
using Helper.Configuracoes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Configuracao;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    #region Models
    public DbSet<FormaPagamento> FormaPagamento { get; set; }
    public DbSet<AtendimentoProcedimento> AgendamentoProcedimento { get; set; }
    public DbSet<Toten> Toten { get; set; }
    public DbSet<SenhaToten> SenhaToten { get; set; }
    public DbSet<Clinica> Clinica { get; set; }
    public DbSet<ConfiguracaoClinica> ConfiguracaoClinica { get; set; }
    public DbSet<ContatoClinica> ContatoClinica { get; set; }
    public DbSet<EnderecoClinica> EnderecoClinica { get; set; }
    public DbSet<ContatoPaciente> ContatoPaciente { get; set; }
    public DbSet<EnderecoPaciente> EnderecoPaciente { get; set; }
    public DbSet<Agendamento> Agendamento { get; set; }
    public DbSet<Convenio> Convenio { get; set; }
    public DbSet<PlanosConvenio> PlanosConvenio { get; set; }
    public DbSet<ProfissionaisSaudeConvenio> ProfissionaisSaudeConvenio { get; set; }
    public DbSet<Paciente> Paciente { get; set; }
    public DbSet<PacienteConvenio> PacienteConvenio { get; set; }
    public DbSet<PacienteFamiliar> PacienteFamiliar { get; set; }
    public DbSet<Procedimento> Procedimento { get; set; }
    public DbSet<Funcionario> Funcionario { get; set; }
    public DbSet<HorarioFuncionario> HorarioFuncionario { get; set; }
    public DbSet<Atendimento> Atendimento { get; set; }
    public DbSet<PacienteProntuario> ProntuarioPaciente { get; set; }
    public DbSet<ExameAtendimento> ExameAtendimento { get; set; }
    public DbSet<PrescricaoAtendimento> PrescricaoAtendimento { get; set; }
    public DbSet<AtestadoAtendimento> AtestadoAtendimento { get; set; }
    public DbSet<AnexosAtendimento> AnexosAtendimento { get; set; }
    public DbSet<Banco> Banco { get; set; }
    public DbSet<ContaBancaria> ContaBancaria { get; set; }
    public DbSet<CategoriaFinanceira> CategoriaFinanceira { get; set; }
    public DbSet<SubCategoria> SubCategoria { get; set; }
    public DbSet<CentroCusto> CentroCusto { get; set; }
    public DbSet<ConfiguracaoFinanceira> ConfiguracaoFinanceira { get; set; }
    public DbSet<Lancamento> Lancamento { get; set; }
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
