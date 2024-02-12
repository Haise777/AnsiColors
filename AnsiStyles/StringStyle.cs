namespace AnsiStyles;

/// <summary>
/// Provides access to ANSI escaped 8-bit colors that can be used in any strings.
/// </summary>
public static class StringStyle
{
    /// <summary>
    /// Reset the text color and style to the default from this point onwards
    /// <example><code>
    /// string text = $"This is blue {Reset}but this is not";
    /// </code></example>
    /// <example><code>
    /// Console.WriteLine("This could be red");
    /// Console.WriteLine($"{Reset}");
    /// Console.WriteLine("But this can't");
    /// </code></example>
    /// <returns>A string with ANSI escaped reset code</returns>
    /// </summary>
    public static string Reset => $"{Globals.EscapeCode}[0m";

    /// <summary>
    /// Provides a index-able object with collection of 256 colors that can be used to set the foreground color in any string
    /// <example><code>
    /// var reset = StringStyle.Reset;
    /// var fc = StringStyle.Foreground;
    /// var red = fc[196];
    ///  
    /// string text = $"This{fc[171]} purple warning{reset} is not marked as {red}red";
    /// </code></example>
    /// </summary>
    public static ColorSetter Foreground { get; } = new(ColorPlane.Foreground);

    /// <summary>
    /// Provides a index-able object with collection of 256 colors that can be used to set the background color in any string
    /// <example><code>
    /// var reset = StringStyle.Reset;
    /// var bc = StringStyle.Foreground;
    /// var red = bc[196];
    ///  
    /// string text = $"This{bc[171]} purple warning{reset} is not marked as {red}red";
    /// </code></example>
    /// </summary>
    public static ColorSetter Background { get; } = new(ColorPlane.Background);
}