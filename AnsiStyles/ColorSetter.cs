using System.Drawing;

namespace AnsiStyles;

/// <summary>
/// Provides a collection of 256 ANSI escaped color codes to be used in any string
/// </summary>
public class ColorSetter
{
    private readonly string[] _colorCodes;

    /// <summary>
    /// Get any of the 256 colors by passing a <c>index</c> starting from 0
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object that can be integrated in strings as a standard string itself</returns>
    public AnsiColor this[int index] => new(_colorCodes[index]);

    /// <summary>
    /// Get a standard Black 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Black color</returns>
    public AnsiColor Black => this[0];

    /// <summary>
    /// Get a standard Red 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Red color</returns>
    public AnsiColor Red => this[1];

    /// <summary>
    /// Get a standard Green 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Green color</returns>
    public AnsiColor Green => this[2];

    /// <summary>
    /// Get a standard Yellow 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Yellow color</returns>
    public AnsiColor Yellow => this[3];

    /// <summary>
    /// Get a standard Blue 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Blue color</returns>
    public AnsiColor Blue => this[4];

    /// <summary>
    /// Get a standard Pink 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Pink color</returns>
    public AnsiColor Pink => this[5];

    /// <summary>
    /// Get a standard Black 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Black color</returns>
    public AnsiColor Cyan => this[6];

    /// <summary>
    /// Get a standard Bright Gray 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Bright Gray color</returns>
    public AnsiColor BrightGray => this[7];

    /// <summary>
    /// Get a standard Gray 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Gray color</returns>
    public AnsiColor Gray => this[8];

    /// <summary>
    /// Get a standard Bright Red 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Bright Red color</returns>
    public AnsiColor BrightRed => this[9];

    /// <summary>
    /// Get a standard Bright Green 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Bright Green color</returns>
    public AnsiColor BrightGreen => this[10];

    /// <summary>
    /// Get a standard Bright Yellow 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Bright Yellow color</returns>
    public AnsiColor BrightYellow => this[11];

    /// <summary>
    /// Get a standard Bright Blue 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Bright Blue color</returns>
    public AnsiColor BrightBlue => this[12];

    /// <summary>
    /// Get a standard Bright Pink 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Bright Pink color</returns>
    public AnsiColor BrightPink => this[13];

    /// <summary>
    /// Get a standard Bright Cyan 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with Bright Cyan color</returns>
    public AnsiColor BrightCyan => this[14];

    /// <summary>
    /// Get a standard White 4-bit color
    /// </summary>
    /// <returns>A <c>AnsiColor</c> object set with White color</returns>
    public AnsiColor White => this[15];

    public ColorSetter(ColorPlane colorPlane)
    {
        _colorCodes = InitializeColorCodes((byte)colorPlane);
    }

    /// <summary>
    /// Creates a rainbowish coloured text with the darker variant of the default 4-bit colors
    /// </summary>
    /// <param name="text">Text to be rainbomized</param>
    /// <param name="groupCount">Number of chars to be in the same color</param>
    /// <returns>A <c>AnsiColor</c> object containing the rainbomized input text</returns>
    public AnsiColor RainbowDark4(string text, int groupCount = 1)
        => MakeRainbow(text, groupCount, 1, 6);

    /// <summary>
    /// Creates a rainbowish coloured text with the brighter variant of the default 4-bit colors
    /// </summary>
    /// <param name="text">Text to be rainbomized</param>
    /// <param name="groupCount">Number of chars to be in the same color</param>
    /// <returns>A <c>AnsiColor</c> object containing the rainbomized input text</returns>
    public AnsiColor RainbowBright4(string text, int offset = 1)
        => MakeRainbow(text, offset, 9, 14);

    /// <summary>
    /// Prints all the 256 colors to the stdout
    /// </summary>
    public void ColorTest()
    {
        for (int i = 0; i < 256; i++)
        {
            if (i % 10 == 0) Console.Write("\n");
            Console.Write($"{this[i]}{i:000}{Colors.Reset} ");
        }
    }

    private AnsiColor MakeRainbow(string text, int offset, int minIndex, int maxIndex)
    {
        var letterGroups = new List<string>();
        var colorIndex = minIndex;
        for (int i = 0; i < text.Length; i += offset)
        {
            letterGroups.Add(_colorCodes[colorIndex++] + text[i..(i + offset)] + Colors.Reset);
            if (colorIndex > maxIndex) colorIndex = minIndex;
        }

        return new AnsiColor(string.Concat(letterGroups));
    }

    private static string[] InitializeColorCodes(byte colorPlane)
    {
        var colors = new string[256];
        for (int i = 0; i < colors.Length; i++)
            colors[i] = $"{Globals.EscapeCode}[{colorPlane};5;{i}m";

        return colors;
    }
}

/// <summary>
/// The two available ANSI color plane values named
/// </summary>
public enum ColorPlane : byte
{
    Foreground = 38,
    Background = 48
}