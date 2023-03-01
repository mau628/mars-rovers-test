using System.Diagnostics.CodeAnalysis;

using mars_rovers;
using mars_rovers.ConsoleHandler;

using Microsoft.Extensions.DependencyInjection;

[ExcludeFromCodeCoverage]
internal class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection()
            .AddSingleton<IConsoleHandler, ConsoleHandler>()
            .AddSingleton<IRoverNavigator, RoverNavigator>();
        var serviceProvider = services.BuildServiceProvider();

        var console = serviceProvider.GetService<IConsoleHandler>()!;
        var roverNavigator = serviceProvider.GetService<IRoverNavigator>()!;

        console.WriteLine(
            "Type the input values. Press enter after each value. Press enter again to start the program."
        );

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

        roverNavigator.NavigateAll(inputValues);

        console.ReadLine();
    }
}
