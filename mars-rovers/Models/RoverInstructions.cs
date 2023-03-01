namespace mars_rovers.Models;

public class RoverInstructions
{
    public RoverDirection Direction { get; internal set; }
    private readonly string _instructions;

    public RoverInstructions(string currentPosition, string instructions)
    {
        var positionValues = currentPosition.ToUpper().Split(' ');
        Direction = new()
        {
            X = int.Parse(positionValues[0]),
            Y = int.Parse(positionValues[1]),
            Z = (RoverDirection.Direction)positionValues[2][0]
        };
        _instructions = instructions.ToUpper().Trim();
    }

    public void Move()
    {
        foreach (var instruction in _instructions)
        {
            switch (instruction)
            {
                case RoverDirection.LEFT:
                case RoverDirection.RIGHT:
                    Direction.Turn(instruction);
                    break;
                case RoverDirection.MOVE:
                    Direction.Move();
                    break;
                default:
                    break;
            }
        }
    }

    public override string ToString()
    {
        return $"{Direction.X} {Direction.Y} {Direction.Z}";
    }
}
