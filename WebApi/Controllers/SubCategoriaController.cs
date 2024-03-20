using Domain.InterfacesServices.ISubCategoriaService;
using Entities.Enums;
using Entities.Models;
using Entities.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(AuthenticationSchemes = "Bearer")]
public class SubCategoriaController : ControllerBase
{
    private readonly InterfaceSubCategoriaService _service;

    public SubCategoriaController(InterfaceSubCategoriaService service)
    {
        _service = service;
    }

    [HttpGet("ListarSubCategoriaFinanceiras/{idCategoriaFinanceira:int}")]
    [Produces("application/json")]
    public async Task<object> ListarSubCategoriaFinanceiras(int idCategoriaFinanceira) => await _service.ListarSubCategoriaFinanceiras(idCategoriaFinanceira);

    [HttpGet("ListaSubCategoriaTipo/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListaSubCategoriaTipo(int idClinica, [FromQuery]TipoLancamento tipo) => await _service.ListaSubCategoriaTipo(tipo, idClinica);

    [HttpGet("ObterSubCategoria/{idSubCategoria:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<SubCategoria>> ObterSubCategoria(int idSubCategoria) => await _service.ObterSubCategoria(idSubCategoria);

    [HttpPost("AdicionarSubCategoria")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<SubCategoria>>> AdicionarSubCategoria(SubCategoria SubCategoria) => await _service.AdicionarSubCategoria(SubCategoria);

    [HttpPut("AtualizarSubCategoria")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarSubCategoria(SubCategoria SubCategoria)
    {
        await _service.AtualizarSubCategoria(SubCategoria);

        return Ok();
    }

    [HttpDelete("DeletarSubCategoria/{idSubCategoria:int}")]
    [Produces("application/json")]
    public async Task<RetornoGenerico<object>> DeletarSubCategoria(int idSubCategoria) => await _service.DeletarSubCategoria(idSubCategoria);
}
