namespace mars_rovers.ConsoleHandler;

using System;

public interface IConsoleHandler
{
    ConsoleColor ForegroundColor { get; set; }
    int CursorTop { get; }
    void Write(string value);
    void WriteLine(string value);
    void WriteLine();
    void SetCursorPosition(int left, int top);
    string? ReadLine();
}