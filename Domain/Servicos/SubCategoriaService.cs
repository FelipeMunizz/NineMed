using Domain.Interfaces.ISubCategoria;
using Domain.InterfacesServices.ISubCategoriaService;
using Entities.Enums;
using Entities.Models;
using Entities.Retorno;

namespace Domain.Servicos;

public class SubCategoriaService : InterfaceSubCategoriaService
{
    private readonly InterfaceSubCategoria _repository;

    public SubCategoriaService(InterfaceSubCategoria repository)
    {
        _repository = repository;
    }

    public async Task<RetornoGenerico<SubCategoria>> AdicionarSubCategoria(SubCategoria SubCategoria)
    {
        SubCategoria = await _repository.Add(SubCategoria);

        if (SubCategoria.Id == 0)
            return new RetornoGenerico<SubCategoria>
            {
                Success = false,
                Message = "Não foi possível adicionar o Sub Categoria"
            };
        else
            return new RetornoGenerico<SubCategoria>
            {
                Success = true,
                Message = "Sub Categoria adicionado com sucesso",
                Result = SubCategoria
            };
    }

    public async Task AtualizarSubCategoria(SubCategoria SubCategoria)
    {
        await _repository.Update(SubCategoria);
    }

    public async Task<RetornoGenerico<object>> DeletarSubCategoria(int idSubCategoria)
    {
        SubCategoria SubCategoria = await _repository.GetEntityById(idSubCategoria);
        if (SubCategoria == null)
            return new RetornoGenerico<object>
            {
                Success = false,
                Message = "Não foi possível localizar o SubCategoria"
            };

        await _repository.Delete(SubCategoria);

        return new RetornoGenerico<object> { Success = true, Message = "Sub Categoria Deletado com sucesso" };
    }

    public async Task<IList<SubCategoria>> ListarSubCategoriaFinanceiras(int idClinica)
    {
        return await _repository.ListarSubCategoriaFinanceiras(idClinica);
    }

    public Task<IList<SubCategoria>> ListaSubCategoriaTipo(TipoLancamento tipo, int idClinica) => _repository.ListaSubCategoriaTipo(tipo, idClinica);

    public async Task<SubCategoria> ObterSubCategoria(int idSubCategoria)
    {
        return await _repository.GetEntityById(idSubCategoria);
    }
}
