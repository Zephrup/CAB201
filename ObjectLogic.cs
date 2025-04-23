namespace CAB201_Project;

/// <summary>
/// Contains Logic relating to various objects
/// </summary>
public class ObjectLogic
{
    private LogicMethods _logicMethods = new LogicMethods();
    private static readonly List<Obstacle> Obstacles = new (); // List that handles all objects
    
    /// <summary>
    /// Adds a Guard to the list of obstacles
    /// </summary>
    /// <param name="input">The input parameters for the guard.</param>
    /// <remarks>Uses logical methods to determine a valid input</remarks>
    public void AddGuard(string[] input)
    {
        _logicMethods.IsCorrectArguments(input, 4);
        _logicMethods.IsCoordinates(input[2], out int x, input[3], out int y, null);
        Obstacles.Add(new Guard(x, y));
        Console.WriteLine("Successfully added guard obstacle.");
    }
    
    /// <summary>
    /// Adds a Fence to the list of obstacles
    /// </summary>
    /// <param name="input">The input parameters for the Fence.</param>
    /// <exception cref="ObjectAddException">Thrown when the input arguments are incorrect</exception>>
    /// <remarks>Uses logical methods to determine a valid input</remarks>
    public void AddFence(string[] input)
    {
        _logicMethods.IsCorrectArguments(input, 6);
        _logicMethods.IsCoordinates(input[2], out int x, input[3], out int y, null);
        if (input[4] != "east" && input[4] != "north") 
            throw new ObjectAddException("Orientation must be 'east' or 'north'.");
        if (!int.TryParse(input[5], out int length) || length <= 0)
            throw new ObjectAddException("Length must be a valid integer greater than 0.");
        Obstacles.Add(new Fence(x, y, input[4], length));
        Console.WriteLine("Successfully added fence obstacle.");
    }

    /// <summary>
    /// Adds a Sensor to the list of obstacles
    /// </summary>
    /// <param name="input">The input parameters for the Sensor.</param>
    /// <exception cref="ObjectAddException">Thrown when the input arguments are incorrect</exception>>
    /// <remarks>Uses logical methods to determine a valid input</remarks>
    public void AddSensor(string[] input)
    {
        _logicMethods.IsCorrectArguments(input, 5);
        _logicMethods.IsCoordinates(input[2], out int x, input[3], out int y, null);
        if (!float.TryParse(input[4], out float range) || range <= 0)
            throw new ObjectAddException("Range must be a valid positive number.");
        Obstacles.Add(new Sensor(x, y, range));
        Console.WriteLine("Successfully added sensor obstacle.");
    }

    /// <summary>
    /// Adds a Camera to the list of obstacles
    /// </summary>
    /// <param name="input">The input parameters for the Camera.</param>
    /// <exception cref="ObjectAddException">Thrown when the input arguments are incorrect</exception>>
    /// <remarks>Uses logical methods to determine a valid input</remarks>
    public void AddCamera(string[] input)
    {
        string[] directions = ["north", "south", "east", "west"];
        
        _logicMethods.IsCorrectArguments(input, 5);
        _logicMethods.IsCoordinates(input[2], out int x, input[3], out int y, null);
        if (!directions.Contains(input[4]))
            throw new ObjectAddException("Direction must be 'north', 'south', 'east' or 'west'.");
        Obstacles.Add(new Camera(x, y, input[4]));
        Console.WriteLine("Successfully added camera obstacle.");
    }

    /// <summary>
    /// Checks if a given position is within the range of any obstacle in the obstacle list
    /// </summary>
    /// <param name="x">The X position to check</param>
    /// <param name="y">The Y position to check</param>
    /// <returns>A Character representing the obstacle in range, or '.' if no obstacle is in range</returns>
    public char Check(int x, int y)
    {
        foreach(var item in Obstacles)
        {
            char result = item.IsInRange(x, y);
            if (result != '.') return result;
        }

        return '.';
    }
}
