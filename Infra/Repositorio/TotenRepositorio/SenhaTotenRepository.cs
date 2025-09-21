using Domain.Interfaces.IToten;
using Entities.Enums;
using Entities.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace Infra.Repositorio.TotenRepositorio;

public class SenhaTotenRepository : InterfaceSenhaToten
{
    private readonly IDatabase _redis;

    private static readonly JsonSerializerOptions _serializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    public SenhaTotenRepository(IConnectionMultiplexer redis)
    {
        _redis = redis.GetDatabase();
    }

    public async Task<SenhaToten> AddSenhaToten(SenhaToten senhaToten)
    {
        var keyLista = $"toten:{senhaToten.IdToten}:senhas";
        var keyItem = $"toten:{senhaToten.IdToten}:senha:{senhaToten.SenhaPainel}";

        var json = JsonSerializer.Serialize(senhaToten, _serializerOptions);

        await _redis.StringSetAsync(keyItem, json, TimeSpan.FromHours(24));

        await _redis.ListLeftPushAsync(keyLista, json);
        await _redis.KeyExpireAsync(keyLista, TimeSpan.FromHours(24));

        return senhaToten;
    }

    public async Task DeletarSenhaToten(SenhaToten senhaToten)
    {
        var keyItem = $"toten:{senhaToten.IdToten}:senha:{senhaToten.SenhaPainel}";
        await _redis.KeyDeleteAsync(keyItem);

        var keyLista = $"toten:{senhaToten.IdToten}:senhas";
        await _redis.ListRemoveAsync(keyLista, JsonSerializer.Serialize(senhaToten, _serializerOptions));
    }

    public async Task<IList<SenhaToten>> ListaSenhasPainel(int idToten)
    {
        var keyLista = $"toten:{idToten}:senhas";
        var values = await _redis.ListRangeAsync(keyLista, 0, -1);

        return values.Select(v => JsonSerializer.Deserialize<SenhaToten>(v!, _serializerOptions)!).ToList();
    }

    public async Task<SenhaToten> ObtemSenhaPainel(string senhaPainel, int idToten)
    {
        var keyItem = $"toten:{idToten}:senha:{senhaPainel}";
        var value = await _redis.StringGetAsync(keyItem);

        if (value.IsNullOrEmpty) return null;

        return JsonSerializer.Deserialize<SenhaToten>(value!, _serializerOptions);
    }

    public async Task<int> SenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento, int idToten)
    {
        var senhas = await ListaSenhasPainel(idToten);
        return senhas.Count(s => s.TipoAtendimento == tipoAtendimento);
    }

    public async Task<SenhaToten> UpdateSenhaToten(SenhaToten senhaToten)
    {
        await DeletarSenhaToten(senhaToten);
        return await AddSenhaToten(senhaToten);
    }

    public async Task<IList<SenhaToten>> ListaSenhaTotenTipoAtendimento(TipoAtendimento tipoAtendimento, int idToten)
    {
        var keyLista = $"toten:{idToten}:senhas";

        var values = await _redis.ListRangeAsync(keyLista, 0, -1);

        if (values is null || values.Length == 0)
            return new List<SenhaToten>();

        var result = values
            .Where(v => !v.IsNullOrEmpty)
            .Select(v =>
            {
                try
                {
                    return JsonSerializer.Deserialize<SenhaToten>(v!, _serializerOptions);
                }
                catch
                {
                    return null;
                }
            })
            .Where(s => s != null) 
            .Select(s => s!)
            .Where(s => s.TipoAtendimento == tipoAtendimento
                        && s.StatusAtendimento == StatusAtendimento.Chegada
                        && s.IdToten == idToten)
            .ToList();

        return result;
    }
}
