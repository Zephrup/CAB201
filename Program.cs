namespace CAB201_Project;

class Program
{
    static void Main(string[] args)
    {
        Commands command = new Commands();
        Console.WriteLine("Welcome to the Threat-o-tron 9000 Obstacle Avoidance System.\n");
        command.Filter(["help"]);
        
        while (true)
        {
            try
            {
                Console.WriteLine("Enter command:");
                string input = Console.ReadLine() ?? "";
                string[] inputParts = input.Split(" ");

                if (input == "exit") break;
                command.Filter(inputParts);
            }
            catch (FilterException e) { Console.WriteLine(e.Message); }
            catch (LogicException e) { Console.WriteLine(e.Message); }
        }
        Console.WriteLine("Thank you for using the Threat-o-tron 9000.");
    }
}
