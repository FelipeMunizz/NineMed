using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.ILancamentoService;

public interface InterfaceLancamentoService
{
    Task<RetornoGenerico<Lancamento>> AdicionarLancamento(Lancamento lancamento);
    Task AtualizarLancamento(Lancamento lancamento);
    Task<IList<Lancamento>> ListaLancamentoReceitas(int idClinica);
    Task<IList<Lancamento>> ListaLancamentoDespesas(int idClinica);
    Task<Lancamento> ObterLancamento(int idLancamento);
    Task<RetornoGenerico<object>> DeletarLancamento(int idLancamento);
    Task<RetornoGenerico<decimal>> RetornoSaldoGeral(int idContaBancaria);
}
