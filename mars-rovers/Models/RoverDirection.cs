namespace mars_rovers.Models;

public class RoverDirection
{
    public enum Direction
    {
        N = 'N',
        E = 'E',
        S = 'S',
        W = 'W'
    }

    public const char LEFT = 'L';
    public const char RIGHT = 'R';
    public const char MOVE = 'M';

    public int X { get; set; }
    public int Y { get; set; }
    public Direction Z { get; set; }

    public string StartArrow =>
        Z switch
        {
            Direction.N => "↑",
            Direction.E => "→",
            Direction.S => "↓",
            Direction.W => "←",
            _ => "",
        };

    public string EndArrow =>
        Z switch
        {
            Direction.N => "▲",
            Direction.E => "►",
            Direction.S => "▼",
            Direction.W => "◄",
            _ => "",
        };

    /// <summary>
    /// Performs a rover turn to the left or right depending on the direction parameter.
    /// </summary>
    public void Turn(char direction)
    {
        if (direction == RIGHT)
        {
            switch (Z)
            {
                case Direction.N:
                    Z = Direction.E;
                    break;
                case Direction.E:
                    Z = Direction.S;
                    break;
                case Direction.S:
                    Z = Direction.W;
                    break;
                case Direction.W:
                    Z = Direction.N;
                    break;
                default:
                    break;
            }
        }
        else if (direction == LEFT)
        {
            switch (Z)
            {
                case Direction.N:
                    Z = Direction.W;
                    break;
                case Direction.E:
                    Z = Direction.N;
                    break;
                case Direction.S:
                    Z = Direction.E;
                    break;
                case Direction.W:
                    Z = Direction.S;
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Moves the rover one step in the direction it is facing.
    /// </summary>
    public void Move()
    {
        switch (Z)
        {
            case Direction.N:
                Y++;
                break;
            case Direction.E:
                X++;
                break;
            case Direction.S:
                Y--;
                break;
            case Direction.W:
                X--;
                break;
            default:
                break;
        }
    }
}
