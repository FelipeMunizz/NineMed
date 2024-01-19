using Domain.Interfaces.IClinica;
using Domain.InterfacesServices.IClinicaService;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

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
    public async Task<IActionResult> AtualizarClinica(Clinica clinica)
    {
        try
        {            
            await _service.AtualizarClinica(clinica);
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

    [HttpGet("ListaEnderecosClinica")]
    [Produces("application/json")]
    public async Task<object> ListaEnderecosClinica(int idClinica) => await _service.ListaEnderecosClinica(idClinica);

    [HttpGet("ObterEnderecoClinica")]
    [Produces("application/json")]
    public async Task<object> ObterEnderecoClinica(int idEndereco) => await _service.ObterEnderecoClinica(idEndereco);


    [HttpPost("AdicionarEnderecoClinica")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarEnderecoClinica(EnderecoClinica endereco)
    {
        await _service.AdicionarEnderecoClinica(endereco);
        return Ok();
    }

    [HttpPut("AtualizarEnderecoClinica")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarEnderecoClinica(EnderecoClinica endereco)
    {
        await _service.AtualizarEnderecoClinica(endereco);
        return Ok();
    }

    [HttpDelete("DeletarEnderecoClinica/{idEndereco:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarEnderecoClinica(int idEndereco)
    {
        await _service.DeletarEnderecoClinica(idEndereco);
        return Ok();
    }

    [HttpGet("ListaContatoClinica")]
    [Produces("application/json")]
    public async Task<object> ListaContatoClinica(int idClinica) => await _service.ListaContatoClinica(idClinica);

    [HttpGet("ObterContatoClinica/{idContato:int}")]
    [Produces("application/json")]
    public async Task<object> ObterContatoClinica(int idContato) => await _service.ObterContatoClinica(idContato);


    [HttpPost("AdicionarContatoClinica")]
    [Produces("application/json")]
    public async Task<IActionResult> AdicionarContatoClinica(ContatoClinica contato)
    {
        await _service.AdicionarContatoClinica(contato);
        return Ok();
    }

    [HttpPut("AtualizarContatoClinica")]
    [Produces("application/json")]
    public async Task<IActionResult> AtualizarEnderecoClinica(ContatoClinica contato)
    {
        await _service.AtualizarContatoClinica(contato);
        return Ok();
    }

    [HttpDelete("DeletarContatoClinica/{idContato:int}")]
    [Produces("application/json")]
    public async Task<IActionResult> DeletarContatoClinica(int idContato)
    {
        await _service.DeletarContatoClinica(idContato);
        return Ok();
    }
}
