using Domain.Interfaces.Generics;
using Domain.Interfaces.IClinica;
using Domain.Interfaces.IFuncionario;
using Domain.Interfaces.ISenhaToten;
using Domain.InterfacesServices;
using Domain.InterfacesServices.IClinicaService;
using Domain.InterfacesServices.IFuncionarioService;
using Domain.Servicos;
using Entities.Models;
using Helper.Configuracoes;
using Infra.Configuracao;
using Infra.Repositorio;
using Infra.Repositorio.ClinicaRepositorio;
using Infra.Repositorio.FuncionarioRepositorio;
using Infra.Repositorio.Generico;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi.Token;

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
builder.Services.AddScoped<InterfaceSenhaToten, SenhaTotenRepository>();
builder.Services.AddScoped<InterfaceClinica, ClinicaRepository>();
builder.Services.AddScoped<InterfaceContatoClinica, ContatoClinicaRepository>();
builder.Services.AddScoped<InterfaceEnderecoClinica, EnderecoClinicaRepository>();
builder.Services.AddScoped<InterfaceFuncionario, FuncionarioRepository>();
#endregion

#region Servicos
builder.Services.AddScoped<InterfaceSenhaTotenService, SenhaTotenService>();
builder.Services.AddScoped<InterfaceClinicaService, ClinicaService>();
builder.Services.AddScoped<InterfaceFuncionarioService, FuncionarioService>();
#endregion

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
                        IssuerSigningKey = JwtSecurityKey.Create("NineMed_Secret_Key-20232004")
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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
