public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hey, what is your name?");
        if (Console.ReadLine() is not null)
        {
            string name = Console.ReadLine();
            Player mc = new Player(name, "Rusty sword", 50, 50, World.Locations[0]);
        }
        else
        {
            while (Console.ReadLine() is null)
            {
                Console.WriteLine("Do you not have a name?");
            }
        }
    }
}