using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.ILancamento;

public interface InterfaceLancamento : InterfaceGeneric<Lancamento>
{
    Task<IList<Lancamento>>ListaLancamentoReceitas(int idClinica);
    Task<IList<Lancamento>>ListaLancamentoDespesas(int idClinica);
    Task<decimal> RetornoSaldoGeral(int idContaBancaria);
}
