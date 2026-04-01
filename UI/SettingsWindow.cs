using System.Numerics;
using Dalamud.Interface.Windowing;
using FarmingBestie.Services;

namespace FarmingBestie.UI;

internal sealed class SettingsWindow : Window
{
    private readonly FarmingService _farmingService;

    public SettingsWindow(FarmingService farmingService)
        : base("FarmingBestie Settings###FarmingBestieSettings", ImGuiWindowFlags.None)
    {
        _farmingService = farmingService;
        SizeConstraints = new WindowSizeConstraints { MinimumSize = new Vector2(400, 300), MaximumSize = new Vector2(500, 600) };
        IsOpen = false;
    }

    public override void PreDraw() => Styles.PushMainStyle();
    public override void PostDraw() => Styles.PopMainStyle();

    public override void Draw()
    {
        ImGui.PushStyleColor(ImGuiCol.Text, Styles.AccentCyan);
        ImGui.Text("FarmingBestie Settings");
        ImGui.PopStyleColor();
        ImGui.Separator(); ImGui.Spacing();

        ImGui.PushStyleColor(ImGuiCol.Text, Styles.TextSecondary);
        ImGui.Text("Settings will be added as features grow.");
        ImGui.PopStyleColor();
    }
}
