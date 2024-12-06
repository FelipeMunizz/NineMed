using Domain.Interfaces.IClinica;
using Domain.InterfacesServices.IClinicaService;
using Entities.Models;
using Entities.Retorno;
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

    #region Clinica
    public async Task<RetornoGenerico<Clinica>> AdicionarClinica(Clinica clinica, EnderecoClinica endereco, ContatoClinica contato)
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
                return new RetornoGenerico<Clinica>
                {
                    Success = false,
                    Message = "Erro ao salvar a clinica"
                };
            }

            await _enderecoClinicaRepositorio.Add(endereco);
            await _contatoClinicaRepositorio.Add(contato);

            return new RetornoGenerico<Clinica>
            {
                Success = true,
                Message = "Clinica Adicionada com Sucesso",
                Result = clinica
            };
        }
        catch (Exception ex)
        {
            LogProxy.GravarLogException(ex);

            return new RetornoGenerico<Clinica>
            {
                Success = false,
                Message = "Erro ao salvar a clinica"
            };
        }
    }

    public async Task AtualizarClinica(Clinica clinica)
    {
        try
        {
            await _clinicaRepositorio.Update(clinica);
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
    #endregion

    #region EnderecoClinica
    public async Task<IList<EnderecoClinica>> ListaEnderecosClinica(int idClinica) => await _enderecoClinicaRepositorio.EnderecosClinica(idClinica);

    public async Task AdicionarEnderecoClinica(EnderecoClinica endereco) => await _enderecoClinicaRepositorio.Add(endereco);

    public async Task AtualizarEnderecoClinica(EnderecoClinica endereco) => await _enderecoClinicaRepositorio.Update(endereco);

    public async Task<EnderecoClinica> ObterEnderecoClinica(int idEndereco) => await _enderecoClinicaRepositorio.GetEntityById(idEndereco);

    public async Task DeletarEnderecoClinica(int idEndereco)
    {
        EnderecoClinica endereco = await ObterEnderecoClinica(idEndereco);

        await _enderecoClinicaRepositorio.Delete(endereco);
    }
    #endregion

    #region ContatoClinica
    public async Task<IList<ContatoClinica>> ListaContatoClinica(int idClinica) => await _contatoClinicaRepositorio.ContatosClinica(idClinica);

    public async Task AdicionarContatoClinica(ContatoClinica contato) => await _contatoClinicaRepositorio.Add(contato);

    public async Task AtualizarContatoClinica(ContatoClinica contato) => await _contatoClinicaRepositorio.Update(contato);

    public async Task<ContatoClinica> ObterContatoClinica(int idContato) => await _contatoClinicaRepositorio.GetEntityById(idContato);

    public async Task DeletarContatoClinica(int idContato)
    {
        ContatoClinica contato = await ObterContatoClinica(idContato);
        await _contatoClinicaRepositorio.Delete(contato);
    }
    #endregion
}
