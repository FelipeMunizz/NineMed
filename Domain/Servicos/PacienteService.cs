using Domain.Interfaces.IPaciente;
using Domain.InterfacesServices.IPacienteService;
using Entities.Models;
using Entities.Retorno;
using Helper.Logs;

namespace Domain.Servicos;

public class PacienteService : InterfacePacienteService
{
    private readonly InterfacePaciente _pacienteRepositorio;
    private readonly InterfacePacienteContato _contatoRepositorio;
    private readonly InterfacePacienteEndereco _enderecoRepositorio;
    private readonly InterfacePacienteConvenio _convenioRepositorio;
    private readonly InterfacePacienteFamiliar _familiarRepositorio;
    private readonly InterfacePacienteProntuario _prontuarioRepositorio;

    public PacienteService(InterfacePaciente pacienteRepositorio,
                           InterfacePacienteContato contatoRepositorio,
                           InterfacePacienteEndereco enderecoRepositorio,
                           InterfacePacienteConvenio convenioRepositorio,
                           InterfacePacienteFamiliar familiarRepositorio,
                           InterfacePacienteProntuario prontuarioRepositorio)
    {
        _pacienteRepositorio = pacienteRepositorio;
        _contatoRepositorio = contatoRepositorio;
        _enderecoRepositorio = enderecoRepositorio;
        _convenioRepositorio = convenioRepositorio;
        _familiarRepositorio = familiarRepositorio;
        _prontuarioRepositorio = prontuarioRepositorio;
    }

    #region Paciente
    public async Task AdicionarPaciente(Paciente paciente,
                                        EnderecoPaciente endereco,
                                        ContatoPaciente contato,
                                        PacienteConvenio convenio,
                                        PacienteFamiliar familiar)
    {
        try
        {
            PacienteProntuario prontuario = new PacienteProntuario();
            paciente = await _pacienteRepositorio.Add(paciente);
            if (paciente.Id > 0)
            {
                endereco.IdPaciente = paciente.Id;
                contato.IdPaciente = paciente.Id;
                convenio.IdPaciente = paciente.Id;
                familiar.IdPaciente = paciente.Id;
                prontuario.IdPaciente = paciente.Id;
            }
            else
            {
                LogProxy.GravarLog($"Erro ao salvar Paciente: {paciente.Nome}, CPF {paciente.CPF}");
                throw new Exception("Erro ao adicionar a Paciente");
            }
            await AdicionarEnderecoPaciente(endereco);
            await AdicionarContatoPaciente(contato);
            await AdicionarPacienteConvenio(convenio);
            await AdicionarPacienteFamiliar(familiar);
            await AdicionarPacienteProntuario(prontuario);
        }
        catch (Exception ex)
        {
            LogProxy.GravarLogException(ex);
            throw;
        }
    }

    public async Task AtualizarPaciente(Paciente paciente)
    {
        await _pacienteRepositorio.Update(paciente);
    }

    public async Task DeletarPaciente(int idPaciente)
    {
        IList<PacienteFamiliar> familiares = await _familiarRepositorio.ListaFamiliaresPaciente(idPaciente);
        foreach (PacienteFamiliar familiar in familiares)
            await _familiarRepositorio.Delete(familiar);

        IList<PacienteConvenio> convenios = await _convenioRepositorio.ListaConveniosPaciente(idPaciente);
        foreach (PacienteConvenio convenio in convenios)
            await _convenioRepositorio.Delete(convenio);

        IList<ContatoPaciente> contatos = await _contatoRepositorio.ListaContatosPaciente(idPaciente);
        foreach (ContatoPaciente contato in contatos)
            await _contatoRepositorio.Delete(contato);

        Paciente paciente = await _pacienteRepositorio.GetEntityById(idPaciente);

        await _pacienteRepositorio.Delete(paciente);
    }

    public async Task<RetornoGenerico<object>> GraficoPacienteConvenio(int idClinica) => await _pacienteRepositorio.GraficoPacienteConvenio(idClinica);
    #endregion

    #region Contato
    public async Task<IList<ContatoPaciente>> ListaContatoPaciente(int idPaciente) => await _contatoRepositorio.ListaContatosPaciente(idPaciente);

    public async Task AdicionarContatoPaciente(ContatoPaciente contato) => await _contatoRepositorio.Add(contato);

    public async Task AtualizarContatoPaciente(ContatoPaciente contato) => await _contatoRepositorio.Update(contato);

    public async Task<ContatoPaciente> ObterContatoPaciente(int idContato) => await _contatoRepositorio.GetEntityById(idContato);

