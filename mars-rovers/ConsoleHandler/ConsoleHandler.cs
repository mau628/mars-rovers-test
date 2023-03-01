namespace mars_rovers.ConsoleHandler;

public class ConsoleHandler : IConsoleHandler
{
    public ConsoleColor ForegroundColor
    {
        get => Console.ForegroundColor;
        set => Console.ForegroundColor = value;
    }

    public int CursorTop => Console.CursorTop;

    public void Write(string value)
    {
        Console.Write(value);
    }

    public void WriteLine(string value)
    {
        Console.WriteLine(value);
    }

    public void WriteLine()
    {
        Console.WriteLine();
    }

    public void SetCursorPosition(int left, int top)
    {
        Console.SetCursorPosition(left, top);
    }

    public string? ReadLine()
    {
        return Console.ReadLine();
    }
}
