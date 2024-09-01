using System.Numerics;
using CS2EZSpawn.Utils;

namespace CS2EZSpawn.Test;

public class ConfigParserTest
{
    private readonly ITestOutputHelper output;

    public ConfigParserTest(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public async Task CanDeserializeJsonFileIntoMapModel()
    {
        var spawns = await Config.GetConfigForMap("de_ancient");
        var bestTSpawnA = new Vector3(-520.000000f, -2224.000000f, -99.415741f);
        var bestCTSpawnA = new Vector3(-520.000000f, -2224.000000f, -99.415741f);

        Assert.NotNull(spawns);
        Assert.True(bestTSpawnA.Equals(spawns.T.BestA));
        Assert.True(bestCTSpawnA.Equals(spawns.CT.BestA));
        Assert.True(spawns.CT.Spawns.Count() == 5, "Expected 5 spawn coordinates for de_ancient.");
    }
}

