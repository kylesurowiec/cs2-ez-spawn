using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CS2EZSpawn.Utils;

public class Vector3Converter : JsonConverter<Vector3>
{
    public override Vector3 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return Vec3Parser.ParseVec3String(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, Vector3 value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"{value.X},{value.Y},{value.Z}");
    }
}

public class Vector3ListConverter : JsonConverter<List<Vector3>>
{
    public override List<Vector3> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var vectorList = new List<Vector3>();

        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            vectorList.Add(Vec3Parser.ParseVec3String(reader.GetString()));
        }

        return vectorList;
    }

    public override void Write(Utf8JsonWriter writer, List<Vector3> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var vector in value)
        {
            writer.WriteStringValue($"{vector.X},{vector.Y},{vector.Z}");
        }
        writer.WriteEndArray();
    }
}

public class Vec3Parser
{
    private static float ParseFloat(string s) => float.Parse(s, System.Globalization.CultureInfo.InvariantCulture);

    public static Vector3 ParseVec3String(string? s)
    {
        if (s is null)
        {
            // TODO: Return null and filter out later
            throw new ArgumentException("Null coordinate string provided.");
        }

        var coords = s.Split(',');

        return new Vector3(
            ParseFloat(coords[0]),
            ParseFloat(coords[1]),
            ParseFloat(coords[2])
        );
    }
}
