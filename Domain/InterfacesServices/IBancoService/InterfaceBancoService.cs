using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.IBancoService;

public interface InterfaceBancoService
{
    Task<RetornoGenerico<Banco>> AdicionarBanco(Banco banco);
    Task AtualizarBanco(Banco banco);
    Task<IList<Banco>> ListarBancosClinica(int idClinica);
    Task<Banco> ObterBanco(int idBanco);
    Task<RetornoGenerico<object>> DeletarBanco(int idBanco);
}
