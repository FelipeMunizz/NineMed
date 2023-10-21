using Domain.Interfaces.Generics;
using Domain.Interfaces.ISenhaToten;
using Domain.InterfacesServices;
using Domain.Servicos;
using Enities.Models;
using Helper.Configuracoes;
using Infra.Configuracao;
using Infra.Repositorio;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

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
#endregion

#region Servicos
builder.Services.AddScoped<InterfaceSenhaTotenService, SenhaTotenService>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
