using System.Text.Json.Serialization;

namespace Entities.Retorno;

public class FileIoResponse
{
    [JsonPropertyName("link")]
    public string Link { get; set; }
}
