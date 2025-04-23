namespace CAB201_Project;

/// <summary>
/// Represents an Obstacle with coordinates.
/// </summary>
public class Obstacle
{
    public int X { get; } // Gets the X position of the obstacle
    public int Y { get; } // Gets the Y position of the obstacle

    /// <summary>
    /// Initializes a new instance of the <see cref="Obstacle"/> class with the specified position
    /// </summary>
    /// <param name="x">The X position of the obstacle</param>
    /// <param name="y"> The Y position of the obstacle</param>
    public Obstacle(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    /// <summary>
    /// Determines if a specified position is within the range of the obstacle.
    /// </summary>
    /// <param name="x">The X position you want to check</param>
    /// <param name="y">The Y position you want to check</param>
    /// <returns>A character representing whether the position is within range (default is '.').</returns>
    public virtual char IsInRange(int x, int y)
    {
        return '.';
    }
}

/// <summary>
/// Represents a guard as an obstacle
/// </summary>
/// <remarks>Inherits the Obstacle class</remarks>
public class Guard : Obstacle
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Guard"/> class with the specified position
    /// </summary>
    /// <param name="x">The X position of the obstacle</param>
    /// <param name="y"> The Y position of the obstacle</param>
    public Guard(int x, int y) : base(x, y)
    {
    }
    
    /// <summary>
    /// Determines if a specified position is within the range of the guard.
    /// </summary>
    /// <param name="x">The X position you want to check</param>
    /// <param name="y">The Y position you want to check</param>
    /// <returns>'G' if the position is the same as the guard's position; otherwise, '.'</returns>
    public override char IsInRange(int x, int y)
    {
        if (X == x && Y == y) return 'G';
        return '.';
    }
}

/// <summary>
/// Represents a fence as an obstacle
/// </summary>
/// <remarks>Inherits the Obstacle class</remarks>
public class Fence : Obstacle
{
    private string Orientation { get; } // Gets the Orientation of the fence
    private int Length { get; } // Gets the Length of the fence

    /// <summary>
    /// Initializes a new instance of the <see cref="Fence"/> class with the specified position, orientation, and length
    /// </summary>
    /// <param name="x">The X position of the obstacle</param>
    /// <param name="y"> The Y position of the obstacle</param>
    /// <param name="orientation">The orientation of the fence (east or north).</param>
    /// <param name="length">The length of the fence. (greater than zero)</param>
    public Fence(int x, int y, string orientation, int length) : base(x, y)
    {
        this.Orientation = orientation;
        this.Length = length;
    }
    
    /// <summary>
    /// Determines if a specified position is within the range of the fence.
    /// </summary>
    /// <param name="x">The X position you want to check</param>
    /// <param name="y">The Y position you want to check</param>
    /// <returns>'F' if the position is within the range of the fence; otherwise, '.'</returns>
    public override char IsInRange(int x, int y)
    {
        for (int i = 0; i < this.Length; i++)
        { 
            switch (this.Orientation)
            {
                case "east": if (x == this.X + i && y == this.Y) return 'F';
                    break;
                case "north": if (x == this.X && y == this.Y + i) return 'F';
                    break;
            }
        }

        return '.';
    }
}

/// <summary>
/// Represents a sensor as an obstacle
/// </summary>
/// <remarks>Inherits the Obstacle class</remarks>
public class Sensor : Obstacle
{
    private float Range { get; } // Gets the Range of the sensor

    /// <summary>
    /// Initializes a new instance of the <see cref="Sensor"/> class with the specified position and range
    /// </summary>
    /// <param name="x">The X position of the obstacle</param>
    /// <param name="y"> The Y position of the obstacle</param>
    /// <param name="range">The detection range of the sensor</param>
    public Sensor(int x, int y, float range) : base(x, y)
    {
        this.Range = range;
    }
    
    /// <summary>
    /// Determines if a specified position is within the range of the sensor.
    /// </summary>
    /// <param name="x">The X position you want to check</param>
    /// <param name="y">The Y position you want to check</param>
    /// <returns>'S' if the position is within the range of the fence; otherwise, '.'</returns>
    public override char IsInRange(int x, int y)
    {
        double xPow = Math.Pow(x - this.X, 2);
        double yPow = Math.Pow(y - this.Y, 2);
        double rangeToCords = Math.Sqrt(xPow + yPow);

        if (rangeToCords < this.Range) return 'S';
        return '.';
    }
}

/// <summary>
/// Represents a Camera as an obstacle
/// </summary>
/// <remarks>Inherits the Obstacle class</remarks>
public class Camera : Obstacle
{
    private string Direction { get; } // Gets the direction the camera is facing

    /// <summary>
    /// Initializes a new instance of the <see cref="Camera"/> class with the specified position and direction
    /// </summary>
    /// <param name="x">The X position of the obstacle</param>
    /// <param name="y"> The Y position of the obstacle</param>
    /// <param name="direction">The direction the camera is facing ('north', 'south', 'east', or 'west')</param>
    public Camera(int x, int y, string direction) : base(x, y)
    {
        this.Direction = direction;
    }
    
    /// <summary>
    /// Determines if a specified position is within the range of the camera.
    /// </summary>
    /// <param name="x">The X position you want to check</param>
    /// <param name="y">The Y position you want to check</param>
    /// <returns>'C' if the position is within the range of the fence; otherwise, '.'</returns>
    public override char IsInRange(int x, int y)
    {
        int xDif = x - this.X;
        int yDif = y - this.Y;

        switch (this.Direction)
        {
            case "north":
                if (Math.Abs(xDif) <= yDif) return 'C';
                break;
            case "south":
                if (-Math.Abs(xDif) >= yDif) return 'C';
                break;
            case "east":
                if (xDif >= Math.Abs(yDif)) return 'C';
                break;
            case "west":
                if (xDif <= -Math.Abs(yDif)) return 'C';
                break;
        }

        return '.';
    }
}
