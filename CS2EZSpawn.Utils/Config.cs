using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CS2EZSpawn.Utils;

public class MapModel
{
    public Dictionary<string, MapData> Maps { get; set; } = new Dictionary<string, MapData>();
}

public class MapData
{
    public TeamData T { get; set; } = null!;
    public TeamData Ct { get; set; } = null!;
}

public class TeamData
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

public class Program
{
    public static async Task Main(string[] args)
    {
        var mapName = "de_ancient";

        var jsonString = await File.ReadAllTextAsync("spawns.json");
        if (jsonString is null)
        {
            throw new ArgumentException("");
        }

        var mapModel = JsonSerializer.Deserialize<MapModel>(jsonString);
        if (mapModel is null)
        {
            throw new ArgumentException("");
        }

        if (mapModel.Maps.TryGetValue(mapName, out var mapData))
        {
            Console.WriteLine($"T BestA: {mapData.T.BestA}");
            Console.WriteLine($"T Spawn 1: {mapData.T.Spawns[0]}");
        }
        else
        {
            Console.WriteLine($"Map '{mapName}' not found.");
        }
    }
}

