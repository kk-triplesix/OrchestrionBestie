using System.Numerics;
using Dalamud.Interface.Windowing;
using FarmingBestie.Models;
using FarmingBestie.Services;

namespace FarmingBestie.UI;

internal sealed class DetailWindow : Window
{
    private readonly CollectionService _collectionService;
    private readonly FarmingService _farmingService;
    private CollectibleData? _item;
    private string _noteText = string.Empty;

    public DetailWindow(CollectionService collectionService, FarmingService farmingService)
        : base("Collectible Details###FarmingBestieDetail", ImGuiWindowFlags.None)
    {
        _collectionService = collectionService;
        _farmingService = farmingService;
        SizeConstraints = new WindowSizeConstraints { MinimumSize = new Vector2(380, 300), MaximumSize = new Vector2(600, 800) };
        IsOpen = false;
    }

    public override void PreDraw() => Styles.PushMainStyle();
    public override void PostDraw() => Styles.PopMainStyle();

    public void ShowCollectible(CollectibleData item)
    {
        _item = item;
        _noteText = _farmingService.GetNote(item.RowId);
        IsOpen = true;
    }

    public override void Draw()
    {
        if (_item == null) { IsOpen = false; return; }
        var item = _item;

        // Name + Type + Status
        ImGui.PushStyleColor(ImGuiCol.Text, Styles.AccentCyan); ImGui.Text(item.Name); ImGui.PopStyleColor();
        ImGui.SameLine();
        ImGui.PushStyleColor(ImGuiCol.Text, Styles.TextSecondary); ImGui.Text($"({item.Type})"); ImGui.PopStyleColor();
        ImGui.SameLine();
        ImGui.PushStyleColor(ImGuiCol.Text, item.IsOwned ? Styles.TextGreen : Styles.TextDimmed);
        ImGui.Text(item.IsOwned ? "Owned" : "Not Owned");
        ImGui.PopStyleColor();

        // Wishlist button
        var isWl = _farmingService.IsWishlisted(item.RowId);
        if (ImGui.Button(isWl ? "Remove from Wishlist" : "Add to Wishlist"))
            _farmingService.ToggleWishlist(item.RowId);

        ImGui.Spacing(); ImGui.Separator(); ImGui.Spacing();

        // Sources
        ImGui.PushStyleColor(ImGuiCol.Text, Styles.AccentCyan); ImGui.Text("Drop Sources"); ImGui.PopStyleColor();
        ImGui.Spacing();

        if (item.Sources.Count == 0)
        {
            ImGui.PushStyleColor(ImGuiCol.Text, Styles.TextDimmed);
            ImGui.Text("No source data available yet.");
            ImGui.PopStyleColor();
        }
        else
        {
            foreach (var source in item.Sources)
            {
                ImGui.PushStyleColor(ImGuiCol.Text, Styles.AccentGold);
                ImGui.Text($"[{source.Type}]");
                ImGui.PopStyleColor();
                ImGui.SameLine();
                ImGui.Text(source.Name);
                if (!string.IsNullOrEmpty(source.Description))
                {
                    ImGui.PushStyleColor(ImGuiCol.Text, Styles.TextSecondary);
                    ImGui.Text($"  {source.Description}");
                    ImGui.PopStyleColor();
                }

                // Run counter for duties
                if (source.DutyId > 0)
                {
                    var runs = _farmingService.GetRunCount(source.DutyId);
                    ImGui.SameLine();
                    ImGui.PushStyleColor(ImGuiCol.Text, Styles.TextSecondary);
                    ImGui.Text($"({runs} runs)");
                    ImGui.PopStyleColor();
                    ImGui.SameLine();
                    if (ImGui.SmallButton($"+1###{source.DutyId}"))
                        _farmingService.IncrementRuns(source.DutyId);
                    ImGui.SameLine();
                    if (ImGui.SmallButton($"Reset###{source.DutyId}r"))
                        _farmingService.ResetRuns(source.DutyId);
                }
            }
        }

        ImGui.Spacing(); ImGui.Separator(); ImGui.Spacing();

        // Notes
        ImGui.PushStyleColor(ImGuiCol.Text, Styles.AccentCyan); ImGui.Text("Notes"); ImGui.PopStyleColor();
        ImGui.Spacing();
        ImGui.PushItemWidth(-1);
        if (ImGui.InputTextMultiline("##note", ref _noteText, 512, new Vector2(0, 60)))
            _farmingService.SetNote(item.RowId, _noteText);
        ImGui.PopItemWidth();
    }
}
