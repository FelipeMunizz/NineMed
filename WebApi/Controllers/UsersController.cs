using Entities.Models;
using Entities.Users;
using Helper.Logs;
using Helper.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _user;
    private readonly SignInManager<ApplicationUser> _sign;

    public UsersController(UserManager<ApplicationUser> user, SignInManager<ApplicationUser> sign)
    {
        _user = user;
        _sign = sign;
    }

    [AllowAnonymous]
    [Produces("application/json")]
    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] RegisterUserDTO login)
    {
        ApplicationUser user = new ApplicationUser
        {
            Email = login.Email,
            UserName = login.Email,
            Documento = login.Documento
        };

        if (!await ValidaDocumento(login.Documento))
            return BadRequest("Documento inválido");

        var res = await _user.FindByEmailAsync(login.Email);

        if (res != null)
            return BadRequest("Email já cadastrado");

        IdentityResult result = await _user.CreateAsync(user, login.Password);

        if (result.Errors.Any())
        {
            return BadRequest(result.Errors);
        }

        // Autenticacao dois fatores por email
        string code = await _user.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        //retorno do email
        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

        var responseRetorn = await _user.ConfirmEmailAsync(user, code);
        if (responseRetorn.Succeeded)
            return Ok("Usuario Adicionado");
        else
            return BadRequest("Erro ao confirmar cadastro");
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Produces("application/json")]
    [HttpPut("EditUser/{id}")]
    public async Task<IActionResult> EditUser(string id, [FromBody] RegisterUserDTO login)
    {
        var user = await _user.FindByIdAsync(id);

        if (user == null)
            return BadRequest("Usuario não encontrado");

        user.Email = login.Email;
        user.UserName = login.Email;
        user.Documento = login.Documento;

        var result = await _user.UpdateAsync(user);

        if (result.Succeeded)
        {
            return Ok("Usuário atualizado com sucesso.");
        }
        else
            return BadRequest("Erro ao atualizar usuário.");
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("ObterUsuario")]
    [Produces("application/json")]
    public async Task<ActionResult<object>> ObterUsuario([FromQuery]string email) => await _user.FindByEmailAsync(email);


    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpDelete("DeletarUsuario")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarUsuario(string id)
    {
        var user = await _user.FindByIdAsync(id);
        if (user == null) return BadRequest();

        await _user.DeleteAsync(user);
        return Ok();
    }

    private async Task<bool> ValidaDocumento(string documento)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string tipoDocumento = documento.Length > 11 ? "cnpj" : "cpf";
                string apiUrl = $"https://api.invertexto.com/v1/validator?token={ApiInvertexto.Token}&value={documento}&type={tipoDocumento}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Analisar a resposta da API para determinar se o documento é válido
                    string responseBody = await response.Content.ReadAsStringAsync();
                    ValidaDocumento resultado = JsonConvert.DeserializeObject<ValidaDocumento>(responseBody);
                    if (resultado.Valid)
                        return true;
                    else
                        return false;
                }
                else
                {
                    LogProxy.GravarLogErro("Erro Api InverTexto",$"Erro na chamada à API: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            LogProxy.GravarLogException(ex);
        }

        return false; // Retornar false por padrão em caso de erro
    }
}

public class ValidaDocumento
{
    public bool Valid { get; set; }
    public string Formatted { get; set; }
}