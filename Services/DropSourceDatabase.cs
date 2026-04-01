using FarmingBestie.Models;

namespace FarmingBestie.Services;

public static class DropSourceDatabase
{
    public static List<DropSource> GetMountSources(string name)
        => MountSources.GetValueOrDefault(name, []);

    public static List<DropSource> GetMinionSources(string name)
        => MinionSources.GetValueOrDefault(name, []);

    // Factory helpers
    private static DropSource Ex(string duty, string boss, byte lvl, uint exp)
        => new() { Type = SourceType.Trial, Name = duty, Description = boss, Level = lvl, ExpansionId = exp };

    private static DropSource Sv(string duty, string info, byte lvl, uint exp)
        => new() { Type = SourceType.Raid, Name = duty, Description = info, Level = lvl, ExpansionId = exp };

    private static DropSource Dg(string duty, byte lvl, uint exp)
        => new() { Type = SourceType.Dungeon, Name = duty, Level = lvl, ExpansionId = exp };

    private static DropSource Ar(string duty, byte lvl, uint exp)
        => new() { Type = SourceType.AllianceRaid, Name = duty, Level = lvl, ExpansionId = exp };

    private static DropSource Dd(string name, string info, byte lvl, uint exp)
        => new() { Type = SourceType.DeepDungeon, Name = name, Description = info, Level = lvl, ExpansionId = exp };

    private static DropSource Vc(string duty, string info, byte lvl, uint exp)
        => new() { Type = SourceType.VariantDungeon, Name = duty, Description = info, Level = lvl, ExpansionId = exp };

    private static DropSource Ek(string name, string info, byte lvl, uint exp)
        => new() { Type = SourceType.Eureka, Name = name, Description = info, Level = lvl, ExpansionId = exp };

    private static DropSource Fo(string name, string info, byte lvl, uint exp)
        => new() { Type = SourceType.FieldOperation, Name = name, Description = info, Level = lvl, ExpansionId = exp };

    private static DropSource Ft(string name, string info, byte lvl, uint exp)
        => new() { Type = SourceType.FATE, Name = name, Description = info, Level = lvl, ExpansionId = exp };

    private static DropSource Tm(string name, string info, byte lvl, uint exp)
        => new() { Type = SourceType.TreasureMap, Name = name, Description = info, Level = lvl, ExpansionId = exp };

    private static DropSource Qt(string name, string info, byte lvl, uint exp)
        => new() { Type = SourceType.Quest, Name = name, Description = info, Level = lvl, ExpansionId = exp };

    private static DropSource Ht(string info, byte lvl, uint exp)
        => new() { Type = SourceType.Hunt, Name = "Hunt Vendor", Description = info, Level = lvl, ExpansionId = exp };

