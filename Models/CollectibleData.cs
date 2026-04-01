namespace FarmingBestie.Models;

public enum CollectibleType
{
    Mount,
    Minion,
}

public enum SourceType
{
    Trial,
    Raid,
    AllianceRaid,
    Dungeon,
    DeepDungeon,
    VariantDungeon,
    TreasureMap,
    Eureka,
    FieldOperation,
    FATE,
    Achievement,
    Quest,
    Crafting,
    MarketBoard,
    MogStation,
    Event,
    PvP,
    GoldSaucer,
    Hunt,
    Other,
}

public sealed class CollectibleData
{
    public uint RowId { get; init; }
    public string Name { get; init; } = string.Empty;
    public CollectibleType Type { get; init; }
    public ushort IconId { get; init; }
    public bool IsOwned { get; set; }
    public List<DropSource> Sources { get; init; } = [];
}

public sealed class DropSource
{
    public SourceType Type { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public uint DutyId { get; init; }
    public byte Level { get; init; }
    public uint ExpansionId { get; init; }
}
