using Entities.Models;
using Entities.Retorno;

namespace Domain.InterfacesServices.IClinicaService;

public interface InterfaceClinicaService
{
    Task<RetornoGenerico<Clinica>> AdicionarClinica(Clinica clinica, EnderecoClinica endereco, ContatoClinica contato);
    Task AtualizarClinica(Clinica clinica);
    Task DeletarClinica(int idClinica);

    #region Endereco
    Task<IList<EnderecoClinica>> ListaEnderecosClinica(int idClinica);
    Task AdicionarEnderecoClinica(EnderecoClinica endereco);
    Task AtualizarEnderecoClinica(EnderecoClinica endereco);
    Task<EnderecoClinica> ObterEnderecoClinica(int idEndereco);
    Task DeletarEnderecoClinica(int idEndereco);
    #endregion

    #region Contato
    Task<IList<ContatoClinica>> ListaContatoClinica(int idClinica);
    Task AdicionarContatoClinica(ContatoClinica contato);
    Task AtualizarContatoClinica(ContatoClinica contato);
    Task<ContatoClinica> ObterContatoClinica(int idContato);
    Task DeletarContatoClinica(int idContato);
    #endregion
}
