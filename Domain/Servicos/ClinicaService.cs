using Domain.Interfaces.IClinica;
using Domain.InterfacesServices;
using Entities.Models;
using Helper.Logs;

namespace Domain.Servicos;

public class ClinicaService : InterfaceClinicaService
{
    private readonly InterfaceClinica _clinicaRepositorio;
    private readonly InterfaceContatoClinica _contatoClinicaRepositorio;
    private readonly InterfaceEnderecoClinica _enderecoClinicaRepositorio;

    public ClinicaService(InterfaceClinica clinicaRepositorio, 
                          InterfaceContatoClinica contatoClinicaRepositorio, 
                          InterfaceEnderecoClinica enderecoClinicaRepositorio)
    {
        _clinicaRepositorio = clinicaRepositorio;
        _contatoClinicaRepositorio = contatoClinicaRepositorio;
        _enderecoClinicaRepositorio = enderecoClinicaRepositorio;
    }

    public async Task AdicionarClinica(Clinica clinica, EnderecoClinica endereco, ContatoClinica contato)
    {
        try
        {
            clinica = await _clinicaRepositorio.Add(clinica);
            if (clinica.Id > 0)
            {
                endereco.IdClinica = clinica.Id;
                contato.IdClinica = clinica.Id;
            }
            else
            {
                LogProxy.GravarLog($"Erro ao salvar Clinica: CNPJ {clinica.CNPJ}");
                throw new Exception("Erro ao adicionar a clinica");
            }

            await _enderecoClinicaRepositorio.Add(endereco);
            await _contatoClinicaRepositorio.Add(contato);
        }
        catch (Exception ex)
        {
            LogProxy.GravarLogException(ex);
            throw;
        }
    }

    public async Task AtualizarClinica(Clinica clinica, EnderecoClinica endereco, ContatoClinica contato)
    {
        try
        {
            await _clinicaRepositorio.Update(clinica);
            await _enderecoClinicaRepositorio.Update(endereco);
            await _contatoClinicaRepositorio.Update(contato);
        }
        catch (Exception ex)
        {
            LogProxy.GravarLogException(ex);
            throw;
        }
    }

    public async Task DeletarClinica(int idClinica)
    {
        try
        {
            IList<ContatoClinica> contatos = await _contatoClinicaRepositorio.ContatosClinica(idClinica);
            foreach (ContatoClinica contato in contatos)
                await _contatoClinicaRepositorio.Delete(contato);

            IList<EnderecoClinica> enderecos = await _enderecoClinicaRepositorio.EnderecosClinica(idClinica);
            foreach (EnderecoClinica endereco in enderecos)
                await _enderecoClinicaRepositorio.Delete(endereco);

            Clinica clinica = await _clinicaRepositorio.GetEntityById(idClinica);

            await _clinicaRepositorio.Delete(clinica);
        }
        catch (Exception ex)
        {
            LogProxy.GravarLogException(ex);
            throw;
        }
    }
}
