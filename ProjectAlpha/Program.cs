using System.Security.Cryptography.X509Certificates;

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
                if (Characters.characters.Contains(name))
                {
                    Characters.ItemAdd(mc);
                }
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
            if ((mc.Current_location == World.LocationByID(World.LOCATION_ID_GUARD_POST)) && ((!mc.Done_Quests.Contains(World.QuestByID(World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN))) && (!mc.Done_Quests.Contains(World.QuestByID(World.QUEST_ID_CLEAR_FARMERS_FIELD)))))
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"{World.Final_quest_UnReady}\n");
                    Console.WriteLine("(1) Back");
                    string tmp2 = Console.ReadLine();
                    if (tmp2 == "1")
                    {
                        (mc.Current_location, mc.Previous_Location) = (mc.Previous_Location, mc.Current_location);
                        break;
                    }
                }
            }
            // checks for accepting quests
            if ((mc.Current_location.QuestAvailableHere is not null) && (!mc.Quest_List.Contains(mc.Current_location.QuestAvailableHere)) && (!mc.Done_Quests.Contains(mc.Current_location.QuestAvailableHere)))
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"{mc.Current_location.QuestAvailableHere.BeginDialogue}\n");
                    Console.WriteLine("Do you accept this quest?");
                    Console.WriteLine("(1) Yes\n(2) No");
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
            // check for returning Final Quest
            if (mc.Done_Quests.Contains(mc.Current_location.QuestAvailableHere) && (mc.Current_location == World.LocationByID(World.LOCATION_ID_BRIDGE)))
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"{mc.Current_location.QuestAvailableHere.EndDialogue}\n");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    mc.Quest_List.Remove(mc.Current_location.QuestAvailableHere);
                    mc.Inventory.Items.Remove(World.MonsterByID(World.MONSTER_ID_GIANT_SPIDER).Drop);
                    Thread.Sleep(1000);
                    System.Environment.Exit(0);
                    break;
                }
            }

            // checks for returning quests
            if ((mc.Quest_List.Contains(mc.Current_location.QuestAvailableHere) && (mc.Done_Quests.Contains(mc.Current_location.QuestAvailableHere))))
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"{mc.Current_location.QuestAvailableHere.EndDialogue}\n");
                    Console.WriteLine($"You have recieved: {mc.Current_location.QuestAvailableHere.Reward.Name}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    
                    mc.Quest_List.Remove(mc.Current_location.QuestAvailableHere);
                    mc.Inventory.Items.Add(mc.Current_location.QuestAvailableHere.Reward);
                    Thread.Sleep(1000);
                    break;
                }
            }
            // encounter monster in non-friendly areas if quest active.
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

            // Checks if player is in a non-friendly area and loads a chance of the goblin to appear.
            if (!mc.Monster_Encountered.Contains(World.MonsterByID(World.MONSTER_ID_GOBLIN_THIEF)))
            {
                // make goblin-class object
                GoblinEncounter goblin = new GoblinEncounter(mc);
                if (goblin.ChanceOfEncounter() && !mc.Current_location.Friendly)
                {
                    Console.Clear();
                    mc.Monster_Encountered.Add(World.MonsterByID(World.MONSTER_ID_GOBLIN_THIEF));
                    goblin.IntoBattle();
                }

            }

            // start menu
            Console.Clear();
            if (mc.Name == "Elmo")
                Characters.ApplySpacyTheme();
            Console.WriteLine(mc.DisplayHealthBar());
            Console.WriteLine($"Location: {mc.Current_location.Name}\n{mc.Current_location.Description}\n");
            Console.WriteLine("(1) Move");
            Console.WriteLine("(2) Quests");
            Console.WriteLine("(3) Inventory");
            Console.WriteLine("(4) Quit");

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

                    Console.WriteLine("\n(1) Back\n> ");
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
                    Console.WriteLine($"(1) North: {mc.Current_location.LocationToNorth.Name}");
                }
                if (mc.Current_location.LocationToSouth is not null)
                {
                    Console.WriteLine($"(2) South: {mc.Current_location.LocationToSouth.Name}");
                }
                if (mc.Current_location.LocationToWest is not null)
                {
                    Console.WriteLine($"(3) West: {mc.Current_location.LocationToWest.Name}");
                }
                if (mc.Current_location.LocationToEast is not null)
                {
                    Console.WriteLine($"(4) East: {mc.Current_location.LocationToEast.Name}");
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