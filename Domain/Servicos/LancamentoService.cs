using Domain.Interfaces.ILancamento;
using Domain.InterfacesServices.ILancamentoService;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class LancamentoService : InterfaceLancamentoService
{
    private readonly InterfaceLancamento _repository;

    public LancamentoService(InterfaceLancamento repository)
    {
        _repository = repository;
    }

    public async Task<RetornoGenerico<Lancamento>> AdicionarLancamento(Lancamento lancamento)
    {
        lancamento.DataLancamento = DateTime.Now;
        
        lancamento = await _repository.Add(lancamento);

        if (lancamento.Id == 0)
            return new RetornoGenerico<Lancamento>
            {
                Success = false,
                Message = "Não foi possível adicionar o Lançamento"
            };
        else
            return new RetornoGenerico<Lancamento>
            {
                Success = true,
                Message = "Lançamento adicionado com sucesso",
                Result = lancamento
            };
    }

    public async Task AtualizarLancamento(Lancamento lancamento)
    {
        await _repository.Update(lancamento);
    }

    public async Task<RetornoGenerico<object>> DeletarLancamento(int idLancamento)
    {
        Lancamento lancamento = await _repository.GetEntityById(idLancamento);
        if (lancamento == null)
            return new RetornoGenerico<object>
            {
                Success = false,
                Message = "Não foi possível localizar o Lançamento"
            };

        await _repository.Delete(lancamento);

        return new RetornoGenerico<object> { Success = true, Message = "Lançamento Deletado com sucesso" };
    }

    public async Task<IList<Lancamento>> ListaLancamentoReceitas(int idClinica) => await _repository.ListaLancamentoReceitas(idClinica);

    public async Task<IList<Lancamento>> ListaLancamentoDespesas(int idClinica) => await _repository.ListaLancamentoDespesas(idClinica);

    public async Task<Lancamento> ObterLancamento(int idLancamento)
    {
        return await _repository.GetEntityById(idLancamento);
    }

    public async Task<RetornoGenerico<decimal>> RetornoSaldoGeral(int idContaBancaria)
    {
        try
        {
            decimal valor = await _repository.RetornoSaldoGeral(idContaBancaria);

            return new RetornoGenerico<decimal>
            {
                Success = true,
                Message = "",
                Result = valor
            };
        }
        catch
        {
            return new RetornoGenerico<decimal>
            {
                Success = false,
                Message = "Não foi possivel obter o valor do saldo geral."
            };
        }
    }
}
