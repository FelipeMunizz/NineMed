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

    public FuncionarioController(InterfaceFuncionarioService service)
    {
        _service = service;
    }

    [HttpPost("AdicionarFuncionario")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarFuncionario(Funcionario funcionario)
    {
        await _service.AdicionarFuncionario(funcionario);

        return Ok();
    }
}
