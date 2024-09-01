using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;

namespace CS2EZSpawn;

public class Commands
{
    [ConsoleCommand("css_spawn", "Teleport player to a random spawn on their side of the map.")]
    [CommandHelper(minArgs: 1, usage: "[name]", whoCanExecute: CommandUsage.CLIENT_AND_SERVER)]
    public void OnHelloCommand(CCSPlayerController? player, CommandInfo commandInfo)
    {
        // The first argument is the command name, in this case "css_hello".
        commandInfo.GetArg(0);

        // The second argument is the first argument passed to the command, in this case "name".
        // The `minArgs` helper parameter is used to ensure that the second argument is present.
        var name = commandInfo.GetArg(1);

        commandInfo.ReplyToCommand($"Hello {name}");
    }
}
