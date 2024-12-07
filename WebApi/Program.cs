#region References
using Domain.IIntegracao;
using Domain.Interfaces.Generics;
using Domain.Interfaces.IAgendamento;
using Domain.Interfaces.IAtendimento;
using Domain.Interfaces.IBanco;
using Domain.Interfaces.ICategoriaFinanceira;
using Domain.Interfaces.ICentroCusto;
using Domain.Interfaces.IClinica;
using Domain.Interfaces.IConfiguracaoClinica;
using Domain.Interfaces.IConfiguracaoFinanceira;
using Domain.Interfaces.IContaBancaria;
using Domain.Interfaces.IConvenio;
using Domain.Interfaces.IFormaPagamento;
using Domain.Interfaces.IFuncionario;
using Domain.Interfaces.ILancamento;
using Domain.Interfaces.IPaciente;
using Domain.Interfaces.IProcedimento;
using Domain.Interfaces.ISubCategoria;
using Domain.Interfaces.IToten;
using Domain.InterfacesServices.IAgendamentoService;
using Domain.InterfacesServices.IAtendimentoService;
using Domain.InterfacesServices.IBancoService;
using Domain.InterfacesServices.ICategoriaFinanceiraService;
using Domain.InterfacesServices.ICentroCustoService;
using Domain.InterfacesServices.IClinicaService;
using Domain.InterfacesServices.IConfiguracaoClinicaService;
using Domain.InterfacesServices.IConfiguracaoFinanceiraService;
using Domain.InterfacesServices.IContaBancariaService;
using Domain.InterfacesServices.IConvenioService;
using Domain.InterfacesServices.IFormaPagamentoService;
using Domain.InterfacesServices.IFuncionarioService;
using Domain.InterfacesServices.ILancamentoService;
using Domain.InterfacesServices.IPacienteService;
using Domain.InterfacesServices.IProcedimentoService;
using Domain.InterfacesServices.ISubCategoriaService;
using Domain.InterfacesServices.ITotenService;
using Domain.Servicos;
using Entities.Models;
using Helper.Configuracoes;
using Infra.Configuracao;
using Infra.Repositorio.AgendamentoRepositorio;
using Infra.Repositorio.AtendimentoRepositorio;
using Infra.Repositorio.BancoRepositorio;
using Infra.Repositorio.CategoriaFinanceiraRepository;
using Infra.Repositorio.CentroCustoRepositorio;
using Infra.Repositorio.ClinicaRepositorio;
using Infra.Repositorio.ConfiguracaoClinicaRepositorio;
using Infra.Repositorio.ConfiguracaoFinanceiraRepositorio;
using Infra.Repositorio.ContaBancariaRepositorio;
using Infra.Repositorio.ConvenioRepositorio;
using Infra.Repositorio.FormaPagamentoRepositorio;
using Infra.Repositorio.FuncionarioRepositorio;
using Infra.Repositorio.Generico;
using Infra.Repositorio.LancamentoRepositorio;
using Infra.Repositorio.PacienteRepositorio;
using Infra.Repositorio.ProcedimentoRepositorio;
using Infra.Repositorio.SubCategoriaRepositorio;
using Infra.Repositorio.TotenRepositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi.Token;
#endregion

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(Config.ConectionString));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();

#region Repositorios
builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositorioGenerico<>));
builder.Services.AddScoped<InterfaceToten, TotenRepository>();
builder.Services.AddScoped<InterfaceSenhaToten, SenhaTotenRepository>();

#region Convenio
builder.Services.AddScoped<InterfaceConvenio, ConvenioRepository>();
builder.Services.AddScoped<InterfacePlanosConvenio, PlanosConvenioRepository>();
builder.Services.AddScoped<InterfaceProfissionalSaudeConvenio, ProfissionalSaudeConvenioRepository>();
#endregion

#region Clinica
builder.Services.AddScoped<InterfaceClinica, ClinicaRepository>();
builder.Services.AddScoped<InterfaceContatoClinica, ContatoClinicaRepository>();
builder.Services.AddScoped<InterfaceEnderecoClinica, EnderecoClinicaRepository>();
#endregion

