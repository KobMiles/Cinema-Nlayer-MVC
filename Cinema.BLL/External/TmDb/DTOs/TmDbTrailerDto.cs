using System.Text.Json.Serialization;

namespace Cinema.BLL.External.TmDb.DTOs;

public class TmDbTrailerDto
{
    [JsonPropertyName("key")]
    public string Key { get; init; } = null!;

    [JsonPropertyName("site")]
    public string Site { get; init; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; init; } = null!;
}