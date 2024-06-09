using Domain.InterfacesServices.IFuncionarioService;
using Entities.Models;
using Entities.Retorno;
using Entities.Users;
using Helper.Configuracoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        var result = await _sign.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            var token = new TokenJwtBuilder()
                .AddSecurityKey(JwtSecurityKey.Create(Config.SecurityKey))
                .AddSubject("Nine Med v1")
                .AddIssuer("NineMed.Security.Bearer")
                .AddAudience("NineMed.Security.Bearer")
                .AddClaim("UsuarioEmail", model.Email)
                .AddExpiry(1440)
                .Builder();

            return new RetornoToken
            {
                Token = token.value,
                Email = model.Email
            };
        }
        else
            return Unauthorized();
    }
}
