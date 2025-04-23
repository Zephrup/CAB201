namespace CAB201_Project;

/// <summary>
/// Contains logic methods for common operations
/// </summary>
public class LogicMethods
{
    /// <summary>
    /// Validates if the input array has the correct number of arguments
    /// </summary>
    /// <param name="input">The input array to check</param>
    /// <param name="count">The expected number of arguments</param>
    /// <exception cref="LogicException">Thrown when the number of arguments is incorrect</exception>
    public void IsCorrectArguments(string[] input, int count)
    {
        if (input.Length != count) throw new LogicException("Incorrect number of arguments.");
    }

    /// <summary>
    /// Validates if the given strings can be converted to integers for coordinates
    /// </summary>
    /// <param name="xStr">The string representing the X position</param>
    /// <param name="x">The parsed X position (integer)</param>
    /// <param name="yStr">The string representing the Y position</param>
    /// <param name="y">The parsed Y position (integer)</param>
    /// <param name="message">The error message to include if the parsing fails</param>
    /// <exception cref="LogicException">>Thrown when the coordinates are not valid integers.</exception>
    public void IsCoordinates(string xStr, out int x, string yStr, out int y, string? message)
    {
        if (!int.TryParse(xStr, out x) || !int.TryParse(yStr, out y))
        {
            if (message != null) throw new LogicException(message);
            throw new LogicException("Coordinates are not valid integers.");
        }
    }
}
