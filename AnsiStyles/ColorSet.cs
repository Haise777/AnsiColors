namespace AnsiStyles;

public class ColorSet
{
    private readonly string[] _colorCodes;
    public AnsiColor this[int index] => new(_colorCodes[index]);

    public AnsiColor Black => this[0];
    public AnsiColor Red => this[1];
    public AnsiColor Green => this[2];
    public AnsiColor Yellow => this[3];
    public AnsiColor Blue => this[4];
    public AnsiColor Pink => this[5];
    public AnsiColor Cyan => this[6];
    public AnsiColor BrightGray => this[7];
    public AnsiColor Gray => this[8];
    public AnsiColor BrightRed => this[9];
    public AnsiColor BrightGreen => this[10];
    public AnsiColor BrightYellow => this[11];
    public AnsiColor BrightBlue => this[12];
    public AnsiColor BrightPink => this[13];
    public AnsiColor BrightCyan => this[14];
    public AnsiColor White => this[15];

    public ColorSet(ColorPlane colorPlane)
    {
        _colorCodes = InitializeColorCodes((byte)colorPlane);
    }

    public void ColorTest()
    {
        for (int i = 0; i < 256; i++)
        {
            if (i % 10 == 0) Console.Write("\n");
            Console.Write($"{this[i]}{i:000}{Colors.Reset} ");
        }
    }

    private static string[] InitializeColorCodes(byte colorPlane)
    {
        var colors = new string[256];
        for (int i = 0; i < colors.Length; i++)
            colors[i] = new string($"{Global.EscapeCode}[{colorPlane};5;{i}m");

        return colors;
    }
}

public enum ColorPlane : byte
{
    Foreground = 35,
    Background = 48
}