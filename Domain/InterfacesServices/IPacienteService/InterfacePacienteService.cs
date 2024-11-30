using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.IPacienteService;

public interface InterfacePacienteService
{
    Task AdicionarPaciente(Paciente paciente, EnderecoPaciente endereco, ContatoPaciente contato, PacienteConvenio convenio, PacienteFamiliar familiar);
    Task AtualizarPaciente(Paciente paciente);
    Task DeletarPaciente(int idPaciente);
    Task<RetornoGenerico<object>> GraficoPacienteConvenio(int idClinica);

    #region Endereco
    Task<IList<EnderecoPaciente>> ListaEnderecosPaciente(int idPaciente);
    Task AdicionarEnderecoPaciente(EnderecoPaciente endereco);
    Task AtualizarEnderecoPaciente(EnderecoPaciente endereco);
    Task<EnderecoPaciente> ObterEnderecoPaciente(int idEndereco);
    Task DeletarEnderecoPaciente(int idEndereco);
    #endregion

    #region Contato
    Task<IList<ContatoPaciente>> ListaContatoPaciente(int idPaciente);
    Task AdicionarContatoPaciente(ContatoPaciente contato);
    Task AtualizarContatoPaciente(ContatoPaciente contato);
    Task<ContatoPaciente> ObterContatoPaciente(int idContato);
    Task DeletarContatoPaciente(int idContato);
    #endregion

    #region Familiar
    Task<IList<PacienteFamiliar>> ListaPacienteFamiliar(int idFamiliar);
    Task AdicionarPacienteFamiliar(PacienteFamiliar familiar);
    Task AtualizarPacienteFamiliar(PacienteFamiliar familiar);
    Task<PacienteFamiliar> ObterPacienteFamiliar(int idFamiliar);
    Task DeletarPacienteFamiliar(int idFamiliar);
    #endregion

    #region Convenio
    Task<IList<PacienteConvenio>> ListaConveniosPaciente(int idConvenio);
    Task AdicionarPacienteConvenio(PacienteConvenio convenio);
    Task AtualizarPacienteConvenio(PacienteConvenio convenio);
    Task<PacienteConvenio> ObterPacienteConvenio(int idConvenio);
    Task DeletarPacienteConvenio(int idConvenio);
    #endregion

    #region Prontuario
    Task<RetornoGenerico<PacienteProntuario>> AdicionarPacienteProntuario(PacienteProntuario prontuario);
    Task AtualizarPacienteProntuario(PacienteProntuario prontuario);
    Task<PacienteProntuario> ObtemPacienteProntuaio(int idPaciente);
    Task<PacienteProntuario> ObtemProntuaio(int idProntuario);
    Task DeletarPacienteProntuario(int idProntuario);
    Task<object> ObtemProntuarioTelaAtendimento(int idPaciente);
    #endregion
}
