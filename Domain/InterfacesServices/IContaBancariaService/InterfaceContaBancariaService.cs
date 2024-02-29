using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.IContaBancariaService;

public interface InterfaceContaBancariaService
{
    Task<RetornoGenerico<ContaBancaria>> AdicionarContaBancaria(ContaBancaria contaBancaria);
    Task AtualizarContaBancaria(ContaBancaria ContaBancaria);
    Task<IList<ContaBancaria>> ListaContasBancariaBanco(int idBanco);
    Task<ContaBancaria> ObterContaBancaria(int idContaBancaria);
    Task<RetornoGenerico<object>> DeletarContaBancaria(int idContaBancaria);
}
