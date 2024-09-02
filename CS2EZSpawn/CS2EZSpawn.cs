using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CS2EZSpawn.Lib.Extensions;

namespace CS2EZSpawn;

public class CS2EZSpawn : BasePlugin
{
    public override string ModuleName => "CS2 EZ Spawns";
    public override string ModuleVersion => "0.0.1";

    public override void Load(bool hotReload)
    {
        Console.WriteLine("CS2 EZ Spawns. Starting...");
    }

    [ConsoleCommand("css_spawn", "Teleport player to a random spawn on their side of the map.")]
    [CommandHelper(minArgs: 1, whoCanExecute: CommandUsage.CLIENT_ONLY)]
    public void OnHelloCommand(CCSPlayerController? player, CommandInfo commandInfo)
    {
        player.ValidateClient(player =>
        {
            var team = player.GetTeam();

            // The first argument is the command name, in this case "css_hello".
            commandInfo.GetArg(0);
            // The second argument is the first argument passed to the command, in this case "name".
            // The `minArgs` helper parameter is used to ensure that the second argument is present.
            var name = commandInfo.GetArg(1);

            commandInfo.ReplyToCommand($"Hello {name}");
        });
    }
}
