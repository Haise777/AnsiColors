namespace AnsiStyles;

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
        Code = Code.Insert(0, $"{Global.EscapeCode}[{sgrCode}m");
        return this;
    }

    public AnsiColor Bold() => ApplyStyle(1);
    public AnsiColor Outline() => ApplyStyle(4);
    public AnsiColor Blinking() => ApplyStyle(5);
    public AnsiColor Faint() => ApplyStyle(2);

    public override string ToString()
    {
        return Code;
    }

    public static AnsiColor operator +(AnsiColor first, AnsiColor then)
    {
        first.Code += then.Code;
        return first;
    }
}