using Domain.Interfaces.IPaciente;
using Domain.InterfacesServices.IPacienteService;
using Entities.Models;
using Entities.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class PacienteController : ControllerBase
{
    private readonly InterfacePaciente _repository;
    private readonly InterfacePacienteService _service;

    public PacienteController(InterfacePaciente repository, InterfacePacienteService service)
    {
        _repository = repository;
        _service = service;
    }

    #region Paciente
    [HttpGet("ListaPacientesClinica/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListaPacientesClinica(int idClinica) => await _repository.ListaPacienteClinica(idClinica);

    [HttpGet("GraficoPacienteConvenio/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<RetornoGenerico<object>> GraficoPacienteConvenio(int idClinica) => await _service.GraficoPacienteConvenio(idClinica);

    [HttpGet("ObterPaciente/{idPaciente:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<Paciente>> ObterPaciente(int idPaciente) => await _repository.GetEntityById(idPaciente);

    [HttpPost("AdicionarPaciente")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarPaciente(PacienteDTO pacienteDTO)
    {
        Paciente paciente = new Paciente
        {
            Nome = pacienteDTO.Nome,
            CPF = pacienteDTO.CPF,
            DataNascimento = pacienteDTO.DataNascimento,
            RG = pacienteDTO.RG,
            EstadoCivil = pacienteDTO.EstadoCivil,
            Profissao = pacienteDTO.Profissao,
            IdClinica = pacienteDTO.IdClinica
        };

        ContatoPaciente contato = new ContatoPaciente
        {
            Nome = pacienteDTO.NomeContato,
            Email = pacienteDTO.Email,
            HorarioComercial = pacienteDTO.HorarioComercial,
            NumeroContato = pacienteDTO.NumeroContato,
            Lembretes = pacienteDTO.Lembretes,
            TipoContato = pacienteDTO.TipoContato
        };

        EnderecoPaciente endereco = new EnderecoPaciente
        {
            Logradouro = pacienteDTO.Logradouro,
            Bairro = pacienteDTO.Bairro,
            CEP = pacienteDTO.CEP,
            Cidade = pacienteDTO.Cidade,
            Complemento = pacienteDTO.Complemento,
            Estado = pacienteDTO.Estado,
            Numero = pacienteDTO.Numero
        };

        PacienteConvenio convenio = new PacienteConvenio
        {
            ContratoPlano = pacienteDTO.ContratoPlano,
            NumeroCarterinha = pacienteDTO.NumeroCarterinha,
            Observacoes = pacienteDTO.Observacoes,
            Validade = pacienteDTO.Validade,
            IdConvenio = pacienteDTO.IdConvenio
        };

        PacienteFamiliar familiar = new PacienteFamiliar
        {
            Nome = pacienteDTO.NomeFamiliar,
            GrauParentesco = pacienteDTO.GrauParentesco,
            Telefone = pacienteDTO.TelefoneFamiliar,
        };

        await _service.AdicionarPaciente(paciente, endereco, contato, convenio, familiar);

        return Ok();
    }

    [HttpPut("AtualizarPaciente")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarPaciente(Paciente paciente)
    {
        await _service.AtualizarPaciente(paciente);
        return Ok();
    }

    [HttpDelete("DeletarPaciente/{idPaciente:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarPaciente(int idPaciente)
    {
        await _service.DeletarPaciente(idPaciente);
        return Ok();
    }
    #endregion

    #region Endereco
    [HttpGet("ListaEnderecoPaciente/{idPaciente:int}")]
    [Produces("application/json")]
    public async Task<object> ListaEnderecoPaciente(int idPaciente) => 
        await _service.ListaEnderecosPaciente(idPaciente);

    [HttpGet("ObterEnderecoPaciente/{idEndereco:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<EnderecoPaciente>> ObterEnderecoPaciente(int idEndereco) => 
        await _service.ObterEnderecoPaciente(idEndereco);

    [HttpPost("AdicionarEnderecoPaciente")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarEnderecoPaciente(EnderecoPaciente endereco)
    {
        await _service.AdicionarEnderecoPaciente(endereco);
        return Ok();
    }

    [HttpPut("AtualizarEnderecoPaciente")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarEnderecoPaciente(EnderecoPaciente endereco)
    {
        await _service.AtualizarEnderecoPaciente(endereco);
        return Ok();
    }

    [HttpDelete("DeletarEnderecoPaciente/{idEndereco:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarEnderecoPaciente(int idEndereco)
    {
        await _service.DeletarEnderecoPaciente(idEndereco);
        return Ok();
    }
    #endregion

    #region Contato
    [HttpGet("ListaContatoPaciente/{idPaciente:int}")]
    [Produces("application/json")]
    public async Task<object> ListaContatoPaciente(int idPaciente) =>
        await _service.ListaContatoPaciente(idPaciente);

    [HttpGet("ObterContatoPaciente/{idContato:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<ContatoPaciente>> ObterContatoPaciente(int idContato) =>
        await _service.ObterContatoPaciente(idContato);

    [HttpPost("AdicionarContatoPaciente")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarContatoPaciente(ContatoPaciente contato)
    {
        await _service.AdicionarContatoPaciente(contato);
        return Ok();
    }

    [HttpPut("AtualizarContatoPaciente")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarContatoPaciente(ContatoPaciente contato)
    {
        await _service.AtualizarContatoPaciente(contato);
        return Ok();
    }

    [HttpDelete("DeletarContatoPaciente/{idContato:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarContatoPaciente(int idContato)
    {
        await _service.DeletarContatoPaciente(idContato);
        return Ok();
    }
    #endregion

    #region Convenio
    [HttpGet("ListaConvenioPaciente/{idPaciente:int}")]
    [Produces("application/json")]
    public async Task<object> ListaConvenioPaciente(int idPaciente) =>
        await _service.ListaConveniosPaciente(idPaciente);

    [HttpGet("ObterConvenioPaciente/{idConvenio:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<PacienteConvenio>> ObterConvenioPaciente(int idConvenio) =>
        await _service.ObterPacienteConvenio(idConvenio);

    [HttpPost("AdicionarConvenioPaciente")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarConvenioPaciente(PacienteConvenio Convenio)
    {
        await _service.AdicionarPacienteConvenio(Convenio);
        return Ok();
    }

    [HttpPut("AtualizarConvenioPaciente")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarConvenioPaciente(PacienteConvenio Convenio)
    {
        await _service.AtualizarPacienteConvenio(Convenio);
        return Ok();
    }

    [HttpDelete("DeletarConvenioPaciente/{idConvenio:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarConvenioPaciente(int idConvenio)
    {
        await _service.DeletarPacienteConvenio(idConvenio);
        return Ok();
    }
    #endregion

    #region Familiar
    [HttpGet("ListaFamiliarPaciente/{idPaciente:int}")]
    [Produces("application/json")]
    public async Task<object> ListaFamiliarPaciente(int idPaciente) =>
        await _service.ListaPacienteFamiliar(idPaciente);

    [HttpGet("ObterFamiliarPaciente/{idFamiliar:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<PacienteFamiliar>> ObterFamiliarPaciente(int idFamiliar) =>
        await _service.ObterPacienteFamiliar(idFamiliar);

    [HttpPost("AdicionarFamiliarPaciente")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarFamiliarPaciente(PacienteFamiliar Familiar)
    {
        await _service.AdicionarPacienteFamiliar(Familiar);
        return Ok();
    }

    [HttpPut("AtualizarFamiliarPaciente")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarFamiliarPaciente(PacienteFamiliar Familiar)
    {
        await _service.AtualizarPacienteFamiliar(Familiar);
        return Ok();
    }

    [HttpDelete("DeletarFamiliarPaciente/{idFamiliar:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarFamiliarPaciente(int idFamiliar)
    {
        await _service.DeletarPacienteFamiliar(idFamiliar);
        return Ok();
    }
    #endregion

    #region Prontuario
    [HttpGet("ObterProntuario/{idProntuario:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<PacienteProntuario>> ObterProntuarioPaciente(int idProntuario) =>
        await _service.ObtemProntuaio(idProntuario);

    [HttpGet("ObterPacienteProntuario/{idPaciente:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<PacienteProntuario>> ObterPacienteProntuario(int idPaciente) =>
        await _service.ObtemPacienteProntuaio(idPaciente);

    [HttpPost("AdicionarProntuarioPaciente")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarProntuarioPaciente(PacienteProntuario Prontuario)
    {
        await _service.AdicionarPacienteProntuario(Prontuario);
        return Ok();
    }

    [HttpPut("AtualizarProntuarioPaciente")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarProntuarioPaciente(PacienteProntuario Prontuario)
    {
        await _service.AtualizarPacienteProntuario(Prontuario);
        return Ok();
    }

    [HttpDelete("DeletarProntuarioPaciente/{idProntuario:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarProntuarioPaciente(int idProntuario)
    {
        await _service.DeletarPacienteProntuario(idProntuario);
        return Ok();
    }

    [HttpGet("ObtemProntuarioTelaAtendimento/{idPaciente:int}")]
    [Produces("application/json")]
    public async Task<ActionResult<object>> ObtemProntuarioTelaAtendimento(int idPaciente) => 
        await _service.ObtemProntuarioTelaAtendimento(idPaciente);
    #endregion
}
