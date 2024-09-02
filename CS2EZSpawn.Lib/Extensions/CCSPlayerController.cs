using CounterStrikeSharp.API.Core;
using CS2EZSpawn.Lib.Enums;

namespace CS2EZSpawn.Lib.Extensions;

public static class CCSPlayerControllerExtensions
{
    public static TeamEnum GetTeam(this CCSPlayerController c) => (TeamEnum)c.Team;

    /// <summary>
    /// Validate client only commands, ensure player controller is valid and nonnull.
    /// </summary>
    public static void ValidateClient(this CCSPlayerController? c, Action<CCSPlayerController> callback)
    {
        if (c is null || !c.IsValid)
        {
            return;
        }

        callback(c!);
    }

    /// <summary>
    /// Validate commands callable on both server and client.
    ///   Server:
    ///     Player controller will be null and the command can be executed.
    ///   Client:
    ///     Check player IsValid flag before calling command.
    /// </summary>
    public static void ValidateCommand(this CCSPlayerController? c, Action<CCSPlayerController?> callback)
    {
        if (c == null) callback(c);
        if (c!.IsValid) callback(c!);
    }
}
