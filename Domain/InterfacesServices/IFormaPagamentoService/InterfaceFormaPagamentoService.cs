using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.IFormaPagamentoService;

public interface InterfaceFormaPagamentoService
{
    Task<RetornoGenerico<FormaPagamento>> AdicionarFormaPagamento(FormaPagamento formaPagamento);
    Task AtualizarFormaPagamento(FormaPagamento formaPagamento);
    Task<IList<FormaPagamento>> ListarFormaPagamentoClinica(int idClinica);
    Task<FormaPagamento> ObterFormaPagamento(int idFormaPagamento);
    Task<RetornoGenerico<object>> DeletarFormaPagamento(int idFormaPagamento);
}
