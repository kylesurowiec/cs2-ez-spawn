using System.Numerics;
using CS2EZSpawn.Lib;

namespace CS2EZSpawn.Test;

public class ConfigParserTest : BaseTestWithLogger
{
    public ConfigParserTest(ITestOutputHelper output) : base(output)
    {
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
