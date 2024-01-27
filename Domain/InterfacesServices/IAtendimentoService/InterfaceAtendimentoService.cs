using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.IAtendimentoService;

public interface InterfaceAtendimentoService
{
    Task<RetornoGenerico<Atendimento>> AdicionarAtendimento(Atendimento atendimento);
    Task AtualizarAtendimento(Atendimento atendimento);
    Task DeletarAtendimento(int idAtendimento);
}
