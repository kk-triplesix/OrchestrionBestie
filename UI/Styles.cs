using System.Numerics;

namespace FarmingBestie.UI;

public static class Styles
{
    public static readonly Vector4 BgDark = new(0.10f, 0.10f, 0.18f, 1.00f);
    public static readonly Vector4 BgMedium = new(0.09f, 0.13f, 0.24f, 1.00f);
    public static readonly Vector4 BgLight = new(0.12f, 0.16f, 0.28f, 1.00f);
    public static readonly Vector4 AccentBlue = new(0.06f, 0.20f, 0.38f, 1.00f);
    public static readonly Vector4 AccentCyan = new(0.33f, 0.79f, 0.79f, 1.00f);
    public static readonly Vector4 AccentGreen = new(0.31f, 0.80f, 0.64f, 1.00f);
    public static readonly Vector4 AccentGold = new(1.00f, 0.85f, 0.20f, 1.00f);
    public static readonly Vector4 TextPrimary = new(0.92f, 0.93f, 0.95f, 1.00f);
    public static readonly Vector4 TextSecondary = new(0.60f, 0.63f, 0.70f, 1.00f);
    public static readonly Vector4 TextDimmed = new(0.40f, 0.42f, 0.48f, 1.00f);
    public static readonly Vector4 TextGreen = new(0.31f, 0.80f, 0.64f, 1.00f);
    public static readonly Vector4 BorderColor = new(0.18f, 0.22f, 0.34f, 1.00f);
    public static readonly Vector4 ButtonBg = new(0.06f, 0.20f, 0.38f, 1.00f);
    public static readonly Vector4 ButtonHover = new(0.10f, 0.28f, 0.48f, 1.00f);
    public static readonly Vector4 ButtonActive = new(0.15f, 0.35f, 0.55f, 1.00f);

    private static readonly Stack<(int Styles, int Colors)> StyleStack = new();
    private static int _styleCount;
    private static int _colorCount;

    public static void PushMainStyle()
    {
        _styleCount = 0;
        _colorCount = 0;

        Push(ImGuiStyleVar.WindowRounding, 8.0f);
        Push(ImGuiStyleVar.FrameRounding, 4.0f);
        Push(ImGuiStyleVar.GrabRounding, 4.0f);
        Push(ImGuiStyleVar.ScrollbarRounding, 4.0f);
        Push(ImGuiStyleVar.TabRounding, 4.0f);
        Push(ImGuiStyleVar.WindowPadding, new Vector2(12, 12));
        Push(ImGuiStyleVar.FramePadding, new Vector2(8, 4));
        Push(ImGuiStyleVar.ItemSpacing, new Vector2(8, 6));
        Push(ImGuiStyleVar.CellPadding, new Vector2(6, 4));

        Push(ImGuiCol.WindowBg, BgDark);
        Push(ImGuiCol.ChildBg, BgMedium);
        Push(ImGuiCol.PopupBg, BgMedium);
        Push(ImGuiCol.Border, BorderColor);
        Push(ImGuiCol.FrameBg, BgLight);
        Push(ImGuiCol.FrameBgHovered, AccentBlue);
        Push(ImGuiCol.Button, ButtonBg);
        Push(ImGuiCol.ButtonHovered, ButtonHover);
        Push(ImGuiCol.ButtonActive, ButtonActive);
        Push(ImGuiCol.Header, AccentBlue);
        Push(ImGuiCol.HeaderHovered, ButtonHover);
        Push(ImGuiCol.Tab, BgMedium);
        Push(ImGuiCol.TabHovered, AccentBlue);
        Push(ImGuiCol.TableHeaderBg, new Vector4(0.08f, 0.11f, 0.20f, 1.00f));
        Push(ImGuiCol.TableRowBgAlt, new Vector4(0.11f, 0.14f, 0.24f, 0.50f));
        Push(ImGuiCol.Text, TextPrimary);
        Push(ImGuiCol.TextDisabled, TextDimmed);
        Push(ImGuiCol.Separator, BorderColor);
        Push(ImGuiCol.CheckMark, AccentCyan);

        StyleStack.Push((_styleCount, _colorCount));
    }

    public static void PopMainStyle()
    {
        var (styles, colors) = StyleStack.Pop();
        ImGui.PopStyleColor(colors);
        ImGui.PopStyleVar(styles);
    }

    private static void Push(ImGuiStyleVar v, float val) { ImGui.PushStyleVar(v, val); _styleCount++; }
    private static void Push(ImGuiStyleVar v, Vector2 val) { ImGui.PushStyleVar(v, val); _styleCount++; }
    private static void Push(ImGuiCol c, Vector4 val) { ImGui.PushStyleColor(c, val); _colorCount++; }
}
