using Domain.Interfaces.IClinica;
using Domain.InterfacesServices;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
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
    public async Task<IActionResult> AdicionarClinica(ClinicaDTO clinicaDTO)
    {
        try
        {
            Clinica clinica = new Clinica
            {
                Nome = clinicaDTO.Fantasia,
                CNPJ = clinicaDTO.CNPJ,
                RazaoSocial = clinicaDTO.RazaoSocial,
                Fantasia = clinicaDTO.Fantasia,
                InscricaoEstadual = clinicaDTO.InscricaoEstadual,
                InscricaoMunicipal = clinicaDTO.InscricaoMunicipal,
                Logo = clinicaDTO.Logo
            };

            EnderecoClinica endereco = new EnderecoClinica
            {
                Logradouro = clinicaDTO.Logradouro,
                Numero = clinicaDTO.Numero,
                Complemento = clinicaDTO.Complemento,
                CEP = clinicaDTO.CEP,
                Bairro = clinicaDTO.Bairro,
                Cidade = clinicaDTO.Cidade,
                Estado = clinicaDTO.Estado,
            };

            ContatoClinica contato = new ContatoClinica
            {
                Nome = clinicaDTO.NomeContato,
                TipoContato = clinicaDTO.TipoContato,
                Email = clinicaDTO.Email,
                NumeroContato = clinicaDTO.NumeroContato,
                HorarioComercial = clinicaDTO.HorarioComercial,
                Lembretes = clinicaDTO.Lembretes
            };

            await _service.AdicionarClinica(clinica, endereco, contato);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut("AtualizarClinica")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarClinica(ClinicaDTO clinicaDTO)
    {
        try
        {
            Clinica clinica = new Clinica
            {
                Nome = clinicaDTO.Fantasia,
                CNPJ = clinicaDTO.CNPJ,
                RazaoSocial = clinicaDTO.RazaoSocial,
                Fantasia = clinicaDTO.Fantasia,
                InscricaoEstadual = clinicaDTO.InscricaoEstadual,
                InscricaoMunicipal = clinicaDTO.InscricaoMunicipal,
                Logo = clinicaDTO.Logo
            };

            EnderecoClinica endereco = new EnderecoClinica
            {
                Logradouro = clinicaDTO.Logradouro,
                Numero = clinicaDTO.Numero,
                Complemento = clinicaDTO.Complemento,
                CEP = clinicaDTO.CEP,
                Bairro = clinicaDTO.Bairro,
                Cidade = clinicaDTO.Cidade,
                Estado = clinicaDTO.Estado,
            };

            ContatoClinica contato = new ContatoClinica
            {
                Nome = clinicaDTO.NomeContato,
                TipoContato = clinicaDTO.TipoContato,
                Email = clinicaDTO.Email,
                NumeroContato = clinicaDTO.NumeroContato,
                HorarioComercial = clinicaDTO.HorarioComercial,
                Lembretes = clinicaDTO.Lembretes
            };

            await _service.AtualizarClinica(clinica, endereco, contato);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("DeletarClinica/{idClinica:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarClinica(int idClinica)
    {
        await _service.DeletarClinica(idClinica);
        return Ok();
    }
}
