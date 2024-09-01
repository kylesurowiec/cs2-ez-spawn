using CounterStrikeSharp.API.Core;

namespace CS2EZSpawn;

public class CS2EZSpawn : BasePlugin
{
    public override string ModuleName => "CS2 EZ Spawns";
    public override string ModuleVersion => "0.0.1";

    public override void Load(bool hotReload)
    {
        Console.WriteLine("CS2 EZ Spawns");
    }
}
