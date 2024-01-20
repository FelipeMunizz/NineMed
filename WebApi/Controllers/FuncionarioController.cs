using Domain.Interfaces.IFuncionario;
using Domain.InterfacesServices.IFuncionarioService;
using Entities.Models;
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

    [HttpGet("ObterFuncionario/{idFuncionario:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<Funcionario>> ObterFuncionario(int idFuncionario) => await _service.ObterFuncionario(idFuncionario);

    [HttpPost("AdicionarFuncionario")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarFuncionario(Funcionario funcionario)
    {
        await _service.AdicionarFuncionario(funcionario);

        return Ok();
    }

    [HttpPut("AtualizarFuncionario")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarFuncionario(Funcionario funcionario)
    {
        await _service.AtualizarFuncionario(funcionario);

        return Ok();
    }

    [HttpDelete("DeletarFuncionario/{idFuncionario:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarFuncionario(int idFuncionario)
    {
        await _service.DeletarFuncionario(idFuncionario);
        return Ok();
    }
}
