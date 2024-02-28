using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.IConvenioService;

public interface InterfaceConvenioService
{
    Task<RetornoGenerico<Convenio>> AdicionarConvenio(Convenio convenio);
    Task AtualizarConvenio(Convenio convenio);
    Task DeletarConvenio(int idConvenio);
    Task<IList<PlanosConvenio>> ListaPlanosConvenio(int idConvenio);
    Task<PlanosConvenio> ObtemPlanoConvenio(int idPlanoConvenio);
    Task<RetornoGenerico<object>> AdicionarPlanoConvenio(PlanosConvenio plano);
    Task AtualizarPlanoConvenio(PlanosConvenio plano);
    Task DeletarPlanoConvenio(int idPlanoConvenio);
    Task<IList<ProfissionaisSaudeConvenio>> ListaProfissionaisSaudeConvenio(int idConvenio);
    Task<ProfissionaisSaudeConvenio> ObtemProfissionalSaudeConvenio(int idProfissionalSaudeConvenio);
    Task<RetornoGenerico<object>> AdicionarProfissionalSaudeConvenio(ProfissionaisSaudeConvenio ProfissionalSaude);
    Task AtualizarProfissionalSaudeConvenio(ProfissionaisSaudeConvenio ProfissionalSaude);
    Task DeletarProfissionalSaudeConvenio(int idProfissionalSaudeConvenio);
    Task<bool> ProfissionalAtendeConvenio(int idFuncionario, int idConvenio);
}
