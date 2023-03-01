namespace mars_rovers;

using System;
using System.Collections.Generic;

using mars_rovers.ConsoleHandler;
using mars_rovers.Models;

public class RoverNavigator : IRoverNavigator
{
    private readonly IConsoleHandler _consoleHandler;

    public RoverNavigator(IConsoleHandler consoleHandler)
    {
        _consoleHandler = consoleHandler;
    }

    public List<RoverInstructions> NavigateAll(List<string> inputValues)
    {
        var inputQueue = new Queue<string>(inputValues);

        if ((inputValues.Count - 1) % 2 != 0)
        {
            throw new ArgumentException("Invalid input. The number of input values must be even.");
        }

        var grid = new RoverGrid(inputQueue.Dequeue());
        var result = new List<RoverInstructions>();

        while (inputQueue.Count > 0)
        {
            var rover = new RoverInstructions(inputQueue.Dequeue(), inputQueue.Dequeue());
            _consoleHandler.Write($"Initial position (");
            _consoleHandler.ForegroundColor = ConsoleColor.Red;
            _consoleHandler.Write(rover.Direction.EndArrow);
            _consoleHandler.ForegroundColor = ConsoleColor.White;
            _consoleHandler.WriteLine($"): {rover}");
            for (int x = 1; x <= grid.Width; x++)
            {
                for (int y = 1; y <= grid.Height; y++)
                {
                    _consoleHandler.Write(" ■");
                }
                _consoleHandler.WriteLine();
            }
            _consoleHandler.ForegroundColor = ConsoleColor.Red;
            var consoleY = _consoleHandler.CursorTop;
            _consoleHandler.SetCursorPosition(
                (rover.Direction.X * 2) - 1,
                consoleY - rover.Direction.Y
            );
            _consoleHandler.Write(rover.Direction.EndArrow);

            rover.Move();

            if (rover.Direction.X > grid.Width || rover.Direction.Y > grid.Height)
            {
                throw new ArgumentException($"Rover {rover} is out of bounds.");
            }
            result.Add(rover);

            _consoleHandler.ForegroundColor = ConsoleColor.Green;
            _consoleHandler.SetCursorPosition(
                (rover.Direction.X * 2) - 1,
                consoleY - rover.Direction.Y
            );
            _consoleHandler.Write(rover.Direction.StartArrow);
            _consoleHandler.SetCursorPosition(0, consoleY);

            _consoleHandler.ForegroundColor = ConsoleColor.White;
            _consoleHandler.Write($"Final position (");
            _consoleHandler.ForegroundColor = ConsoleColor.Green;
            _consoleHandler.Write(rover.Direction.StartArrow);
            _consoleHandler.ForegroundColor = ConsoleColor.White;
            _consoleHandler.WriteLine($"): {rover}");
            _consoleHandler.WriteLine();
            _consoleHandler.WriteLine();
        }

        return result;
    }
}
