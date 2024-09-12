public class Program
{
    public static void Main()
    {
        string name;
        Player mc;

        // name loop
        while (true)
        {
            Console.WriteLine("Hey, what is your name?");
            name = Console.ReadLine();
            if (name is not null)
            {
                mc = new Player(name, "Rusty sword", 50, 50, World.Locations[0]);
                Console.Clear();
                Console.WriteLine($"Greetings, {name}\n");
                Thread.Sleep(1000);
                break;
            }
            else
            {
                while (name is null)
                {
                    Console.WriteLine("Do you not have a name?");
                }
            }
        }

        // menu loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Location: {mc.Current_location.Name}\n{mc.Current_location.Description}\n\nFrom here you can go:\n");
            if (mc.Current_location.LocationToNorth is not null)
            {
                Console.WriteLine($"North (1): {mc.Current_location.LocationToNorth.Name}");
            }
            if (mc.Current_location.LocationToSouth is not null)
            {
                Console.WriteLine($"South (2): {mc.Current_location.LocationToSouth.Name}");
            }
            if (mc.Current_location.LocationToWest is not null)
            {
                Console.WriteLine($"West (3): {mc.Current_location.LocationToWest.Name}");
            }
            if (mc.Current_location.LocationToEast is not null)
            {
                Console.WriteLine($"East (4): {mc.Current_location.LocationToEast.Name}");
            }

            Console.WriteLine("\n" +World.map);

            Console.WriteLine("Where do you want to go?");

            while (true)
            {
                string choice = Console.ReadLine();
                if ((choice == "1") && (mc.Current_location.LocationToNorth is not null))
                {
                    mc.Current_location = mc.Current_location.LocationToNorth;
                    break;
                }
                else if ((choice == "2") && (mc.Current_location.LocationToSouth is not null))
                {
                    mc.Current_location = mc.Current_location.LocationToSouth;
                    break;
                }
                else if ((choice == "3") && (mc.Current_location.LocationToWest is   not null))
                {
                    mc.Current_location = mc.Current_location.LocationToWest;
                    break;
                }
                else if ((choice == "4") && (mc.Current_location.LocationToEast is not null))
                {
                    mc.Current_location = mc.Current_location.LocationToEast;
                    break;
                }
                break;
            }
        }
    }
}