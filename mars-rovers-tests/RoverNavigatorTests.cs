namespace mars_rovers_tests;

using FluentAssertions;

using mars_rovers.ConsoleHandler;
using mars_rovers.RoverNavigator;

using Moq;

using Xunit;

public class RoverNavigatorTests
{
    [Fact]
    public void ShouldReturnValidValues()
    {
        // Given
        var inputValues = new List<string>
        {
            "5 5",
            "1 2 N",
            "LMLMLMLMM",
            "3 3 E",
            "MMRMMRMRRM",
            "1 1 N",
            "MMRMLMMRMMMR",
            "3 3 W",
            "MMLMMRRR",
            "3 3 N",
            "RRRR"
        };
        var consoleHandlerMock = new Mock<IConsoleHandler>();
        var roverNavigator = new RoverNavigator(consoleHandlerMock.Object);

        // When
        var result = roverNavigator.NavigateAll(inputValues);

        // Then
        result.Count.Should().Be(5);
        result[0].ToString().Should().Be("1 3 N");
        result[1].ToString().Should().Be("5 1 E");
        result[2].ToString().Should().Be("5 5 S");
        result[3].ToString().Should().Be("1 1 E");
        result[4].ToString().Should().Be("3 3 N");
    }

    [Fact]
    public void ShouldThrowExceptionWhenGridIsSmallerThanResult()
    {
        // Given
        var inputValues = new List<string> { "0 0", "1 2 N", "LMLMLMLMM" };
        var consoleHandlerMock = new Mock<IConsoleHandler>();
        var roverNavigator = new RoverNavigator(consoleHandlerMock.Object);

        // When
        Action result = () => roverNavigator.NavigateAll(inputValues);

        // Then
        result.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ShouldThrowExceptionWhenRoverInstructionsAreMissing()
    {
        // Given
        var inputValues = new List<string> { "5 5", "1 2 N" };
        var consoleHandlerMock = new Mock<IConsoleHandler>();
        var roverNavigator = new RoverNavigator(consoleHandlerMock.Object);

        // When
        Action result = () => roverNavigator.NavigateAll(inputValues);

        // Then
        result.Should().Throw<ArgumentException>();
    }
}
