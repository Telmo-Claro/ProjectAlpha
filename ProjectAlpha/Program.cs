public class Program
{
    public static void Main()
    {
        string? name;
        Player mc;
        bool MoveLoop = false;

        // name loop
        while (true)
        {
            Console.WriteLine("Hey, what is your name?");
            name = Console.ReadLine();
            if (name is not null)
            {
                mc = new Player(name, World.WeaponByID(World.WEAPON_ID_RUSTY_SWORD), 50, 50, World.Locations[0]);
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
            // checks for when you enter a new location / updates

            // check for the final boss, first defeat 2 previous quests
            if ((mc.Current_location == World.LocationByID(World.LOCATION_ID_GUARD_POST)) && ((!mc.Quest_List.Contains(World.QuestByID(World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN))) && (!mc.Quest_List.Contains(World.QuestByID(World.QUEST_ID_CLEAR_FARMERS_FIELD)))))
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"{World.Final_quest_UnReady}\n");
                    Console.WriteLine("Back (1)");
                    string tmp2 = Console.ReadLine();
                    if (tmp2 == "1")
                    {
                        (mc.Current_location, mc.Previous_Location) = (mc.Previous_Location, mc.Current_location);
                        break;
                    }
                }
            }
            // checks for quests
            if ((mc.Current_location.QuestAvailableHere is not null) && (!mc.Quest_List.Contains(mc.Current_location.QuestAvailableHere)))
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"{mc.Current_location.QuestAvailableHere.BeginDialogue}\n");
                    Console.WriteLine("Do you accept this quest?");
                    Console.WriteLine("Yes (1)\nNo (2)");
                    string tmp = Console.ReadLine();
                    if (tmp == "1")
                    {
                        mc.Quest_List.Add(mc.Current_location.QuestAvailableHere);
                        Console.Clear();
                        Console.WriteLine("The quest has been accepted");
                        Thread.Sleep(1000);
                        break;
                    }
                    else if (tmp == "2")
                    {
                        (mc.Current_location, mc.Previous_Location) = (mc.Previous_Location, mc.Current_location);
                        break;
                    }
                }
            }

            // encounter monster the monster in non-friendly areas
            if ((mc.Current_location.MonsterLivingHere is not null) && (!mc.Monster_Encountered.Contains(mc.Current_location.MonsterLivingHere)))
            {
                while (true)
                {
                    Console.Clear();
                    mc.Monster_Encountered.Add(mc.Current_location.MonsterLivingHere);
                    Encounter monster = new Encounter(mc.Current_location.MonsterLivingHere, mc);
                    monster.choice();
                    break;
                }
            }

            // start menu
            // Console.Clear();
            Console.WriteLine($"Location: {mc.Current_location.Name}\n{mc.Current_location.Description}\n");
            Console.WriteLine("Move (1)");
            Console.WriteLine("Quests (2)");
            Console.WriteLine("Inventory (3)");
            Console.WriteLine("Quit (4)");

            string Choice = Console.ReadLine();
            if (Choice == "1")
            {
                MoveLoop = true;
            }
            else if (Choice == "2")
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Quests: ");
                    if (mc.Quest_List.Count != 0)
                    {
                        foreach (Quest quest in mc.Quest_List)
                        {
                            Console.WriteLine(quest.Info());
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have no active quests!");
                    }

                    Console.WriteLine("\nBack (1)");
                    string Back = Console.ReadLine();
                    if (Back == "1")
                    {
                        break;
                    }
                }
            }
            else if (Choice == "3")
            {
                mc.InvMenu();
            }
            else if (Choice == "4")
            {
                System.Environment.Exit(0);
            }

            // movement loop
            while (MoveLoop)
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

                Console.WriteLine("\n" + World.map);

                Console.WriteLine("Where do you want to go?");

                while (true)
                {
                    string choice = Console.ReadLine();
                    if ((choice == "1") && (mc.Current_location.LocationToNorth is not null))
                    {
                        mc.Previous_Location = mc.Current_location;
                        mc.Current_location = mc.Current_location.LocationToNorth;
                        MoveLoop = false;
                        break;
                    }
                    else if ((choice == "2") && (mc.Current_location.LocationToSouth is not null))
                    {
                        mc.Previous_Location = mc.Current_location;
                        mc.Current_location = mc.Current_location.LocationToSouth;
                        MoveLoop = false;
                        break;
                    }
                    else if ((choice == "3") && (mc.Current_location.LocationToWest is not null))
                    {
                        mc.Previous_Location = mc.Current_location;
                        mc.Current_location = mc.Current_location.LocationToWest;
                        MoveLoop = false;
                        break;
                    }
                    else if ((choice == "4") && (mc.Current_location.LocationToEast is not null))
                    {
                        mc.Previous_Location = mc.Current_location;
                        mc.Current_location = mc.Current_location.LocationToEast;
                        MoveLoop = false;
                        break;
                    }
                }
            }
        }
    }
}