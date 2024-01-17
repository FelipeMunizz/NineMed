using Dapper;
using Domain.Interfaces.IToten;
using Entities.Models;
using Helper.Configuracoes;
using Infra.Repositorio.Generico;
using Microsoft.Data.SqlClient;

namespace Infra.Repositorio.TotenRepositorio;

public class TotenRepository : RepositorioGenerico<Toten>, InterfaceToten
{

    public async Task<List<Toten>> ListaTotensClinica(int idClinica)
    {
        using (var connection = new SqlConnection(Config.ConectionString))
        {
            await connection.OpenAsync();

            string sql = "SELECT * FROM Toten WHERE IdClinica = @IdClinica";
            var totens = await connection.QueryAsync<Toten>(sql, new { IdClinica = idClinica });

            await connection.CloseAsync();

            return totens.ToList();
        }
    }
}
