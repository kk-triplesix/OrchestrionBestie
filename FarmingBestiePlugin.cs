using Dalamud.Game.Gui.Dtr;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using ECommons;
using ECommons.DalamudServices;
using FarmingBestie.Services;
using FarmingBestie.UI;

namespace FarmingBestie;

public sealed class FarmingBestiePlugin : IDalamudPlugin, IDisposable
{
    private readonly WindowSystem _windowSystem;
    private readonly MainWindow _mainWindow;
    private readonly DetailWindow _detailWindow;
    private readonly SettingsWindow _settingsWindow;
    private readonly CollectionService _collectionService;
    private readonly FarmingService _farmingService;
    private readonly IDtrBarEntry _dtrEntry;

    public FarmingBestiePlugin(IDalamudPluginInterface pluginInterface)
    {
        ECommonsMain.Init(pluginInterface, this);

        _collectionService = new CollectionService();
        _farmingService = new FarmingService();
        _detailWindow = new DetailWindow(_collectionService, _farmingService);
        _settingsWindow = new SettingsWindow(_farmingService);
        _mainWindow = new MainWindow(_collectionService, _detailWindow, _farmingService, _settingsWindow);

        _windowSystem = new WindowSystem("FarmingBestie");
        _windowSystem.AddWindow(_mainWindow);
        _windowSystem.AddWindow(_detailWindow);
        _windowSystem.AddWindow(_settingsWindow);

        _detailWindow.IsOpen = false;
        _settingsWindow.IsOpen = false;

        _dtrEntry = Svc.DtrBar.Get("FarmingBestie");
        _dtrEntry.OnClick += _ => _mainWindow.Toggle();
        UpdateDtrText();

        Svc.PluginInterface.UiBuilder.OpenMainUi += () => _mainWindow.Toggle();
        Svc.PluginInterface.UiBuilder.OpenConfigUi += () => _settingsWindow.Toggle();
        Svc.PluginInterface.UiBuilder.Draw += OnDraw;

        Svc.Commands.AddHandler("/farm", new Dalamud.Game.Command.CommandInfo(OnCommand)
        {
            HelpMessage = "/farm — Toggle main window | /farm search <name> — Search mount/minion | /farm stats — Show statistics"
        });
    }

    private void OnCommand(string command, string args)
    {
        var trimmed = args.Trim();
        var lower = trimmed.ToLowerInvariant();

        switch (lower)
        {
            case "stats":
                _mainWindow.IsOpen = true;
                break;
            default:
                if (lower.StartsWith("search "))
                {
                    var searchTerm = trimmed[7..].Trim();
                    _mainWindow.SearchAndOpen(searchTerm);
                }
                else
                {
                    _mainWindow.Toggle();
                }
                break;
        }
    }

    private void OnDraw()
    {
        if (Svc.GameGui.GameUiHidden) return;
        _windowSystem.Draw();
        UpdateDtrText();
    }

    private void UpdateDtrText()
    {
        _collectionService.RefreshOwnership();
        var mountPct = _collectionService.MountPercent;
        var minionPct = _collectionService.MinionPercent;
        _dtrEntry.Text = $"FB M:{mountPct:F0}% m:{minionPct:F0}%";
        _dtrEntry.Tooltip = "FarmingBestie — Click to toggle";
    }

    public void Dispose()
    {
        Svc.Commands.RemoveHandler("/farm");
        Svc.PluginInterface.UiBuilder.Draw -= OnDraw;
        _dtrEntry.Remove();
        ECommonsMain.Dispose();
    }
}
