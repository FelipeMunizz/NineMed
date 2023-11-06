using Domain.Interfaces.IClinica;
using Domain.InterfacesServices;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

//[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class ClinicaController : ControllerBase
{
    private readonly InterfaceClinica _repository;
    private readonly InterfaceClinicaService _service;

    public ClinicaController(InterfaceClinica repository, InterfaceClinicaService service)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet("ListaClinicasUsuario")]
    [Produces("application/json")]
    public async Task<object> ListaClinicasUsuario(string email) => await _repository.ListaClinicasUsuario(email);

    [HttpGet("ObterClinica/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<Clinica>> ObterClinca(int idClinica) => await _repository.GetEntityById(idClinica);

    [HttpPost("AdicionarClinica")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarClinica(Clinica clinica)
    {
        await _repository.Add(clinica);
        return Ok();
    }

    [HttpPut("AtualizarClinica")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarClinica(Clinica clinica)
    {
        await _repository.Update(clinica);
        return Ok();
    }

    [HttpDelete("DeletarClinica/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarClinica(int idClinica)
    {
        try
        {
            var clinica = await _repository.GetEntityById(idClinica);
            await _repository.Delete(clinica);
            return Ok(true);
        }
        catch (Exception)
        {
            return BadRequest(false);
        }
    }
}
