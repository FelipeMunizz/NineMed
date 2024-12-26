using Entities.Models;
using Entities.ModelsReports;
using Entities.Retorno;

namespace Domain.InterfacesServices.IAtendimentoService;

public interface InterfaceAtendimentoService
{
    Task<RetornoGenerico<Atendimento>> AdicionarAtendimento(Atendimento atendimento);
    Task AtualizarAtendimento(Atendimento atendimento);
    Task DeletarAtendimento(int idAtendimento);
    Task<RetornoGenerico<object>> GraficoAtendimentosMensal(int idClinica);
    Task<RetornoGenerico<object>> EvolucaoProntuarioByIdPaciente(int idPaciente);

    #region Exames
    Task<RetornoGenerico<ExameAtendimento>> AdicionarExameAtendimento(ExameAtendimento exame);
    Task AtualizarExameAtendimento(ExameAtendimento exame);
    Task DeletarExameAtendimento(int idExame);
    Task<ExameAtendimento> ObterExameAtendimento(int idExame);
    Task<IList<ExameAtendimento>> ListarExamesAtendimento(int idAtendimento);
    #endregion

    #region Prescrição
    Task<RetornoGenerico<PrescricaoAtendimento>> AdicionarPrescricaoAtendimento(PrescricaoAtendimento prescricao);
    Task AtualizarPrescricaoAtendimento(PrescricaoAtendimento prescricao);
    Task DeletarPrescricaoAtendimento(int idPrescricao);
    Task<PrescricaoAtendimento> ObterPrescricaoAtendimento(int idPrescricao);
    Task<IList<PrescricaoAtendimento>> ListarPrescricaosAtendimento(int idAtendimento);
    #endregion

    #region Atestado
    Task<RetornoGenerico<AtestadoAtendimento>> AdicionarAtestadoAtendimento(AtestadoAtendimento Atestado);
    Task AtualizarAtestadoAtendimento(AtestadoAtendimento Atestado);
    Task DeletarAtestadoAtendimento(int idAtestado);
    Task<AtestadoAtendimento> ObterAtestadoAtendimento(int idAtestado);
    Task<IList<AtestadoAtendimento>> ListarAtestadosAtendimento(int idAtendimento);
    Task<object> ObterAtestadoRelatorio(int idAtendimento);
    #endregion

    #region Anexos
    Task<RetornoGenerico<AnexosAtendimento>> AdicionarAnexosAtendimento(AnexosAtendimento Anexos);
    Task AtualizarAnexosAtendimento(AnexosAtendimento Anexos);
    Task DeletarAnexosAtendimento(int idAnexos);
    Task<AnexosAtendimento> ObterAnexosAtendimento(int idAnexos);
    Task<IList<AnexosAtendimento>> ListarAnexossAtendimento(int idAtendimento);
    #endregion
}