#region Paciente
builder.Services.AddScoped<InterfacePaciente, PacienteRepository>();
builder.Services.AddScoped<InterfacePacienteContato, PacienteContatoRepository>();
builder.Services.AddScoped<InterfacePacienteConvenio, PacienteConvenioRepository>();
builder.Services.AddScoped<InterfacePacienteEndereco, PacienteEnderecoRepository>();
builder.Services.AddScoped<InterfacePacienteFamiliar, PacienteFamiliarRepoistory>();
builder.Services.AddScoped<InterfacePacienteProntuario, PacienteProntuarioRepository>();
#endregion

#region Agendamento
builder.Services.AddScoped<InterfaceAgendamento, AgendamentoRepository>();
#endregion

#region Atendimento
builder.Services.AddScoped<InterfaceAtendimento, AtendimentoRepository>();
builder.Services.AddScoped<InterfaceExameAtendimento, ExamesAtendimentoRepository>();
builder.Services.AddScoped<InterfacePrescricaoAtendimento, PrescricaoAtendimentoRepository>();
builder.Services.AddScoped<InterfaceAnexosAtendimento, AnexosAtendimentoRepository>();
builder.Services.AddScoped<InterfaceAtestadoAtendimento, AtestadoAtendimentoRepository>();
#endregion

builder.Services.AddScoped<InterfaceFuncionario, FuncionarioRepository>();
builder.Services.AddScoped<InterfaceHorarioFuncionario, HorarioFuncionarioRepository>();
builder.Services.AddScoped<InterfaceProcedimento, ProcedimentoRepository>();
builder.Services.AddScoped<InterfaceConfiguracaoClinica, ConfiguracaoClinicaRepository>();
builder.Services.AddScoped<IBanco, BancoRepository>();
builder.Services.AddScoped<InterfaceContaBancaria, ContaBancariaRepository>();
builder.Services.AddScoped<InterfaceSubCategoria, SubCategoriaRepository>();
builder.Services.AddScoped<InterfaceCentroCusto, CentroCustoRepository>();
builder.Services.AddScoped<InterfaceConfiguracaoFinanceira, ConfiguracaoFinanceiraRepository>();
builder.Services.AddScoped<InterfaceLancamento, LancamentoRepository>();
builder.Services.AddScoped<InterfaceCategoriaFinanceira, CategoriaFinanceiraRepository>();
builder.Services.AddScoped<InterfaceFormaPagamento, FormaPagamentoRepository>();
#endregion

#region Servicos
builder.Services.AddScoped<InterfaceTotenService, TotenService>();
builder.Services.AddScoped<InterfaceClinicaService, ClinicaService>();
builder.Services.AddScoped<InterfaceConvenioService, ConvenioService>();
builder.Services.AddScoped<InterfaceFuncionarioService, FuncionarioService>();
builder.Services.AddScoped<InterfaceProcedimentoService, ProcedimentoService>();
builder.Services.AddScoped<InterfacePacienteService, PacienteService>();
builder.Services.AddScoped<InterfaceConfiguracaoClinicaService, ConfiguracaoClinicaService>();
builder.Services.AddScoped<InterfaceAgendamentoService, AgendamentoService>();
builder.Services.AddScoped<InterfaceAtendimentoService, AtendimentoService>();
builder.Services.AddScoped<InterfaceBancoService, BancoService>();
builder.Services.AddScoped<InterfaceContaBancariaService, ContaBancariaService>();
builder.Services.AddScoped<InterfaceSubCategoriaService, SubCategoriaService>();
builder.Services.AddScoped<InterfaceCentroCustoService, CentroCustoService>();
builder.Services.AddScoped<InterfaceConfiguracaoFinanceiraService, ConfiguracaoFinanceiraService>();
builder.Services.AddScoped<InterfaceLancamentoService, LancamentoService>();
builder.Services.AddScoped<InterfaceCategoriaFinanceiraService, CategoriaFinanceiraService>();
builder.Services.AddScoped<InterfaceFormaPagamentoService, FormaPagamentoService>();
#endregion

//builder.Services.AddSingleton(new RabbitMqService("fila_senhas"));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NineMed", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Header de autorização JWT usando o esquema Bearer.\r\n\r\nInforme 'Bearer'[espaço] e o seu token.\r\n\r\nExemplo \'Bearer 12345abcdef\'",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });

});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "NineMed.Security.Bearer",
                        ValidAudience = "NineMed.Security.Bearer",
                        IssuerSigningKey = JwtSecurityKey.Create(Config.SecurityKey)
                    };

                    option.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                            return Task.CompletedTask;
                        },

                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };
                });

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


//builder.WebHost.UseUrls("http://0.0.0.0:5000");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
