using Domain.InterfacesServices.ICategoriaFinanceiraService;
using Entities.Models;
using Entities.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class CategoriaFinanceiraController : ControllerBase
{
    private readonly InterfaceCategoriaFinanceiraService _service;

    public CategoriaFinanceiraController(InterfaceCategoriaFinanceiraService service)
    {
        _service = service;
    }

    [HttpGet("ListarCategoriasFinanceiraClinica/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListarCategoriasFinanceiraClinica(int idClinica) => await _service.ListarCategoriasFinanceiraClinica(idClinica);

    [HttpGet("ObterCategoriaFinanceira/{idCategoriaFinanceira:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<CategoriaFinanceira>> ObterCategoriaFinanceira(int idCategoriaFinanceira) => await _service.ObterCategoriaFinanceira(idCategoriaFinanceira);

    [HttpPost("AdicionarCategoriaFinanceira")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<CategoriaFinanceira>>> AdicionarCategoriaFinanceira(CategoriaFinanceira categoriaFinanceira) => await _service.AdicionarCategoriaFinanceira(categoriaFinanceira);

    [HttpPut("AtualizarCategoriaFinanceira")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarCategoriaFinanceira(CategoriaFinanceira categoriaFinanceira)
    {
        await _service.AtualizarCategoriaFinanceira(categoriaFinanceira);

        return Ok();
    }

    [HttpDelete("DeletarCategoriaFinanceira/{idCategoriaFinanceira:int}")]
    [Produces("application/json")]
    public async Task<RetornoGenerico<object>> DeletarCategoriaFinanceira(int idCategoriaFinanceira) => await _service.DeletarCategoriaFinanceira(idCategoriaFinanceira);
}
