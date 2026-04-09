using Dalamud.Game.Command;
using Dalamud.Interface.Windowing;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

namespace OrchestrionBestie;

internal sealed class OrchestrionBestiePlugin : IDalamudPlugin, IDisposable
{
    [PluginService] internal static IDalamudPluginInterface PluginInterface { get; private set; } = null!;
    [PluginService] internal static ICommandManager Commands { get; private set; } = null!;
    [PluginService] internal static IPluginLog Log { get; private set; } = null!;

    private readonly WindowSystem _windowSystem;

    public OrchestrionBestiePlugin()
    {
        _windowSystem = new WindowSystem("OrchestrionBestie");

        PluginInterface.UiBuilder.Draw += _windowSystem.Draw;

        Commands.AddHandler("/ob", new CommandInfo(OnCommand)
        {
            HelpMessage = "Toggle OrchestrionBestie window",
        });
    }

    private void OnCommand(string command, string args)
    {
    }

    public void Dispose()
    {
        Commands.RemoveHandler("/ob");
        PluginInterface.UiBuilder.Draw -= _windowSystem.Draw;
        _windowSystem.RemoveAllWindows();
    }
}
