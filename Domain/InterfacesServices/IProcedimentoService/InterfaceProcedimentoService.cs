using Entities.Models;

namespace Domain.InterfacesServices.IProcedimentoService;

public interface InterfaceProcedimentoService
{
    Task AdicionarProcedimento(Procedimento procedimento);
    Task EditarProcedimento(Procedimento procedimento);
    Task ExcluirProcedimento(int idProcedimento);
}
