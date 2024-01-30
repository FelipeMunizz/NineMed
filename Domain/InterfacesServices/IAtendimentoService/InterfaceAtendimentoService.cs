using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.IAtendimentoService;

public interface InterfaceAtendimentoService
{
    Task<RetornoGenerico<Atendimento>> AdicionarAtendimento(Atendimento atendimento);
    Task AtualizarAtendimento(Atendimento atendimento);
    Task DeletarAtendimento(int idAtendimento);

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
}
