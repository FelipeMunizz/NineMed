using Domain.Interfaces.IFuncionario;
using Domain.InterfacesServices.IFuncionarioService;
using Entities.Models;
using Entities.Retorno;
using Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly InterfaceFuncionarioService _service;
    private readonly InterfaceFuncionario _repository;

    public FuncionarioController(InterfaceFuncionarioService service, InterfaceFuncionario repository)
    {
        _service = service;
        _repository = repository;
    }

    [HttpGet("ListarFuncionarios/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListarFuncionariosClinica(int idClinica) => await _repository.ListarFuncionariosClinica(idClinica);

    [HttpGet("ListarProfissionaisSaude/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListarProfissionaisSaude(int idClinica) => await _repository.ListarProfissionaisSaude(idClinica);

    [HttpGet("ObterFuncionario/{idFuncionario:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<Funcionario>> ObterFuncionario(int idFuncionario) => await _service.ObterFuncionario(idFuncionario);

    [HttpGet("ObterFuncionarioEmail")]
    [Produces("application/json")]
    public async Task<ActionResult<Funcionario>> ObterFuncionarioEmail(string email) => await _service.ObterFuncionarioEmail(email);

    [HttpPost("AdicionarFuncionario")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<Funcionario>>> AdicionarFuncionario(Funcionario funcionario)
    {
        RetornoGenerico<Funcionario> retorno = await _service.AdicionarFuncionario(funcionario);

        if (retorno.Success)
            return Ok(retorno);

        return BadRequest(retorno);
    }

    [HttpPut("AtualizarFuncionario")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarFuncionario(Funcionario funcionario)
    {
        await _service.AtualizarFuncionario(funcionario);

        return Ok();
    }

    [HttpPut("AtualizarSenhaFuncionario")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<bool>>> AtualizarSenhaFuncionario(LoginUserDTO loginUser)
    {
        RetornoGenerico<bool> retorno = await _service.AtualizarSenhaFuncionario(loginUser);

        if(retorno.Success) 
            return Ok(retorno); 
        
        return BadRequest(retorno);
    }

    [HttpDelete("DeletarFuncionario/{idFuncionario:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarFuncionario(int idFuncionario)
    {
        await _service.DeletarFuncionario(idFuncionario);
        return Ok();
    }
}
