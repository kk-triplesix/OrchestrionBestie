using System.Numerics;
using Dalamud.Interface.Windowing;
using FarmingBestie.Models;
using FarmingBestie.Services;

namespace FarmingBestie.UI;

internal sealed class MainWindow : Window
{
    private readonly CollectionService _collectionService;
    private readonly DetailWindow _detailWindow;
    private readonly FarmingService _farmingService;
    private readonly SettingsWindow _settingsWindow;

    private string _searchText = string.Empty;
    private int _ownershipFilter; // 0=All, 1=Missing, 2=Owned
    private List<CollectibleData> _filteredMounts = [];
    private List<CollectibleData> _filteredMinions = [];
    private bool _dirty = true;

    private static readonly string[] OwnershipLabels = ["All", "Missing", "Owned"];

    public MainWindow(CollectionService collectionService, DetailWindow detailWindow, FarmingService farmingService, SettingsWindow settingsWindow)
        : base("FarmingBestie###FarmingBestieMain", ImGuiWindowFlags.None)
    {
        _collectionService = collectionService;
        _detailWindow = detailWindow;
        _farmingService = farmingService;
        _settingsWindow = settingsWindow;
        SizeConstraints = new WindowSizeConstraints { MinimumSize = new Vector2(650, 450), MaximumSize = new Vector2(9999, 9999) };
    }

    public override void PreDraw() => Styles.PushMainStyle();
    public override void PostDraw() => Styles.PopMainStyle();

    public void SearchAndOpen(string term)
    {
        var all = _collectionService.SearchAll(term);
        if (all.Count == 1)
            _detailWindow.ShowCollectible(all[0]);
        else
        {
            _searchText = term;
            _dirty = true;
            IsOpen = true;
        }
    }

    public override void Draw()
    {
        _collectionService.RefreshOwnership();

        // Header
        ImGui.PushStyleColor(ImGuiCol.Text, Styles.AccentCyan); ImGui.Text("FarmingBestie"); ImGui.PopStyleColor();
        ImGui.SameLine();
        ImGui.PushStyleColor(ImGuiCol.Text, Styles.TextSecondary); ImGui.Text("— Mount & Minion Tracker"); ImGui.PopStyleColor();
        ImGui.SameLine();
        var rightX = ImGui.GetWindowWidth() - ImGui.CalcTextSize("Settings").X - 24;
        ImGui.SetCursorPosX(rightX);
        if (ImGui.Button("Settings")) _settingsWindow.Toggle();
        ImGui.Separator();

        // Filters
        ImGui.PushItemWidth(200);
        if (ImGui.InputTextWithHint("##search", "Search mounts & minions...", ref _searchText, 256)) _dirty = true;
        ImGui.PopItemWidth();
        ImGui.SameLine();
        ImGui.PushItemWidth(100);
        if (ImGui.Combo("##ownership", ref _ownershipFilter, OwnershipLabels, OwnershipLabels.Length)) _dirty = true;
        ImGui.PopItemWidth();
        ImGui.Spacing();

        // Stats
        ImGui.PushStyleColor(ImGuiCol.Text, Styles.TextSecondary);
        ImGui.Text($"Mounts: {_collectionService.OwnedMountCount}/{_collectionService.TotalMountCount} ({_collectionService.MountPercent:F0}%)");
        ImGui.SameLine(); ImGui.SetCursorPosX(300);
        ImGui.Text($"Minions: {_collectionService.OwnedMinionCount}/{_collectionService.TotalMinionCount} ({_collectionService.MinionPercent:F0}%)");
        ImGui.PopStyleColor();

        if (_dirty) { ApplyFilters(); _dirty = false; }

        // Tabs
        if (ImGui.BeginTabBar("##mainTabs"))
        {
            if (ImGui.BeginTabItem($"Mounts ({_filteredMounts.Count})"))
            { DrawTable(_filteredMounts); ImGui.EndTabItem(); }
            if (ImGui.BeginTabItem($"Minions ({_filteredMinions.Count})"))
            { DrawTable(_filteredMinions); ImGui.EndTabItem(); }
            if (ImGui.BeginTabItem("Wishlist"))
            { DrawWishlist(); ImGui.EndTabItem(); }
            ImGui.EndTabBar();
        }
    }

