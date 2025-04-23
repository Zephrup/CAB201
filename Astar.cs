namespace CAB201_Project;


/// <summary>
/// Represents the A* Pathfinding Algorithm
/// </summary>
public class Astar
{
    /// <summary>
    /// Executes the A* algorithm to find the shortest path between two nodes.
    /// Pseudo Code - https://robotics.caltech.edu/wiki/images/e/e0/Astar.pdf
    /// </summary>
    /// <param name="startX">The X position of the starting node</param>
    /// <param name="startY">The Y position of the starting node</param>
    /// <param name="endX">The X position of the goal node</param>
    /// <param name="endY">The Y position of the goal node</param>
    /// <exception cref="PathException">Thrown when no path is found</exception>
    public void AStar(int startX, int startY, int endX, int endY)
    {
        Node start = new Node(startX, startY);
        start.F = 0;
        Node goal = new Node(endX, endY);
        List<Node> openSet = new List<Node>();
        List<Node> closedSet = new List<Node>();

        openSet.Add(start);
        bool foundPath = false;
        while (openSet.Count != 0)
        {
            openSet.Sort((x, y) =>
            {
                int fScoreComparison = x.F.CompareTo(y.F); // Sort by F score
                if (fScoreComparison != 0) return fScoreComparison; // If the Same, Sort by H score
                return x.H.CompareTo(y.H);
            });
            Node current = openSet[0]; // Moving the Node from Open to Closed Set
            openSet.RemoveAt(0);
            closedSet.Add(current);
            if (current.Position() == goal.Position()) // Checking if the Position is the same as the goal
            {
                PrintPath(current);
                foundPath = true;
                break;
            }
            
            current.AddNeighbors(); // Generating the neighbor Nodes
            foreach (var neighbor in current.Neighbors)
            {
                neighbor.Prev = current;
                neighbor.H = ManhattanDist(neighbor, goal);
                neighbor.G = current.G + 1;
                neighbor.F = neighbor.G + neighbor.H;

                bool betterOpen = false;
                bool betterClosed = false;
                for (int i = 0; i < openSet.Count; i++) // Checking if the new node is in the set and better than the one in the set
                {
                    if (neighbor.Position() == openSet[i].Position())
                    {
                        if (openSet[i].F <= neighbor.F) betterOpen = true;
                        else
                        {
                            openSet[i] = neighbor; // Swap the nodes for the better F score
                            betterOpen = true;
                        }
                    }
                }

                for (int i = 0; i < closedSet.Count; i++) // Checking if the new node is in the set and better than the one in the set
                {
                    if (neighbor.Position() == closedSet[i].Position())
                    {
                        if (closedSet[i].F <= neighbor.F) betterClosed = true;
                        else
                        {
                            closedSet[i] = neighbor; // Swap the nodes for the better F score
                            betterClosed = true;
                        }
                    }
                }

                // If there was no better in either (or swap) add to openSet
                if (!betterOpen && !betterClosed) openSet.Add(neighbor);
            }
        }

        if (!foundPath) throw new PathException("There is no safe path to the objective.");
    }

    /// <summary>
    /// Calculates the Manhattan distance between two nodes.
    /// </summary>
    /// <param name="a">The first Node</param>
    /// <param name="b">The second Node</param>
    /// <returns>The Manhattan distance between the nodes.</returns>
    private int ManhattanDist(Node a, Node b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    /// <summary>
    /// Prints the path from the start node to the current node.
    /// </summary>
    /// <param name="current">The current node (last/goal node)</param>
    /// <remarks>Backtraces from the current node to find the path</remarks>
    private void PrintPath(Node current)
    {
        List<Node> path = new List<Node>();
        while (current != null!) // Inputs the path into a list
        {
            path.Add(current);
            current = current.Prev!;
        }
        path.Reverse(); // Reverse the path so the first index is the starting Node

        Console.WriteLine("The following path will take you to the objective:");
        int klicks = 0;
        string direction = "";
        
        for (int i = 1; i < path.Count; i++) // Print Instructions for path
        {
            int diffX = path[i].X - path[i - 1].X;
            int diffY = path[i].Y - path[i - 1].Y;

            string currentDirection = "";
            if (diffX > 0) currentDirection = "east";
            else if (diffX < 0) currentDirection = "west";
            else if (diffY > 0) currentDirection = "north";
            else if (diffY < 0) currentDirection = "south";

            if (currentDirection == direction) klicks++;
            else
            {
                if (direction != "") Console.WriteLine($"Head {direction} for {klicks} klick{(klicks > 1 ? "s" : "")}.");
                direction = currentDirection;
                klicks = 1;
            }
        }
        Console.WriteLine($"Head {direction} for {klicks} klick{(klicks > 1 ? "s" : "")}.");
    }
}
