using Domain.Interfaces.IFormaPagamento;
using Domain.InterfacesServices.IFormaPagamentoService;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class FormaPagamentoService : InterfaceFormaPagamentoService
{
    private readonly InterfaceFormaPagamento _repository;

    public FormaPagamentoService(InterfaceFormaPagamento repository)
    {
        _repository = repository;
    }

    public async Task<RetornoGenerico<FormaPagamento>> AdicionarFormaPagamento(FormaPagamento formaPagamento)
    {
        formaPagamento = await _repository.Add(formaPagamento);

        if (formaPagamento.Id == 0)
            return new RetornoGenerico<FormaPagamento>
            {
                Success = false,
                Message = "Não foi possível adicionar o Forma Pagamento"
            };
        else
            return new RetornoGenerico<FormaPagamento>
            {
                Success = true,
                Message = "Forma Pagamento adicionado com sucesso",
                Result = formaPagamento
            };
    }

    public async Task AtualizarFormaPagamento(FormaPagamento formaPagamento)
    {
        await _repository.Update(formaPagamento);
    }

    public async Task<RetornoGenerico<object>> DeletarFormaPagamento(int idFormaPagamento)
    {
        FormaPagamento formaPagamento = await _repository.GetEntityById(idFormaPagamento);
        if (formaPagamento == null)
            return new RetornoGenerico<object>
            {
                Success = false,
                Message = "Não foi possível localizar o Forma Pagamento"
            };

        await _repository.Delete(formaPagamento);

        return new RetornoGenerico<object> { Success = true, Message = "Forma Pagamento Deletado com sucesso" };
    }

    public async Task<IList<FormaPagamento>> ListarFormaPagamentoClinica(int idClinica)
    {
        return await _repository.ListaFormaPagamentoClinica(idClinica);
    }

    public async Task<FormaPagamento> ObterFormaPagamento(int idFormaPagamento)
    {
        return await _repository.GetEntityById(idFormaPagamento);
    }
}
