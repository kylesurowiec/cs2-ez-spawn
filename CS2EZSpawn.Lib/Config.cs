using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CS2EZSpawn.Lib;

public class TeamSpawnConfig
{
    [JsonPropertyName("t")]
    public SpawnConfig T { get; set; } = null!;

    [JsonPropertyName("ct")]
    public SpawnConfig CT { get; set; } = null!;
}

public class SpawnConfig
{
    [JsonPropertyName("best_a")]
    [JsonConverter(typeof(Vector3Converter))]
    public Vector3 BestA { get; set; }

    [JsonPropertyName("best_b")]
    [JsonConverter(typeof(Vector3Converter))]
    public Vector3 BestB { get; set; }

    [JsonPropertyName("spawns")]
    [JsonConverter(typeof(Vector3ListConverter))]
    public List<Vector3> Spawns { get; set; } = null!;
}

public class Config
{
    public static async Task<TeamSpawnConfig?> GetConfigForMap(string map)
    {
        var jsonStr = await File.ReadAllTextAsync("spawns.json");
        var de = JsonSerializer.Deserialize<Dictionary<string, TeamSpawnConfig>>(jsonStr);

        return de?[map];
    }
}
