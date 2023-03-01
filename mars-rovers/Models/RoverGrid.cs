namespace mars_rovers.Models;

public class RoverGrid
{
    public int Width { get; internal set; }
    public int Height { get; internal set; }

    public RoverGrid(string gridSize)
    {
        var gridValues = gridSize.Split(' ');
        Width = int.Parse(gridValues[0]);
        Height = int.Parse(gridValues[1]);
    }
}
