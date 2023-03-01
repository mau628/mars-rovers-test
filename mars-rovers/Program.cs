using System.Diagnostics.CodeAnalysis;

using mars_rovers.ConsoleHandler;
using mars_rovers.RoverNavigator;

using Microsoft.Extensions.DependencyInjection;

[ExcludeFromCodeCoverage]
internal class Program
{
    private static void Main(string[] args)
    {
        // Setup dependency injection.
        // ConsoleHandler is a wrapper around the System.Console class. It is used to make the program testable.
        // RoverNavigator is the main logic of the program. It is used to navigate the rovers according to the input values.
        var services = new ServiceCollection()
            .AddSingleton<IConsoleHandler, ConsoleHandler>()
            .AddSingleton<IRoverNavigator, RoverNavigator>();

        var serviceProvider = services.BuildServiceProvider();
        var console = serviceProvider.GetService<IConsoleHandler>()!;
        var roverNavigator = serviceProvider.GetService<IRoverNavigator>()!;

        console.WriteLine(
            "Type the input values. Press enter after each value. Press enter again to start the program."
        );

        // Read the input values from the console.
        var inputValues = new List<string>();
        string? currentInput;
        do
        {
            currentInput = console.ReadLine();
            if (!string.IsNullOrWhiteSpace(currentInput))
            {
                inputValues.Add(currentInput);
            }
        } while (!string.IsNullOrWhiteSpace(currentInput));

        // Perform the main logic of the program. Navigate the rovers according to the input values.
        roverNavigator.NavigateAll(inputValues);

        // Wait for the user to press enter before closing the program.
        console.ReadLine();
    }
}
