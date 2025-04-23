namespace CAB201_Project;

/// <summary>
/// Handles the execution of various commands
/// </summary>
public class Commands
{
    ObjectLogic _objectLogic = new ObjectLogic();
    private LogicMethods _logicMethods = new LogicMethods();
    
    /// <summary>
    /// Filters and executes the appropriate command based on the input.
    /// </summary>
    /// <param name="input">The input command and its arguments</param>
    /// <exception cref="FilterException">Thrown when the command is invalid or an error occurs during execution</exception>
    public void Filter(string[] input)
    {
        switch (input[0])
        {
            case "add":
                try { AddFilter(input); }
                catch (ObjectAddException e) { Console.WriteLine(e.Message); }
                break;
            case "check":
                try { Check(input); }
                catch (CheckException e) { Console.WriteLine(e.Message); }
                break;
            case "map":
                try { Map(input); }
                catch (MapException e) { Console.WriteLine(e.Message); }
                break;
            case "path":
                try { Path(input); }
                catch (PathException e) { Console.WriteLine(e.Message); }
                break;
            case "help": Console.WriteLine(Help());
                break;
            default:
                throw new FilterException($"Invalid option: {input[0]}\n" +
                                    "Type 'help' to see a list of commands.");
        }
    }
    
    /// <summary>
    /// Filters and executes the appropriate object add command based on the input
    /// </summary>
    /// <param name="input">The input command and its arguments</param>
    /// <exception cref="FilterException">Thrown when the obstacle type is invalid or unspecified</exception>
    private void AddFilter(string[] input)
    {
        if (input.Length < 2) throw new FilterException("You need to specify an obstacle type.");
            switch (input[1])
            {
                case "guard":
                    _objectLogic.AddGuard(input);
                    break;
                case "fence":
                    _objectLogic.AddFence(input);
                    break;
                case "sensor":
                    _objectLogic.AddSensor(input);
                    break;
                case "camera":
                    _objectLogic.AddCamera(input);
                    break;
                default: throw new FilterException("Invalid obstacle type.");
        }
    }
    
    /// <summary>
    /// Checks if a given position and its surroundings are safe
    /// </summary>
    /// <param name="input">The input command and its arguments</param>
    /// <exception cref="CheckException">Thrown when the location is compromised or has no safe directions</exception>
    private void Check(string[] input)
    {
        _logicMethods.IsCorrectArguments(input, 3);
        _logicMethods.IsCoordinates(input[1], out int x, input[2], out int y, null);
            if (_objectLogic.Check(x, y) != '.')
                throw new CheckException("Agent, your location is compromised. Abort mission.");

            string safeDirections = "";
            if (_objectLogic.Check(x, y + 1) == '.') safeDirections += "North\n";
            if (_objectLogic.Check(x, y - 1) == '.') safeDirections += "South\n";
            if (_objectLogic.Check(x + 1, y) == '.') safeDirections += "East\n";
            if (_objectLogic.Check(x - 1, y) == '.') safeDirections += "West\n";
            if (safeDirections == "")
                throw new CheckException("You cannot safely move in any direction. Abort mission.");
            Console.WriteLine($"You can safely take any of the following directions:\n{safeDirections}");
    }

    /// <summary>
    /// Draws a map of registered obstacles in the specified region
    /// </summary>
    /// <param name="input">The input command and its arguments</param>
    /// <exception cref="MapException">Thrown when the input arguments are invalid</exception>
    private void Map(string[] input)
    {
        _logicMethods.IsCorrectArguments(input, 5);
        _logicMethods.IsCoordinates(input[1], out int x, input[2], out int y, "Coordinates are not valid integers.");
        if (!int.TryParse(input[3], out int w) || !int.TryParse(input[4], out int h) || w <= 0 || h <= 0)
            throw new MapException("Width and height must be valid positive integers.");
        Console.WriteLine("Here is a map of obstacles in the selected region:");
        for (int i = y + h; i > y; i--)
        {
            for (int j = x; j < x + w; j++)
            {
                Console.Write(_objectLogic.Check(j, i - 1));
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Finds a path free of obstacles from the agent's location to the objective
    /// </summary>
    /// <param name="input">The input command and its arguments</param>
    /// <exception cref="PathException">Thrown when the path is invalid or the objective is blocked</exception>
    private void Path(string[] input)
    {
        Astar astar = new Astar();
        _logicMethods.IsCorrectArguments(input, 5);
        _logicMethods.IsCoordinates(input[1], out int aX, input[2], out int aY,"Agent coordinates are not valid integers.");
        _logicMethods.IsCoordinates(input[3], out int gX, input[4], out int gY, "Objective coordinates are not valid integers.");
        if ((aX, aY) == (gX, gY)) throw new PathException("Agent, you are already at the objective.");
        if (_objectLogic.Check(gX, gY) != '.') throw new PathException("The objective is blocked by an obstacle and cannot be reached.");
        astar.AStar(aX, aY, gX, gY);
    }

    /// <summary>
    /// Displays the help message listing all valid commands
    /// </summary>
    /// <returns>A string containing the help message</returns>
    private static string Help()
    {
        return "Valid commands are:\n" +
               "add guard <x> <y>: registers a guard obstacle\n" +
               "add fence <x> <y> <orientation> <length>: registers a fence obstacle. Orientation must be 'east' or 'north'.\n" +
               "add sensor <x> <y> <radius>: registers a sensor obstacle\n" +
               "add camera <x> <y> <direction>: registers a camera obstacle. Direction must be 'north', 'south', 'east' or 'west'.\n" +
               "check <x> <y>: checks whether a location and its surroundings are safe\n" +
               "map <x> <y> <width> <height>: draws a text-based map of registered obstacles\n" +
               "path <agent x> <agent y> <objective x> <objective y>: finds a path free of obstacles\n" +
               "help: displays this help message\n" +
               "exit: closes this program\n";
    }
}
