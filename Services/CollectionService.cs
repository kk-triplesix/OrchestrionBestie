using Dalamud.Utility;
using ECommons.DalamudServices;
using FFXIVClientStructs.FFXIV.Client.Game;
using Lumina.Excel.Sheets;
using FarmingBestie.Models;

namespace FarmingBestie.Services;

public sealed class CollectionService
{
    public List<CollectibleData> Mounts { get; } = [];
    public List<CollectibleData> Minions { get; } = [];
    public Dictionary<uint, CollectibleData> AllLookup { get; } = [];

    private DateTime _lastRefresh = DateTime.MinValue;
    private int _ownedMountCount, _totalMountCount;
    private int _ownedMinionCount, _totalMinionCount;

    public int OwnedMountCount => _ownedMountCount;
    public int TotalMountCount => _totalMountCount;
    public float MountPercent => _totalMountCount > 0 ? (float)_ownedMountCount / _totalMountCount * 100f : 0f;
    public int OwnedMinionCount => _ownedMinionCount;
    public int TotalMinionCount => _totalMinionCount;
    public float MinionPercent => _totalMinionCount > 0 ? (float)_ownedMinionCount / _totalMinionCount * 100f : 0f;

    public CollectionService()
    {
        LoadMounts();
        LoadMinions();
        _totalMountCount = Mounts.Count;
        _totalMinionCount = Minions.Count;
    }

    private void LoadMounts()
    {
        var sheet = Svc.Data.GetExcelSheet<Mount>();
        if (sheet == null) return;

        foreach (var row in sheet)
        {
            var name = row.Singular.ExtractText();
            if (string.IsNullOrWhiteSpace(name))
                continue;

            if (row.Icon == 0)
                continue;

            var data = new CollectibleData
            {
                RowId = row.RowId,
                Name = name,
                Type = CollectibleType.Mount,
                IconId = (ushort)row.Icon,
            };

            Mounts.Add(data);
            AllLookup[row.RowId] = data;
        }

        Mounts.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
    }

    private void LoadMinions()
    {
        var sheet = Svc.Data.GetExcelSheet<Companion>();
        if (sheet == null) return;

        foreach (var row in sheet)
        {
            var name = row.Singular.ExtractText();
            if (string.IsNullOrWhiteSpace(name))
                continue;

            if (row.Icon == 0)
                continue;

            var data = new CollectibleData
            {
                RowId = 100000 + row.RowId, // Offset to avoid collision with mount IDs
                Name = name,
                Type = CollectibleType.Minion,
                IconId = (ushort)row.Icon,
            };

            Minions.Add(data);
            AllLookup[data.RowId] = data;
        }

        Minions.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
    }

    public void RefreshOwnership()
    {
        if ((DateTime.Now - _lastRefresh).TotalSeconds < 2.0)
            return;
        _lastRefresh = DateTime.Now;

        // TODO: Check ownership via PlayerState / UIState
        // For now just update counts
        _ownedMountCount = Mounts.Count(m => m.IsOwned);
        _ownedMinionCount = Minions.Count(m => m.IsOwned);
    }

    public List<CollectibleData> SearchAll(string term)
    {
        if (string.IsNullOrWhiteSpace(term))
            return [.. Mounts, .. Minions];

        return [.. Mounts.Where(m => m.Name.Contains(term, StringComparison.OrdinalIgnoreCase)),
                .. Minions.Where(m => m.Name.Contains(term, StringComparison.OrdinalIgnoreCase))];
    }
}
