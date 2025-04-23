namespace CAB201_Project;

/// <summary>
/// Represents a node in the A* pathfinding algorithm.
/// </summary>
/// <remarks>ONLY USED FOR A*</remarks>>
public class Node
{
    public int X; // X position of the node
    public int Y; // y position of the node
    public int H; // Heuristic cost of the node
    public int G; // Cost from the start node to this node (steps)
    public int F; // Total code of (G + H) of the node
    public List<Node> Neighbors = new (); // List of the nodes neighbors
    private bool _walkable; // Boolean Value indicating if this node can be used for the path
    public Node? Prev; // Previous node in the path to this node
    private ObjectLogic _objectLogic = new ();

    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class with specified coords>
    /// </summary>
    /// <param name="x">The X position of the node</param>
    /// <param name="y">The Y position of the node</param>
    /// <remarks>Also sets the boolean if the node if walkable of not</remarks>
    public Node(int x, int y)
    {
        this.X = x;
        this.Y = y;
        this._walkable = _objectLogic.Check(X, Y) == '.';
    }

    /// <summary>
    /// Gets the position of the node in the form of a tuple
    /// </summary>
    /// <returns>A tuple containing the X position and Y position of the node</returns>
    public (int, int) Position()
    {
        return (this.X, this.Y);
    }

    /// <summary>
    /// Adds the neighboring nodes to <see cref="Neighbors"/> list>
    /// </summary>
    /// <remarks>Also removes all neighbors that are not walkable (set to false)</remarks>>
    public void AddNeighbors()
    {
        Neighbors.Clear(); // Clears the list for caution
        Neighbors.Add(new Node(X+1, Y));  // East
        Neighbors.Add(new Node(X-1, Y));  // West
        Neighbors.Add(new Node(X, Y+1));  // North
        Neighbors.Add(new Node(X, Y-1));  // South

        Neighbors.RemoveAll(n => !n._walkable); // Removes all neighbors that are obstacles (not walkable)
    }
}
