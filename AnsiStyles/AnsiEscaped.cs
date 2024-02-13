namespace AnsiStyles;

/// <summary>
/// A object with special values and methods that can be integrated in strings as a standard string itself.
/// </summary>
public class AnsiEscaped
{
    /// <summary>
    /// A ANSI escaped code stored as a string
    /// </summary>
    public string Code { get; private set; }

    public AnsiEscaped(string code)
    {
        Code = code;
    }

    //Styles
    private AnsiEscaped ApplyStyle(byte sgrCode)
    {
        Code = Code.Insert(0, $"{Globals.EscapeCode}[{sgrCode}m");
        return this;
    }

    /// <summary>
    /// Apply Bold style to the current AnsiEscaped onwards.
    /// </summary>
    /// <returns>Same <c>AnsiEscaped</c> object reference</returns>
    public AnsiEscaped Bold() => ApplyStyle(1);

    /// <summary>
    /// Apply Outline style to the current AnsiEscaped onwards.
    /// </summary>
    /// <returns>Same <c>AnsiEscaped</c> object reference</returns>
    public AnsiEscaped Outline() => ApplyStyle(4);

    /// <summary>
    /// Apply Blinking style to the current AnsiEscaped onwards.
    /// </summary>
    /// <returns>Same <c>AnsiEscaped</c> object reference</returns>
    public AnsiEscaped Blinking() => ApplyStyle(5);

    /// <summary>
    /// Apply Faint style to the current AnsiEscaped onwards.
    /// </summary>
    /// <returns>Same <c>AnsiEscaped</c> object reference</returns>
    public AnsiEscaped Faint() => ApplyStyle(2);

    public override string ToString() => Code;

    /// Concat two AnsiEscaped instances into a single object.
    public static AnsiEscaped operator +(AnsiEscaped first, AnsiEscaped then)
    {
        first.Code += then.Code;
        return first;
    }

    /// Concat a common string with a AnsiEscaped object.
    public static AnsiEscaped operator +(AnsiEscaped first, string then)
    {
        first.Code += then;
        return first;
    }

    /// Concat a common string before the AnsiEscaped code, thus the concatenated string will not be affected by it.
    public static AnsiEscaped operator +(string first, AnsiEscaped then)
    {
        then.Code = then.Code.Insert(0, first);
        return then;
    }
}