using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.IConvenioService;

public interface InterfaceConvenioService
{
    Task AdicionarConvenio(Convenio convenio);
    Task AtualizarConvenio(Convenio convenio);
    Task DeletarConvenio(int idConvenio);
    Task<IList<PlanosConvenio>> ListaPlanosConvenio(int idConvenio);
    Task<PlanosConvenio> ObtemPlanoConvenio(int idPlanoConvenio);
    Task<RetornoGenerico<object>> AdicionarPlanoConvenio(PlanosConvenio plano);
    Task AtualizarPlanoConvenio(PlanosConvenio plano);
    Task DeletarPlanoConvenio(int idPlanoConvenio);
}
