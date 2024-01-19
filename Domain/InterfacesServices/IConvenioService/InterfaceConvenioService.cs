using Entities.Models;

namespace Domain.InterfacesServices.IConvenioService;

public interface InterfaceConvenioService
{
    Task AdicionarConvenio(Convenio convenio);
    Task AtualizarConvenio(Convenio convenio);
    Task DeletarConvenio(int idConvenio);
}
