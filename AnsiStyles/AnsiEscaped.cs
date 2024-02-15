namespace AnsiStyles;

/// <summary>
/// A object with special values and methods that can be integrated in strings as a standard string itself.
/// </summary>
public class AnsiEscaped
{
    /// <summary>
    /// A ANSI escaped value stored as a string
    /// </summary>
    public string Value { get; private set; }

    /// <summary>
    /// <para>Creates a instance of the object.</para>
    /// <para>Normally you should let <see cref="StyleGroup"/> create a instance for you.</para>
    /// </summary>
    /// <param name="value">The ANSI value to be stored</param>
    public AnsiEscaped(string value)
    {
        Value = value;
    }

    //Styles
    private AnsiEscaped ApplyStyle(byte sgrValue)
    {
        Value = Value.Insert(0, $"{Globals.EscapeValue}[{sgrValue}m");
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
    
    /// <returns>A string containing an ANSI escaped value</returns>
    public override string ToString() => Value;

    /// <summary>
    /// Concat two AnsiEscaped instances into a single object.
    /// </summary>
    /// <param name="first">left side</param>
    /// <param name="then">right side</param>
    /// <returns>A single <c>AnsiEscaped</c> object reference</returns>
    public static AnsiEscaped operator +(AnsiEscaped first, AnsiEscaped then)
    {
        first.Value += then.Value;
        return first;
    }
    
    /// <summary>
    /// Concat a common string with a AnsiEscaped object.
    /// </summary>
    /// <param name="first">left side</param>
    /// <param name="then">right side</param>
    /// <returns>A single <c>AnsiEscaped</c> object reference</returns>
    public static AnsiEscaped operator +(AnsiEscaped first, string then)
    {
        first.Value += then;
        return first;
    }

    /// <summary>
    /// Concat a common string before the AnsiEscaped value, thus the concatenated string will not be affected by it.
    /// </summary>
    /// <param name="first">left side</param>
    /// <param name="then">right side</param>
    /// <returns>A single <c>AnsiEscaped</c> object reference</returns>
    public static AnsiEscaped operator +(string first, AnsiEscaped then)
    {
        then.Value = then.Value.Insert(0, first);
        return then;
    }
}