    private void DrawTable(List<CollectibleData> items)
    {
        var flags = ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg | ImGuiTableFlags.Resizable
                    | ImGuiTableFlags.ScrollY | ImGuiTableFlags.SizingStretchProp;
        var tableHeight = ImGui.GetContentRegionAvail().Y;

        if (!ImGui.BeginTable("##collectibles", 3, flags, new Vector2(0, tableHeight)))
            return;

        ImGui.TableSetupScrollFreeze(0, 1);
        ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthStretch, 0);
        ImGui.TableSetupColumn("Sources", ImGuiTableColumnFlags.WidthFixed, 200);
        ImGui.TableSetupColumn("Status", ImGuiTableColumnFlags.WidthFixed, 60);
        ImGui.TableHeadersRow();

        foreach (var item in items)
        {
            ImGui.TableNextRow();

            ImGui.TableNextColumn();
            var nameColor = item.IsOwned ? Styles.TextDimmed : Styles.TextPrimary;
            ImGui.PushStyleColor(ImGuiCol.Text, nameColor);
            if (ImGui.Selectable($"{item.Name}###{item.RowId}", false, ImGuiSelectableFlags.SpanAllColumns))
                _detailWindow.ShowCollectible(item);
            ImGui.PopStyleColor();

            ImGui.TableNextColumn();
            ImGui.PushStyleColor(ImGuiCol.Text, Styles.TextSecondary);
            ImGui.Text(item.Sources.Count > 0 ? string.Join(", ", item.Sources.Select(s => s.Type.ToString())) : "-");
            ImGui.PopStyleColor();

            ImGui.TableNextColumn();
            ImGui.PushStyleColor(ImGuiCol.Text, item.IsOwned ? Styles.TextGreen : Styles.TextDimmed);
            ImGui.Text(item.IsOwned ? "Owned" : "-");
            ImGui.PopStyleColor();
        }

        ImGui.EndTable();
    }

    private void DrawWishlist()
    {
        var wishlistItems = _farmingService.Wishlist
            .Select(id => _collectionService.AllLookup.GetValueOrDefault(id))
            .Where(c => c != null)
            .ToList();

        if (wishlistItems.Count == 0)
        {
            ImGui.PushStyleColor(ImGuiCol.Text, Styles.TextDimmed);
            ImGui.Text("Your wishlist is empty. Click items to add them.");
            ImGui.PopStyleColor();
            return;
        }

        foreach (var item in wishlistItems)
        {
            if (item == null) continue;
            var color = item.IsOwned ? Styles.TextGreen : Styles.AccentGold;
            ImGui.PushStyleColor(ImGuiCol.Text, color);
            if (ImGui.Selectable($"{(item.IsOwned ? "v" : "x")} {item.Name}###wl{item.RowId}"))
                _detailWindow.ShowCollectible(item);
            ImGui.PopStyleColor();
        }
    }

    private void ApplyFilters()
    {
        var search = _searchText.Trim();
        _filteredMounts = Filter(_collectionService.Mounts, search);
        _filteredMinions = Filter(_collectionService.Minions, search);
    }

    private List<CollectibleData> Filter(List<CollectibleData> source, string search)
    {
        return source.Where(c =>
        {
            if (_ownershipFilter == 1 && c.IsOwned) return false;
            if (_ownershipFilter == 2 && !c.IsOwned) return false;
            if (search.Length > 0 && !c.Name.Contains(search, StringComparison.OrdinalIgnoreCase)) return false;
            return true;
        }).ToList();
    }
}
