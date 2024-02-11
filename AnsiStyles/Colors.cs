namespace AnsiStyles;

public static class Colors
{
    public static string Reset => $"{Global.EscapeCode}[0m";
    public static ColorSet Foreground { get; } = new(ColorPlane.Foreground);
    public static ColorSet Background { get; } = new(ColorPlane.Background);
}