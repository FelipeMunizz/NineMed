using Domain.Interfaces.Generics;
using Entities.Models;

namespace Domain.Interfaces.IFormaPagamento;

public interface InterfaceFormaPagamento : InterfaceGeneric<FormaPagamento>
{
    Task<IList<FormaPagamento>> ListaFormaPagamentoClinica(int idClinica);
}
