using Domain.Interfaces.IAtendimento;
using Domain.InterfacesServices.IAtendimentoService;
using Entities.Models;
using Entities.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApi.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class AtendimentoController : ControllerBase
{
    private readonly InterfaceAtendimentoService _service;
    private readonly InterfaceAtendimento _repository;

    public AtendimentoController(InterfaceAtendimentoService service, InterfaceAtendimento repository)
    {
        _service = service;
        _repository = repository;
    }

    #region Atendimento
    [HttpPost("AdicionarAtendimento")]
    [Produces("application/json")]
    public async Task<ActionResult<object>> AdicionarAtendimento(Atendimento atendimento)
    {
        RetornoGenerico<Atendimento> retorno = await _service.AdicionarAtendimento(atendimento);

        if (retorno.Success)
            return Ok(retorno);
        else
            return BadRequest(retorno);
    }

    [HttpPut("AtualizarAtendimento")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarAtendimento(Atendimento Atendimento)
    {
        await _service.AtualizarAtendimento(Atendimento);
        return Ok();
    }

    [HttpGet("ObterAtendimento/{idAtendimento:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<Atendimento>> ObterAtendimento(int idAtendimento) =>
        await _repository.GetEntityById(idAtendimento);


    [HttpGet("ListaAtentedimentoPaciente/{idPaciente:int}")]
    [Produces("application/json")]
    public async Task<object> ListaAtentedimentoPaciente(int idPaciente) => await _repository.ListaAtentedimentoPaciente(idPaciente);

    [HttpGet("GraficoAtendimentosMensal/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<object>>> GraficoAtendimentosMensal(int idClinica) =>
        await _service.GraficoAtendimentosMensal(idClinica);

    [HttpGet("EvolucaoProntuarioByIdPaciente/{idPaciente:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<RetornoGenerico<object>>> EvolucaoProntuarioByIdPaciente(int idPaciente) =>
        await _service.EvolucaoProntuarioByIdPaciente(idPaciente);
    #endregion

    #region Exames
    [HttpGet("ObterExameAtendimento/{idExame:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<ExameAtendimento>> ObterExameAtendimento(int idExame) =>
        await _service.ObterExameAtendimento(idExame);

    [HttpGet("ListaExamesAtentedimento/{idAtendimento:int}")]
    [Produces("application/json")]
    public async Task<object> ListaExamesAtentedimento(int idAtendimento) =>
        await _service.ListarExamesAtendimento(idAtendimento);

    [HttpPost("AdicionarExameAtendimento")]
    [Produces("application/json")]
    public async Task<ActionResult<object>> AdicionarExameAtendimento(ExameAtendimento exame)
    {
        RetornoGenerico<ExameAtendimento> retorno = await _service.AdicionarExameAtendimento(exame);

        if (retorno.Success)
            return Ok(retorno);
        else
            return BadRequest(retorno);
    }

    [HttpPut("AtualizarExameAtendimento")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarExameAtendimento(ExameAtendimento exame)
    {
        await _service.AtualizarExameAtendimento(exame);
        return Ok();
    }

    [HttpDelete("DeletarExameAtendimento/{idExame:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarExameAtendimento(int idExame)
    {
        await _service.DeletarExameAtendimento(idExame);
        return Ok();
    }
    #endregion

    #region Prescricao
    [HttpGet("ObterPrescricaoAtendimento/{idPrescricao:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<PrescricaoAtendimento>> ObterPrescricaoAtendimento(int idPrescricao) =>
        await _service.ObterPrescricaoAtendimento(idPrescricao);

    [HttpGet("ListaPrescricaosAtentedimento/{idAtendimento:int}")]
    [Produces("application/json")]
    public async Task<object> ListaPrescricaosAtentedimento(int idAtendimento) =>
        await _service.ListarPrescricaosAtendimento(idAtendimento);

    [HttpPost("AdicionarPrescricaoAtendimento")]
    [Produces("application/json")]
    public async Task<ActionResult<object>> AdicionarPrescricaoAtendimento(PrescricaoAtendimento Prescricao)
    {
        RetornoGenerico<PrescricaoAtendimento> retorno = await _service.AdicionarPrescricaoAtendimento(Prescricao);

        if (retorno.Success)
            return Ok(retorno);
        else
            return BadRequest(retorno);
    }

    [HttpPut("AtualizarPrescricaoAtendimento")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarPrescricaoAtendimento(PrescricaoAtendimento Prescricao)
    {
        await _service.AtualizarPrescricaoAtendimento(Prescricao);
        return Ok();
    }

    [HttpDelete("DeletarPrescricaoAtendimento/{idPrescricao:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarPrescricaoAtendimento(int idPrescricao)
    {
        await _service.DeletarPrescricaoAtendimento(idPrescricao);
        return Ok();
    }
    #endregion

    #region Atestado
    [HttpGet("ObterAtestadoAtendimento/{idAtestado:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<AtestadoAtendimento>> ObterAtestadoAtendimento(int idAtestado) =>
        await _service.ObterAtestadoAtendimento(idAtestado);

    [HttpGet("ListaAtestadosAtentedimento/{idAtendimento:int}")]
    [Produces("application/json")]
    public async Task<object> ListaAtestadosAtentedimento(int idAtendimento) =>
        await _service.ListarAtestadosAtendimento(idAtendimento);

    [HttpPost("AdicionarAtestadoAtendimento")]
    [Produces("application/json")]
    public async Task<ActionResult<object>> AdicionarAtestadoAtendimento(AtestadoAtendimento Atestado)
    {
        RetornoGenerico<AtestadoAtendimento> retorno = await _service.AdicionarAtestadoAtendimento(Atestado);

        if (retorno.Success)
            return Ok(retorno);
        else
            return BadRequest(retorno);
    }

    [HttpPut("AtualizarAtestadoAtendimento")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarAtestadoAtendimento(AtestadoAtendimento Atestado)
    {
        await _service.AtualizarAtestadoAtendimento(Atestado);
        return Ok();
    }

    [HttpDelete("DeletarAtestadoAtendimento/{idAtestado:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarAtestadoAtendimento(int idAtestado)
    {
        await _service.DeletarAtestadoAtendimento(idAtestado);
        return Ok();
    }

    [AllowAnonymous]
    [HttpGet("AtestadoRepository/{idAtendimento:int}")]
    public async Task<ActionResult<object>> AtestadoRepository(int idAtendimento) =>
        await _service.ObterAtestadoRelatorio(idAtendimento);
    #endregion

    #region Anexos
    [HttpGet("ObterAnexosAtendimento/{idAnexos:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<AnexosAtendimento>> ObterAnexosAtendimento(int idAnexos) =>
        await _service.ObterAnexosAtendimento(idAnexos);

    [HttpGet("ListaAnexossAtentedimento/{idAtendimento:int}")]
    [Produces("application/json")]
    public async Task<object> ListaAnexossAtentedimento(int idAtendimento) =>
        await _service.ListarAnexossAtendimento(idAtendimento);

    [HttpPost("AdicionarAnexosAtendimento")]
    [Produces("application/json")]
    public async Task<ActionResult<object>> AdicionarAnexosAtendimento(AnexosAtendimento Anexos)
    {
        RetornoGenerico<AnexosAtendimento> retorno = await _service.AdicionarAnexosAtendimento(Anexos);

        if (retorno.Success)
            return Ok(retorno);
        else
            return BadRequest(retorno);
    }

    [HttpPut("AtualizarAnexosAtendimento")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarAnexosAtendimento(AnexosAtendimento Anexos)
    {
        await _service.AtualizarAnexosAtendimento(Anexos);
        return Ok();
    }

    [HttpDelete("DeletarAnexosAtendimento/{idAnexos:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarAnexosAtendimento(int idAnexos)
    {
        await _service.DeletarAnexosAtendimento(idAnexos);
        return Ok();
    }
    #endregion
}

