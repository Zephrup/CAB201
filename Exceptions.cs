namespace CAB201_Project;

/// <summary>
/// Represents errors that occur during filtering operations.
/// </summary>
public class FilterException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FilterException"/> class.
    /// </summary>
    public FilterException() { }
    /// <summary>
    /// Initializes a new instance of the <see cref="FilterException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public FilterException(string message) : base(message) { }
    /// <summary>
    /// Initializes a new instance of the <see cref="FilterException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public FilterException(string message, Exception innerException) : base(message, innerException) { }
}

/// <summary>
/// Represents errors that occur during object addition operations.
/// </summary>
public class ObjectAddException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectAddException"/> class.
    /// </summary>
    public ObjectAddException() { }
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectAddException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public ObjectAddException(string message) : base(message) { }
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectAddException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public ObjectAddException(string message, Exception innerException) : base(message, innerException) { }
}

/// <summary>
/// Represents errors that occur during check operations.
/// </summary>
public class CheckException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CheckException"/> class.
    /// </summary>
    public CheckException() { }
    /// <summary>
    /// Initializes a new instance of the <see cref="CheckException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public CheckException(string message) : base(message) { }
    /// <summary>
    /// Initializes a new instance of the <see cref="CheckException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public CheckException(string message, Exception innerException) : base(message, innerException) { }
}

/// <summary>
/// Represents errors that occur during pathfinding operations.
/// </summary>
public class PathException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PathException"/> class.
    /// </summary>
    public PathException() { }
    /// <summary>
    /// Initializes a new instance of the <see cref="PathException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public PathException(string message) : base(message) { }
    /// <summary>
    /// Initializes a new instance of the <see cref="PathException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public PathException(string message, Exception innerException) : base(message, innerException) { }
}

/// <summary>
/// Represents errors that occur during map operations.
/// </summary>
public class MapException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MapException"/> class.
    /// </summary>
    public MapException() { }
    /// <summary>
    /// Initializes a new instance of the <see cref="MapException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public MapException(string message) : base(message) { }
    /// <summary>
    /// Initializes a new instance of the <see cref="MapException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public MapException(string message, Exception innerException) : base(message, innerException) { }
}

/// <summary>
/// Represents errors that occur during logical operations. 
/// </summary>
public class LogicException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LogicException"/> class.
    /// </summary>
    public LogicException() { }
    /// <summary>
    /// Initializes a new instance of the <see cref="LogicException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public LogicException(string message) : base(message) { }
    /// <summary>
    /// Initializes a new instance of the <see cref="LogicException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public LogicException(string message, Exception innerException) : base(message, innerException) { }
}
