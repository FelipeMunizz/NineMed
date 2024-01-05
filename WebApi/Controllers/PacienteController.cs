using Domain.Interfaces.IPaciente;
using Domain.InterfacesServices.IPacienteService;
using Entities.Models;
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

    [HttpGet("ListaPacientesClinica/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<object> ListaPacientesClinica(int idClinica) => await _repository.ListaPacienteClinica(idClinica);

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
}
