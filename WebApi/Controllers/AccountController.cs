using Domain.InterfacesServices.IFuncionarioService;
using Entities.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Token;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _user;
    private readonly SignInManager<ApplicationUser> _sign;
    private readonly InterfaceFuncionarioService _funcionarioService;

    public AccountController(UserManager<ApplicationUser> user, SignInManager<ApplicationUser> sign, InterfaceFuncionarioService funcionarioService)
    {
        _user = user;
        _sign = sign;
        _funcionarioService = funcionarioService;
    }

    [AllowAnonymous]
    [Produces("application/json")]
    [HttpPost("CreateToken")]
    public async Task<object> CreateToken([FromBody] LoginUserDTO model)
    {
        var result = await _sign.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            var token = new TokenJwtBuilder()
                .AddSecurityKey(JwtSecurityKey.Create("NineMed_Secret_Key-20232004"))
                .AddSubject("Nine Med v1")
                .AddIssuer("NineMed.Security.Bearer")
                .AddAudience("NineMed.Security.Bearer")
                .AddClaim("UsuarioEmail", model.Username)
                .AddExpiry(60)
                .Builder();

            Funcionario funcionario = await _funcionarioService.ObterFuncionarioEmail(model.Username);

            return new RetornoToken
            {
                Token = token.value,
                User = model.Username,
                Nome = funcionario.Nome,
                Role = funcionario.Perfil.ToString(),
                IdFuncionario = funcionario.Id,
                IdClinica = funcionario.IdClinica
            };
        }
        else
            return Unauthorized();
    }
}

public class RetornoToken
{
    public int IdFuncionario {  get; set; }
    public string Token { get; set; }
    public string Nome { get; set; }
    public string User { get; set; }
    public string Role { get; set; }
    public int IdClinica { get; set; }
}