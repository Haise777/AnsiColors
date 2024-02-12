namespace AnsiStyles;

/// <summary>
/// A object with special values and methods that can be integrated in strings as a standard string itself.
/// </summary>
public class AnsiColor
{
    public string Code { get; private set; }

    public AnsiColor(string code)
    {
        Code = code;
    }

    //Styles
    private AnsiColor ApplyStyle(byte sgrCode)
    {
        Code = Code.Insert(0, $"{Globals.EscapeCode}[{sgrCode}m");
        return this;
    }

    /// <summary>
    /// Apply Bold style to the current AnsiColor onwards.
    /// </summary>
    /// <returns>Same <c>AnsiColor</c> object reference</returns>
    public AnsiColor Bold() => ApplyStyle(1);

    /// <summary>
    /// Apply Outline style to the current AnsiColor onwards.
    /// </summary>
    /// <returns>Same <c>AnsiColor</c> object reference</returns>
    public AnsiColor Outline() => ApplyStyle(4);

    /// <summary>
    /// Apply Blinking style to the current AnsiColor onwards.
    /// </summary>
    /// <returns>Same <c>AnsiColor</c> object reference</returns>
    public AnsiColor Blinking() => ApplyStyle(5);

    /// <summary>
    /// Apply Faint style to the current AnsiColor onwards.
    /// </summary>
    /// <returns>Same <c>AnsiColor</c> object reference</returns>
    public AnsiColor Faint() => ApplyStyle(2);

    public override string ToString() => Code;

    public static AnsiColor operator +(AnsiColor first, AnsiColor then)
    {
        first.Code += then.Code;
        return first;
    }

    public static AnsiColor operator +(AnsiColor first, string then)
    {
        first.Code += then;
        return first;
    }

    public static AnsiColor operator +(string first, AnsiColor then)
    {
        then.Code = then.Code.Insert(0, first);
        return then;
    }
}