    // =====================================================================
    //  MOUNT SOURCES
    // =====================================================================
    private static readonly Dictionary<string, List<DropSource>> MountSources = new(StringComparer.OrdinalIgnoreCase)
    {
        // =================================================================
        //  ARR EXTREME TRIAL MOUNTS (Ponies) — Level 50, Expansion 0
        // =================================================================
        ["aithon"] = [Ex("The Bowl of Embers (Extreme)", "Ifrit", 50, 0)],
        ["xanthos"] = [Ex("The Howling Eye (Extreme)", "Garuda", 50, 0)],
        ["gullfaxi"] = [Ex("The Navel (Extreme)", "Titan", 50, 0)],
        ["enbarr"] = [Ex("The Whorleater (Extreme)", "Leviathan", 50, 0)],
        ["markab"] = [Ex("The Striking Tree (Extreme)", "Ramuh", 50, 0)],
        ["boreas"] = [Ex("Akh Afah Amphitheatre (Extreme)", "Shiva", 50, 0)],
        ["nightmare"] =
        [
            Ex("The Bowl of Embers (Extreme)", "Rare drop — Ifrit", 50, 0),
            Ex("The Howling Eye (Extreme)", "Rare drop — Garuda", 50, 0),
            Ex("The Navel (Extreme)", "Rare drop — Titan", 50, 0),
        ],
        ["kirin"] = [Qt("A Legend for a Legend", "Collect all 6 ARR ponies", 50, 0)],

        // =================================================================
        //  HW EXTREME TRIAL MOUNTS (Lanners) — Level 60, Expansion 1
        // =================================================================
        ["white lanner"] = [Ex("The Limitless Blue (Extreme)", "Bismarck", 60, 1)],
        ["rose lanner"] = [Ex("Thok ast Thok (Extreme)", "Ravana", 60, 1)],
        ["round lanner"] = [Ex("The Minstrel's Ballad: Thordan's Reign", "Thordan", 60, 1)],
        ["warring lanner"] = [Ex("Containment Bay S1T7 (Extreme)", "Sephirot", 60, 1)],
        ["dark lanner"] = [Ex("The Minstrel's Ballad: Nidhogg's Rage", "Nidhogg", 60, 1)],
        ["sophic lanner"] = [Ex("Containment Bay P1T6 (Extreme)", "Sophia", 60, 1)],
        ["demonic lanner"] = [Ex("Containment Bay Z1T9 (Extreme)", "Zurvan", 60, 1)],
        ["firebird"] = [Qt("Fiery Wings, Fiery Hearts", "Collect all 7 HW lanners", 60, 1)],

        // =================================================================
        //  SB EXTREME TRIAL MOUNTS (Kamuy) — Level 70, Expansion 2
        // =================================================================
        ["reveling kamuy"] = [Ex("The Pool of Tribute (Extreme)", "Susano", 70, 2)],
        ["blissful kamuy"] = [Ex("Emanation (Extreme)", "Lakshmi", 70, 2)],
        ["legendary kamuy"] = [Ex("The Minstrel's Ballad: Shinryu's Domain", "Shinryu", 70, 2)],
        ["auspicious kamuy"] = [Ex("The Jade Stoa (Extreme)", "Byakko", 70, 2)],
        ["lunar kamuy"] = [Ex("The Minstrel's Ballad: Tsukuyomi's Pain", "Tsukuyomi", 70, 2)],
        ["euphonious kamuy"] = [Ex("Hells' Kier (Extreme)", "Suzaku", 70, 2)],
        ["hallowed kamuy"] = [Ex("The Wreath of Snakes (Extreme)", "Seiryu", 70, 2)],
        ["rathalos"] = [Ex("The Great Hunt (Extreme)", "Monster Hunter crossover", 70, 2)],
        ["kamuy of the nine tails"] = [Qt("A Lone Wolf No More", "Collect all 7 SB kamuy", 70, 2)],

        // =================================================================
        //  ShB EXTREME TRIAL MOUNTS (Gwibers) — Level 80, Expansion 3
        // =================================================================
        ["fae gwiber"] = [Ex("The Dancing Plague (Extreme)", "Titania", 80, 3)],
        ["innocent gwiber"] = [Ex("The Crown of the Immaculate (Extreme)", "Innocence", 80, 3)],
        ["shadow gwiber"] = [Ex("The Minstrel's Ballad: Hades's Elegy", "Hades", 80, 3)],
        ["ruby gwiber"] = [Ex("Cinder Drift (Extreme)", "Ruby Weapon", 80, 3)],
        ["gwiber of light"] = [Ex("The Seat of Sacrifice (Extreme)", "Warrior of Light", 80, 3)],
        ["emerald gwiber"] = [Ex("Castrum Marinum (Extreme)", "Emerald Weapon", 80, 3)],
        ["diamond gwiber"] = [Ex("The Cloud Deck (Extreme)", "Diamond Weapon", 80, 3)],
        ["landerwaffe"] = [Qt("The Dragon Made", "Collect all 7 ShB gwibers", 80, 3)],

        // =================================================================
        //  EW EXTREME TRIAL MOUNTS (Lynxes) — Level 90, Expansion 4
        // =================================================================
        ["lynx of eternal darkness"] = [Ex("The Minstrel's Ballad: Zodiark's Fall", "Zodiark", 90, 4)],
        ["lynx of divine light"] = [Ex("The Minstrel's Ballad: Hydaelyn's Call", "Hydaelyn", 90, 4)],
        ["bluefeather lynx"] = [Ex("The Minstrel's Ballad: Endsinger's Aria", "Endsinger", 90, 4)],
        ["lynx of imperious wind"] = [Ex("Storm's Crown (Extreme)", "Barbariccia", 90, 4)],
        ["lynx of righteous fire"] = [Ex("Mount Ordeals (Extreme)", "Rubicante", 90, 4)],
        ["lynx of fallen shadow"] = [Ex("The Voidcast Dais (Extreme)", "Golbez", 90, 4)],
        ["lynx of abyssal grief"] = [Ex("The Abyssal Fracture (Extreme)", "Zeromus", 90, 4)],
        ["apocryphal bahamut"] = [Qt("Wings of Hope", "Collect all 7 EW lynxes", 90, 4)],

        // =================================================================
        //  DT EXTREME TRIAL MOUNTS (Wings) — Level 100, Expansion 5
        // =================================================================
        ["wings of ruin"] = [Ex("Worqor Lar Dor (Extreme)", "Valigarmanda", 100, 5)],
        ["wings of resolve"] = [Ex("Everkeep (Extreme)", "Zoraal Ja", 100, 5)],
        ["wings of eternity"] = [Ex("The Minstrel's Ballad: Sphene's Burden", "Sphene", 100, 5)],
        ["wings of the knighthood"] = [Ex("Recollection (Extreme)", "Recollection", 100, 5)],
        ["wings of death"] = [Ex("The Minstrel's Ballad: Necron's Embrace", "Necron", 100, 5)],
        ["wings of mist"] = [Ex("Hell on Rails (Extreme)", "Hell on Rails", 100, 5)],
        ["felyne support team cart"] = [Ex("The Windward Wilds (Extreme)", "Monster Hunter Wilds crossover", 100, 5)],

        // =================================================================
        //  HW SAVAGE RAID MOUNTS — Level 60, Expansion 1
        // =================================================================
        ["gobwalker"] = [Sv("Alexander - The Burden of the Father (Savage)", "A4S", 60, 1)],
        ["arrhidaeus"] = [Sv("Alexander - The Soul of the Creator (Savage)", "A12S", 60, 1)],

        // =================================================================
        //  SB SAVAGE RAID MOUNTS — Level 70, Expansion 2
        // =================================================================
        ["alte roite"] = [Sv("Deltascape V4.0 (Savage)", "O4S", 70, 2)],
        ["air force"] = [Sv("Sigmascape V4.0 (Savage)", "O8S", 70, 2)],
        ["model o"] = [Sv("Alphascape V4.0 (Savage)", "O12S", 70, 2)],

        // =================================================================
        //  ShB SAVAGE RAID MOUNTS — Level 80, Expansion 3
        // =================================================================
        ["skyslipper"] = [Sv("Eden's Gate: Sepulture (Savage)", "E4S", 80, 3)],
        ["ramuh"] = [Sv("Eden's Verse: Refulgence (Savage)", "E8S", 80, 3)],
        ["eden"] = [Sv("Eden's Promise: Eternity (Savage)", "E12S", 80, 3)],

        // =================================================================
        //  EW SAVAGE RAID MOUNTS — Level 90, Expansion 4
        // =================================================================
        ["demi-phoinix"] = [Sv("Asphodelos: The Fourth Circle (Savage)", "P4S", 90, 4)],
        ["sunforged"] = [Sv("Abyssos: The Eighth Circle (Savage)", "P8S", 90, 4)],
        ["megaloambystoma"] = [Sv("Anabaseios: The Twelfth Circle (Savage)", "P12S", 90, 4)],

        // =================================================================
        //  DT SAVAGE RAID MOUNTS — Level 100, Expansion 5
        // =================================================================
        ["monowheel s1"] = [Sv("AAC Light-heavyweight M4 (Savage)", "M4S Tier 1", 100, 5)],
        ["air-wheeler c9"] = [Sv("AAC Cruiserweight M4 (Savage)", "M8S Tier 2", 100, 5)],
        ["lowrider t1rant"] = [Sv("AAC Heavyweight M4 (Savage)", "M12S Tier 3", 100, 5)],

        // =================================================================
        //  DUNGEON MOUNTS
        // =================================================================
        ["magitek predator"] = [Dg("Ala Mhigo", 70, 2)],

        // =================================================================
        //  DEEP DUNGEON MOUNTS
        // =================================================================
        ["black pegasus"] = [Dd("Palace of the Dead", "Gold-trimmed Sack, floors 151+", 60, 1)],
        ["disembodied head"] = [Dd("Palace of the Dead", "10 Gelmorran Potsherds", 60, 1)],
        ["dodo"] = [Dd("Heaven-on-High", "Platinum-haloed Sack, floors 71+", 70, 2)],
        ["juedi"] = [Dd("Heaven-on-High", "Achievement: all 4 Empyrean accessories", 70, 2)],
        ["orthos craklaw"] = [Dd("Eureka Orthos", "Gold-tinged Sack", 90, 4)],
        ["aeturna"] = [Dd("Eureka Orthos", "Achievement: all 4 Enaretos accessories", 90, 4)],
        ["ornamental shrublet"] = [Dd("Pilgrim's Traverse", "Silver Sack", 100, 5)],
        ["pilgrim's protector"] = [Dd("Pilgrim's Traverse", "Sack of First Light or 99 First Light Relics", 100, 5)],
        ["forgiven mimicry"] = [Dd("Pilgrim's Traverse", "Sack of First Light or 99 First Light Relics", 100, 5)],
        ["chandelier of first light"] = [Dd("Pilgrim's Traverse", "Achievement: all 4 Illumed Aetherpool Grips", 100, 5)],

        // =================================================================
        //  EUREKA MOUNTS — Expansion 2 (SB era)
        // =================================================================
        ["tyrannosaur"] = [Ek("Eureka Anemos", "Anemos Lockbox", 70, 2)],
        ["eldthurs"] = [Ek("Eureka Pyros", "Gold Bunny Lockbox", 70, 2)],
        ["eurekan petrel"] = [Ek("Eureka Hydatos", "Gold Bunny Lockbox", 70, 2)],
        ["demi-ozma"] = [Ek("The Baldesion Arsenal", "Achievement: clear Baldesion Arsenal", 70, 2)],

        // =================================================================
        //  BOZJA / FIELD OPERATION MOUNTS — Expansion 3 (ShB era)
        // =================================================================
        ["gabriel alpha"] = [Fo("Bozjan Southern Front", "Southern Front Lockbox", 80, 3)],
        ["construct 14"] = [Fo("Bozjan Southern Front", "180 Bozjan Clusters", 80, 3)],
        ["gabriel mark III"] = [Fo("Delubrum Reginae", "Rare drop from final boss", 80, 3)],
        ["cerberus"] = [Fo("Delubrum Reginae (Savage)", "Achievement reward", 80, 3)],
        ["deinonychus"] = [Fo("The Dalriada", "Rare drop from final boss", 80, 3)],
        ["al-iklil"] = [Fo("Bozjan Southern Front", "Collect all 50 Field Notes", 80, 3)],

        // =================================================================
        //  VARIANT / CRITERION DUNGEON MOUNTS
        // =================================================================
        // EW Variant (Survey Record completion)
        ["silkie"] = [Vc("The Sil'dihn Subterrane", "Complete all survey records", 90, 4)],
        ["burabura chochin"] = [Vc("Mount Rokkon", "Complete all survey records", 90, 4)],
        ["spectral statice"] = [Vc("Aloalo Island", "Complete all survey records", 90, 4)],
        // EW Criterion (coin exchange or rare drop)
        ["sil'dihn throne"] = [Vc("Another Sil'dihn Subterrane", "100 Sil'dihn Silvers or rare drop", 90, 4)],
        ["shishioji"] = [Vc("Another Mount Rokkon", "100 Shishu Coins or rare drop", 90, 4)],
        ["quaqua"] = [Vc("Another Aloalo Island", "100 Aloalo Coins or rare drop", 90, 4)],
        // DT Criterion
        ["genie of the lamp"] = [Vc("Another Merchant's Tale", "100 Corvosi Manuscripts or rare drop", 100, 5)],
        ["royal magicked carpet"] = [Vc("Another Merchant's Tale", "100 Pieces of Corvosi Brass", 100, 5)],

        // =================================================================
        //  TREASURE MAP MOUNTS
        // =================================================================
        ["pinky"] = [Tm("The Excitatron 6000", "3 Exciting Tonics", 90, 4)],
        ["phaethon"] = [Tm("Shifting Gymnasion Agonon", "3 Burning Horns", 90, 4)],
        ["qeziigural"] = [Tm("Cenote Ja Ja Gural", "3 Twilight Gemstones", 100, 5)],
        ["dreamwalker"] = [Tm("Vault Oneiron", "Jackpot: Three 7s", 100, 5)],

        // =================================================================
        //  FATE MOUNTS
        // =================================================================
        ["ixion"] = [Ft("A Horse Outside", "12 Ixion Horns — The Lochs", 70, 2)],
        ["ironfrog mover"] = [Ft("A Finale Most Formidable", "12 Formidable Cogs — Kholusia", 80, 3)],
        ["level checker"] = [Ft("Omicron Recall: Killing Order", "12 Chi Bolts — Ultima Thule", 90, 4)],
        ["mehwapyarra"] = [Ft("The Serpentlord Seethes", "12 Ttokrrone Scales — Shaaloani", 100, 5)],

        // =================================================================
        //  FAUX HOLLOWS (UNREAL) MOUNTS
        // =================================================================
        ["construct VI-S"] = [Ex("Faux Hollows", "500 Faux Leaves from Unreal Trials", 90, 4)],
        ["venturous kamuy"] = [Ex("Faux Hollows", "600 Faux Leaves from Unreal Trials", 90, 4)],

        // =================================================================
        //  HUNT MOUNTS
        // =================================================================
        ["wyvern"] = [Ht("3,000 Centurio Seals (6 Clan Mark Logs)", 60, 1)],
        ["forgiven reticence"] = [Ht("3,200 Sacks of Nuts", 80, 3)],
        ["vinegaroon"] = [Ht("3,200 Sacks of Nuts", 90, 4)],
        ["automatoise"] = [Ht("3,200 Sacks of Nuts", 100, 5)],

        // =================================================================
        //  BLUE MAGE MOUNT
        // =================================================================
        ["morbol"] = [new() { Type = SourceType.Other, Name = "Blue Mage Content", Description = "Achievement: clear Savage raids as full BLU party", Level = 70, ExpansionId = 2 }],
    };

