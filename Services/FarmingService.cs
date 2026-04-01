using ECommons.DalamudServices;
using FarmingBestie.Models;

namespace FarmingBestie.Services;

public sealed class FarmingService
{
    private readonly FarmingConfig _config;

    public FarmingService()
    {
        _config = Svc.PluginInterface.GetPluginConfig() as FarmingConfig ?? new FarmingConfig();
    }

    public HashSet<uint> Wishlist => _config.Wishlist;

    public bool IsWishlisted(uint rowId) => _config.Wishlist.Contains(rowId);

    public void ToggleWishlist(uint rowId)
    {
        if (!_config.Wishlist.Remove(rowId))
            _config.Wishlist.Add(rowId);
        Save();
    }

    public int GetRunCount(uint dutyId) => _config.RunCounts.GetValueOrDefault(dutyId, 0);

    public void IncrementRuns(uint dutyId)
    {
        _config.RunCounts[dutyId] = GetRunCount(dutyId) + 1;
        Save();
    }

    public void ResetRuns(uint dutyId)
    {
        _config.RunCounts.Remove(dutyId);
        Save();
    }

    public void SetNote(uint rowId, string note)
    {
        if (string.IsNullOrWhiteSpace(note))
            _config.Notes.Remove(rowId);
        else
            _config.Notes[rowId] = note.Trim();
        Save();
    }

    public string GetNote(uint rowId) => _config.Notes.GetValueOrDefault(rowId, string.Empty);

    public void Save()
    {
        Svc.PluginInterface.SavePluginConfig(_config);
    }
}