    public async Task DeletarContatoPaciente(int idContato)
    {
        ContatoPaciente contato = await _contatoRepositorio.GetEntityById(idContato);

        await _contatoRepositorio.Delete(contato);
    }
    #endregion

    #region Endereco
    public async Task<IList<EnderecoPaciente>> ListaEnderecosPaciente(int idPaciente) => await _enderecoRepositorio.ListaEnderecosPaciente(idPaciente);

    public async Task AdicionarEnderecoPaciente(EnderecoPaciente Endereco) => await _enderecoRepositorio.Add(Endereco);

    public async Task AtualizarEnderecoPaciente(EnderecoPaciente Endereco) => await _enderecoRepositorio.Update(Endereco);

    public async Task<EnderecoPaciente> ObterEnderecoPaciente(int idEndereco) => await _enderecoRepositorio.GetEntityById(idEndereco);

    public async Task DeletarEnderecoPaciente(int idEndereco)
    {
        EnderecoPaciente endereco = await _enderecoRepositorio.GetEntityById(idEndereco);

        await _enderecoRepositorio.Delete(endereco);
    }
    #endregion

    #region Familiar
    public async Task<IList<PacienteFamiliar>> ListaPacienteFamiliar(int idFamiliar) => await _familiarRepositorio.ListaFamiliaresPaciente(idFamiliar);
    public async Task AdicionarPacienteFamiliar(PacienteFamiliar familiar) => await _familiarRepositorio.Add(familiar);
    public async Task AtualizarPacienteFamiliar(PacienteFamiliar familiar) => await _familiarRepositorio.Update(familiar);
    public async Task<PacienteFamiliar> ObterPacienteFamiliar(int idFamiliar) => await _familiarRepositorio.GetEntityById(idFamiliar);
    public async Task DeletarPacienteFamiliar(int idFamiliar)
    {
        PacienteFamiliar familiar = await _familiarRepositorio.GetEntityById(idFamiliar);

        await _familiarRepositorio.Delete(familiar);
    }
    #endregion

    #region Convenio
    public async Task<IList<PacienteConvenio>> ListaConveniosPaciente(int idConvenio) => await _convenioRepositorio.ListaConveniosPaciente(idConvenio);
    public async Task AdicionarPacienteConvenio(PacienteConvenio Convenio) => await _convenioRepositorio.Add(Convenio);
    public async Task AtualizarPacienteConvenio(PacienteConvenio Convenio) => await _convenioRepositorio.Update(Convenio);
    public async Task<PacienteConvenio> ObterPacienteConvenio(int idConvenio) => await _convenioRepositorio.GetEntityById(idConvenio);
    public async Task DeletarPacienteConvenio(int idConvenio)
    {
        PacienteConvenio convenio = await _convenioRepositorio.GetEntityById(idConvenio);

        await _convenioRepositorio.Delete(convenio);
    }
    #endregion

    #region Prontuario
    public async Task<RetornoGenerico<PacienteProntuario>> AdicionarPacienteProntuario(PacienteProntuario prontuario)
    {
        PacienteProntuario pacienteProntuario = await ObtemPacienteProntuaio(prontuario.IdPaciente);
        if(pacienteProntuario != null)
        {
            prontuario = await _prontuarioRepositorio.Add(prontuario);

            if (prontuario.Id == 0)
                return new RetornoGenerico<PacienteProntuario>
                {
                    Success = false,
                    Message = "Não foi possivel adicionar prontuario"
                };
            return new RetornoGenerico<PacienteProntuario>
            {
                Success = true,
                Message = "Prontuario adicionado com sucesso",
                Result = prontuario
            };
        }
        else
        {
            return new RetornoGenerico<PacienteProntuario>
            {
                Success = false,
                Message = "Paciente já possui um pronturario",
                Result = pacienteProntuario
            };
        }
    }

    public async Task AtualizarPacienteProntuario(PacienteProntuario prontuario)
    {
        await _prontuarioRepositorio.Update(prontuario);
    }

    public async Task<PacienteProntuario> ObtemProntuaio(int idProntuario) => await _prontuarioRepositorio.GetEntityById(idProntuario);

    public async Task<PacienteProntuario> ObtemPacienteProntuaio(int idPaciente) => await _prontuarioRepositorio.ObtemPacienteProntuario(idPaciente);

    public async Task<object> ObtemProntuarioTelaAtendimento(int idPaciente) => await _prontuarioRepositorio.ObtemProntuarioTelaAtendimento(idPaciente);

    public async Task DeletarPacienteProntuario(int idProntuario)
    {
        PacienteProntuario prontuario = await ObtemProntuaio(idProntuario);
        if(prontuario != null)
            await _prontuarioRepositorio.Delete(prontuario);
    }
    #endregion
}