    // =====================================================================
    //  MINION SOURCES
    // =====================================================================
    private static readonly Dictionary<string, List<DropSource>> MinionSources = new(StringComparer.OrdinalIgnoreCase)
    {
        // =================================================================
        //  ARR DUNGEON MINIONS — Level 47-50, Expansion 0
        // =================================================================
        ["morbol seedling"] = [Dg("The Aurum Vale", 47, 0)],
        ["bite-sized pudding"] = [Dg("The Wanderer's Palace", 50, 0)],
        ["demon brick"] = [Dg("Amdapor Keep", 50, 0)],
        ["slime puddle"] = [Dg("Copperbell Mines (Hard)", 50, 0)],
        ["baby opo-opo"] = [Dg("Brayflox's Longstop (Hard)", 50, 0)],
        ["naughty nanka"] = [Dg("Hullbreaker Isle", 50, 0)],
        ["tight-beaked parrot"] = [Dg("Sastasha (Hard)", 50, 0)],
        ["mummy's little mummy"] = [Dg("The Sunken Temple of Qarn (Hard)", 50, 0)],

        // =================================================================
        //  ARR TRIAL MINIONS — Level 50, Expansion 0
        // =================================================================
        ["wind-up ultros"] = [Ex("The Dragon's Neck", "Ultros & Typhon", 50, 0)],
        ["enkidu"] = [Ex("Battle in the Big Keep", "Gilgamesh", 50, 0)],

        // =================================================================
        //  ARR ALLIANCE RAID MINIONS — Level 50, Expansion 0
        // =================================================================
        ["wind-up onion knight"] = [Ar("Syrcus Tower", 50, 0)],
        ["puff of darkness"] = [Ar("The World of Darkness", 50, 0)],

        // =================================================================
        //  HW DUNGEON MINIONS — Level 53-60, Expansion 1
        // =================================================================
        ["gaelikitten"] = [Dg("Sohm Al", 53, 1)],
        ["lesser panda"] = [Dg("The Aery", 55, 1)],
        ["unicolt"] = [Dg("The Vault", 57, 1)],
        ["page 63"] = [Dg("The Great Gubal Library", 59, 1)],
        ["ugly duckling"] = [Dg("Neverreap", 60, 1)],
        ["owlet"] = [Dg("The Fractal Continuum", 60, 1)],
        ["korpokkur kid"] = [Dg("Saint Mocianne's Arboretum", 60, 1)],
        ["calca"] = [Dg("The Antitower", 60, 1)],
        ["brina"] = [Dg("The Antitower", 60, 1)],
        ["morpho"] = [Dg("The Lost City of Amdapor (Hard)", 60, 1)],
        ["calamari"] = [Dg("Hullbreaker Isle (Hard)", 60, 1)],
        ["shaggy shoat"] = [Dg("Xelphatol", 60, 1)],
        ["bullpup"] = [Dg("Baelsar's Wall", 60, 1)],

        // =================================================================
        //  HW ALLIANCE RAID MINIONS — Level 60, Expansion 1
        // =================================================================
        ["wind-up echidna"] = [Ar("The Void Ark", 60, 1)],
        ["wind-up calofisteri"] = [Ar("The Weeping City of Mhach", 60, 1)],
        ["wind-up scathach"] = [Ar("Dun Scaith", 60, 1)],

        // =================================================================
        //  HW RAID MINIONS — Level 60, Expansion 1
        // =================================================================
        ["faustlet"] = [Sv("Alexander - The Burden of the Son (Savage)", "A6S only", 60, 1)],
        ["toy alexander"] = [Sv("Alexander - The Soul of the Creator", "A12 Normal + Savage", 60, 1)],

        // =================================================================
        //  SB DUNGEON MINIONS — Level 61-70, Expansion 2
        // =================================================================
        ["ghido"] = [Dg("The Sirensong Sea", 61, 2)],
        ["bombfish"] = [Dg("Shisui of the Violet Tides", 63, 2)],
        ["road sparrow"] = [Dg("Bardam's Mettle", 65, 2)],
        ["mock-up grynewaht"] = [Dg("Doma Castle", 67, 2)],
        ["magitek avenger F1"] = [Dg("Castrum Abania", 69, 2)],
        ["dress-up yugiri"] = [Dg("Kugane Castle", 70, 2)],
        ["ivon coeurlfist doll"] = [Dg("The Temple of the Fist", 70, 2)],
        ["salt & pepper seal"] = [Dg("The Drowned City of Skalla", 70, 2)],
        ["white whittret"] = [Dg("Hells' Lid", 70, 2)],
        ["monkey king"] = [Dg("The Swallow's Compass", 70, 2)],
        ["mudpie"] = [Dg("Saint Mocianne's Arboretum (Hard)", 70, 2)],
        ["wind-up weapon"] = [Dg("The Ghimlyt Dark", 70, 2)],

        // =================================================================
        //  SB TRIAL MINIONS — Level 70, Expansion 2
        // =================================================================
        ["poogie"] = [Ex("The Great Hunt (Extreme)", "Monster Hunter crossover — 5 Rathalos Scale+", 70, 2)],

        // =================================================================
        //  SB ALLIANCE RAID MINIONS — Level 70, Expansion 2
        // =================================================================
        ["construct 8"] = [Ar("The Ridorana Lighthouse", 70, 2)],
        ["wind-up ramza"] = [Ar("The Orbonne Monastery", 70, 2)],

        // =================================================================
        //  SB RAID MINIONS — Level 70, Expansion 2
        // =================================================================
        ["wind-up exdeath"] = [Sv("Deltascape V4.0", "O4 Normal + Savage", 70, 2)],
        ["wind-up kefka"] = [Sv("Sigmascape V4.0", "O8 Normal + Savage", 70, 2)],
        ["omg"] = [Sv("Alphascape V4.0", "O12 Normal + Savage", 70, 2)],

        // =================================================================
        //  SB EUREKA MINIONS — Level 70, Expansion 2
        // =================================================================
        ["wind-up fafnir"] = [Ek("Eureka Anemos", "Anemos Lockbox / Boss FATE", 70, 2)],
        ["wind-up mithra"] = [Ek("Eureka Anemos", "Anemos Lockbox / Boss FATE", 70, 2)],
        ["the prince of anemos"] = [Ek("Eureka Anemos", "Anemos Lockbox / Boss FATE", 70, 2)],
        ["copycat bulb"] = [Ek("Eureka Pagos", "Gold Bunny Lockbox", 70, 2)],
        ["wind-up tarutaru"] = [Ek("Eureka Pagos", "Pagos Lockbox", 70, 2)],
        ["wind-up elvaan"] = [Ek("Eureka Pyros", "Boss FATE", 70, 2)],
        ["dhalmel calf"] = [Ek("Eureka Pyros", "Pyros / Heat-warped Lockbox", 70, 2)],
        ["conditional virtue"] = [Ek("The Baldesion Arsenal", "Absolute Virtue chest", 70, 2)],
        ["yukinko snowflake"] = [Ek("Eureka Hydatos", "Hydatos / Moisture-warped Lockbox", 70, 2)],

        // =================================================================
        //  ShB DUNGEON MINIONS — Level 71-80, Expansion 3
        // =================================================================
        ["black hayate"] = [Dg("Holminster Switch", 71, 3)],
        ["tiny echevore"] = [Dg("Dohn Mheg", 73, 3)],
        ["chameleon"] = [Dg("The Qitana Ravel", 75, 3)],
        ["armadillo bowler"] = [Dg("Malikah's Well", 77, 3)],
        ["forgiven hate"] = [Dg("Mt. Gulg", 79, 3)],
        ["clionid larva"] = [Dg("Akadaemia Anyder", 80, 3)],
        ["shoebill"] = [Dg("Amaurot", 80, 3)],
        ["little leannan"] = [Dg("The Grand Cosmos", 80, 3)],
        ["ancient one"] = [Dg("Anamnesis Anyder", 80, 3)],
        ["ephemeral necromancer"] = [Dg("The Heroes' Gauntlet", 80, 3)],
        ["drippy"] = [Dg("Matoya's Relict", 80, 3)],
        ["magitek predator F1"] = [Dg("Paglth'an", 80, 3)],

        // =================================================================
        //  ShB TRIAL MINIONS — Level 80, Expansion 3
        // =================================================================
        ["giant beaver"] = [Ex("The Dancing Plague (Extreme)", "Trade 1 Dancing Wing — Titania EX", 80, 3)],

        // =================================================================
        //  ShB ALLIANCE RAID MINIONS (YoRHa) — Level 80, Expansion 3
        // =================================================================
        ["pod 054"] = [Ar("The Copied Factory", 80, 3)],
        ["pod 316"] = [Ar("The Copied Factory", 80, 3)],
        ["2B automaton"] = [Ar("The Puppets' Bunker", 80, 3)],
        ["2P automaton"] = [Ar("The Puppets' Bunker", 80, 3)],
        ["smaller stubby"] = [Ar("The Tower at Paradigm's Breach", 80, 3)],
        ["9S automaton"] = [Ar("The Tower at Paradigm's Breach", 80, 3)],

        // =================================================================
        //  ShB RAID MINIONS (Eden) — Level 80, Expansion 3
        // =================================================================
        ["eden minor"] = [Sv("Eden's Gate: Sepulture", "E4 Normal + Savage", 80, 3)],
        ["wind-up ryne"] = [Sv("Eden's Verse: Refulgence", "E8 Normal + Savage", 80, 3)],
        ["wind-up gaia"] = [Sv("Eden's Promise: Eternity", "E12 Normal + Savage", 80, 3)],

        // =================================================================
        //  ShB BOZJA MINIONS (unique to Bozja) — Level 80, Expansion 3
        // =================================================================
        ["magitek helldiver F1"] = [Fo("Castrum Lacus Litore", "Drop from Castrum", 80, 3)],
        ["dainsleif F1"] = [Fo("Bozjan Southern Front", "Southern Front Lockbox", 80, 3)],
        ["save the princess"] = [Fo("Delubrum Reginae (Savage)", "Final chest", 80, 3)],
        ["wind-up gunnhildr"] = [Fo("Bozjan Southern Front", "100 Bozjan Clusters", 80, 3)],
        ["mameshiba"] = [Fo("Bozjan Southern Front", "Lockbox drop", 80, 3)],
        ["koala joey"] = [Fo("Bozjan Southern Front", "Lockbox drop", 80, 3)],
        ["axolotl eft"] = [Fo("Bozjan Southern Front", "Lockbox drop", 80, 3)],

        // =================================================================
        //  EW DUNGEON MINIONS — Level 81-90, Expansion 4
        // =================================================================
        ["wind-up magus sisters"] = [Dg("The Tower of Zot", 81, 4)],
        ["wind-up anima"] = [Dg("The Tower of Babil", 83, 4)],
        ["hippo calf"] = [Dg("Vanaspati", 85, 4)],
        ["caduceus"] = [Dg("Ktisis Hyperboreia", 87, 4)],
        ["tiny troll"] = [Dg("The Aitiascope", 89, 4)],
        ["starbird"] = [Dg("The Dead Ends", 90, 4)],
        ["prince lunatender"] = [Dg("Smileton", 90, 4)],
        ["optimus omicron"] = [Dg("The Stigma Dreamscape", 90, 4)],
        ["teacup kapikulu"] = [Dg("Alzadaal's Legacy", 90, 4)],
        ["wind-up scarmiglione"] = [Dg("The Fell Court of Troia", 90, 4)],
        ["wind-up cagnazzo"] = [Dg("Lapis Manalis", 90, 4)],
        ["puffin"] = [Dg("The Aetherfont", 90, 4)],
        ["wind-up golbez"] = [Dg("The Lunar Subterrane", 90, 4)],

        // =================================================================
        //  EW ALLIANCE RAID MINIONS (Myths of the Realm) — Level 90, Expansion 4
        // =================================================================
        ["wind-up azeyma"] = [Ar("Aglaia", 90, 4)],
        ["wind-up halone"] = [Ar("Euphrosyne", 90, 4)],
        ["wind-up oschon"] = [Ar("Thaleia", 90, 4)],

        // =================================================================
        //  EW RAID MINIONS (Pandaemonium) — Level 90, Expansion 4
        // =================================================================
        ["nosferatu"] = [Sv("Asphodelos: The Fourth Circle", "P4 Normal + Savage", 90, 4)],
        ["wind-up erichthonios"] = [Sv("Abyssos: The Eighth Circle", "P8 Normal + Savage", 90, 4)],
        ["wind-up athena"] = [Sv("Anabaseios: The Twelfth Circle", "P12 Normal + Savage", 90, 4)],

        // =================================================================
        //  EW VARIANT / CRITERION DUNGEON MINIONS — Level 90, Expansion 4
        // =================================================================
        ["sponge silkie"] = [Vc("The Sil'dihn Subterrane", "Variant dungeon drop", 90, 4)],
        ["sewer skink"] = [Vc("The Sil'dihn Subterrane", "Variant dungeon drop", 90, 4)],
        ["okuri chochin"] = [Vc("Mount Rokkon", "Variant dungeon drop", 90, 4)],
        ["shiromaru"] = [Vc("Mount Rokkon", "Variant dungeon drop", 90, 4)],
        ["kuromaru"] = [Vc("Mount Rokkon", "Variant dungeon drop", 90, 4)],
        ["uolosapa"] = [Vc("Aloalo Island", "Variant dungeon drop", 90, 4)],
        ["repulu"] = [Vc("Aloalo Island", "Variant dungeon drop", 90, 4)],

        // =================================================================
        //  EW TREASURE MAP MINIONS — Level 90, Expansion 4
        // =================================================================
        ["royal lunatender"] = [Tm("The Excitatron 6000", "Treasure dungeon drop", 90, 4)],
        ["wind-up philos"] = [Tm("Shifting Gymnasion Agonon", "Treasure dungeon drop", 90, 4)],
        ["wind-up aidoneus"] = [Tm("Shifting Gymnasion Agonon", "Treasure dungeon drop", 90, 4)],
        ["mikra lyssa"] = [Tm("Shifting Gymnasion Agonon", "Treasure dungeon drop", 90, 4)],

        // =================================================================
        //  DT DUNGEON MINIONS — Level 91-100, Expansion 5
        // =================================================================
        ["petit punutiy"] = [Dg("Ihuykatumu", 91, 5)],
        ["rororrlo teh"] = [Dg("Worqor Zormor", 93, 5)],
        ["speaking stone"] = [Dg("The Skydeep Cenote", 95, 5)],
        ["air-wheeler M9"] = [Dg("Vanguard", 97, 5)],
        ["ambrose the unfinished"] = [Dg("Origenics", 99, 5)],
        ["tin sentry T1"] = [Dg("Alexandria", 100, 5)],
        ["tankardtender"] = [Dg("Tender Valley", 100, 5)],
        ["mischief maker"] = [Dg("The Strayborough Deadwalk", 100, 5)],
        ["shshuye"] = [Dg("Yuweyawata Field Station", 100, 5)],
        ["royal hound"] = [Dg("The Underkeep", 100, 5)],
        ["micro crow"] = [Dg("The Meso Terminal", 100, 5)],
        ["mistic condor"] = [Dg("Mistwake", 100, 5)],

        // =================================================================
        //  DT TRIAL MINIONS — Level 100, Expansion 5
        // =================================================================
        ["seikret fledgling"] = [Ex("The Windward Wilds (Extreme)", "Trade 3 Guardian Scales — MH Wilds crossover", 100, 5)],
        ["vigorwasp"] = [Ex("The Windward Wilds (Extreme)", "Trade 3 Guardian Scales — MH Wilds crossover", 100, 5)],

        // =================================================================
        //  DT ALLIANCE RAID MINIONS (Echoes of Vana'diel) — Level 100, Expansion 5
        // =================================================================
        ["nano lord"] = [Ar("Jeuno: The First Walk", 100, 5)],
        ["wind-up eald'narche"] = [Ar("San d'Oria: The Second Walk", 100, 5)],

        // =================================================================
        //  DT RAID MINIONS (Arcadion) — Level 100, Expansion 5
        // =================================================================
        ["black kitten"] = [Sv("AAC Light-heavyweight M4", "M4 Normal + Savage", 100, 5)],
        ["grooving green"] = [Sv("AAC Heavyweight M4", "M12 Normal + Savage", 100, 5)],

        // =================================================================
        //  DT CHAOTIC RAID MINIONS — Level 100, Expansion 5
        // =================================================================
        ["wisp of darkness"] = [new() { Type = SourceType.AllianceRaid, Name = "The Cloud of Darkness (Chaotic)", Description = "Rare coffer drop", Level = 100, ExpansionId = 5 }],

        // =================================================================
        //  DT VARIANT / CRITERION DUNGEON MINIONS — Level 100, Expansion 5
        // =================================================================
        ["little mermaid"] = [Vc("The Merchant's Tale", "Variant dungeon drop", 100, 5)],
        ["magic lamp"] = [Vc("The Merchant's Tale", "Variant dungeon drop", 100, 5)],
        ["soothing sea-beast"] = [Vc("The Merchant's Tale", "12 Corvosi Brass", 100, 5)],

        // =================================================================
        //  DT TREASURE MAP MINIONS — Level 100, Expansion 5
        // =================================================================
        ["honeysuckler"] = [Tm("Cenote Ja Ja Gural", "Treasure dungeon drop", 100, 5)],
        ["the lawnblazer"] = [Tm("Cenote Ja Ja Gural / Vault Oneiron", "Treasure dungeon drop", 100, 5)],
        ["mini yan"] = [Tm("Vault Oneiron", "Treasure dungeon drop", 100, 5)],
        ["gimme kitten"] = [Tm("Vault Oneiron", "Treasure dungeon drop", 100, 5)],

        // =================================================================
        //  DT DEEP DUNGEON MINIONS (Pilgrim's Traverse) — Level 100, Expansion 5
        // =================================================================
        ["toco toquito"] = [Dd("Pilgrim's Traverse", "Silver Sack", 100, 5)],
        ["spinettesaurus"] = [Dd("Pilgrim's Traverse", "Silver Sack", 100, 5)],
        ["wind-up feo ul"] = [Dd("Pilgrim's Traverse", "Gold Sack", 100, 5)],
        ["sin beaver"] = [Dd("Pilgrim's Traverse", "25 Phials of Luminous Oil", 100, 5)],

        // =================================================================
        //  ShB TREASURE MAP MINIONS — Level 80, Expansion 3
        // =================================================================
        ["wind-up fuath"] = [Tm("The Dungeons of Lyhe Ghiah", "Treasure dungeon drop", 80, 3)],
        ["golden beaver"] = [Tm("The Shifting Oubliettes of Lyhe Ghiah", "Treasure dungeon drop", 80, 3)],
        ["sungold talos"] = [Tm("The Shifting Oubliettes of Lyhe Ghiah", "Treasure dungeon drop", 80, 3)],

        // =================================================================
        //  SB TREASURE MAP MINIONS — Level 70, Expansion 2
        // =================================================================
        ["wind-up namazu"] = [Tm("Gazelleskin Maps", "Map reward", 70, 2)],
        ["wind-up matanga"] = [Tm("The Hidden Canals of Uznair", "Treasure dungeon drop", 70, 2)],
        ["the gold whisker"] = [Tm("The Hidden Canals of Uznair", "Treasure dungeon drop", 70, 2)],
        ["capybara pup"] = [Tm("Lost/Hidden Canals of Uznair", "Treasure dungeon drop", 70, 2)],
        ["hedgehoglet"] = [Tm("Lost/Hidden Canals of Uznair", "Treasure dungeon drop", 70, 2)],

        // =================================================================
        //  FATE MINIONS
        // =================================================================
        ["wind-up ixion"] = [Ft("A Horse Outside", "5 Ixion Horns — The Lochs", 70, 2)],
        ["fox pup"] = [Ft("Foxy Lady", "3 Sassho-seki Fragments — Yanxia", 70, 2)],
        ["wind-up daivadipa"] = [Ft("Devout Pilgrims vs. Daivadipa", "Beads exchange — Thavnair", 90, 4)],
    };
}
