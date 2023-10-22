using Domain.InterfacesServices;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SenhaTotenController : ControllerBase
{
    private readonly InterfaceSenhaTotenService _service;

    public SenhaTotenController(InterfaceSenhaTotenService service)
    {
        _service = service;
    }

    [HttpPost("AdicionarSenhaToten")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarSenhaToten(SenhaToten senhaToten)
    {
        await _service.AdicionarSenhaToten(senhaToten);
        return Ok();
    }
}
