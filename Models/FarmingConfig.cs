using Dalamud.Configuration;

namespace FarmingBestie.Models;

[Serializable]
public sealed class FarmingConfig : IPluginConfiguration
{
    public int Version { get; set; } = 1;
    public HashSet<uint> Wishlist { get; set; } = [];
    public Dictionary<uint, int> RunCounts { get; set; } = [];
    public Dictionary<uint, string> Notes { get; set; } = [];
}
