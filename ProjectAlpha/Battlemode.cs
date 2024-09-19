using System.Xml;

public class BattleMode
{
    public int damageByMonster;
    public int damageByPlayer;
    public static bool inBattle;
    public Monster Monsterrawr;
    public Player Playerrawr;
    public Weapon Weapon;
    public int roundCount = 1;

    public BattleMode(Monster monster, Player player)
    {
        this.Monsterrawr = monster;
        this.Playerrawr = player;
        this.Weapon = player.Current_weapon;
        inBattle = true;
    }

    public void BattleMenu()
    {
        Console.WriteLine($"You encountered a {Monsterrawr.Name}!");

        while (Playerrawr.Current_hp > 0 && inBattle)
        {
            int damage = 0;
            GoblinEncounter goblin = new(Playerrawr);
            Console.WriteLine("Round: " + roundCount);
            if (Monsterrawr == goblin.Goblin)
            {
                int playerInventoryLenght = Playerrawr.Inventory.Items.Count();
                Random random = new Random();

                if (roundCount == 4)
                {
                    Console.Write($"{goblin.Goblin.Name} has ran away with your items!\n" + Playerrawr.Name + "! Try to defeat it in 3 rounds next time!\n");
                    Console.ReadKey();
                    inBattle = false;
                    break;
                }

                //steals an item every round
                if (Playerrawr.Inventory.Items.Count() is not 0) 
                { 
                    int itemToSteal = random.Next(0, playerInventoryLenght - 1);
                    Item itemStolen = Playerrawr.Inventory.Items[itemToSteal];
                    goblin.Inventory.Items.Add(itemStolen);
                    Playerrawr.Inventory.Items.RemoveAt(itemToSteal);
                    Console.WriteLine($"{goblin.Goblin.Name} has stolen {itemStolen.Name} from you!");
                    Console.ReadKey();
                }


                // if goblin dies, items go back to player
                if (Monsterrawr.CurrentHitPoints <= 0) 
                {
                    for (int i = 0; i < goblin.Inventory.Items.Count(); i++) 
                    {
                        Item itemBack = Playerrawr.Inventory.Items[i];
                        goblin.Inventory.Items.RemoveAt(i);
                        Playerrawr.Inventory.Items.Add(itemBack);
                    }
                    Console.ReadKey();
                }

                // line separates the rounds
                Console.WriteLine("------------------------------------------------------------");
                roundCount++;
            }

            // Check if the monster is already dead at the start of the loop
            if (Monsterrawr.CurrentHitPoints <= 0)
            {
                Console.WriteLine($"Your HP: {Playerrawr.Current_hp}");
                Console.WriteLine($"You have defeated the {Monsterrawr.Name}! Press any key to continue");
                Playerrawr.Done_Quests.Add(Monsterrawr.Quest);
                inBattle = false;  // End the battle loop
                Console.ReadLine();
                continue;
            }
            Console.WriteLine($"Your HP: {Playerrawr.Current_hp}");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(1) Attack\n(2) Flee\n(3) Look at inventory\n(4) Quit game");

            // Get player input
            string? playerChoice = Console.ReadLine();

            switch (playerChoice)
            {
                case "1":
                    // Player attacks the monster
                    damage = RandomDamage(0, Weapon.maximumDamage);
                    Console.WriteLine($"You hit {Monsterrawr.Name} for {damage} damage.");
                    Monsterrawr.CurrentHitPoints -= damage;

                    // Check if the monster is defeated after player's attack
                    if (Monsterrawr.CurrentHitPoints <= 0)
                    {
                        Console.WriteLine($"You have defeated the {Monsterrawr.Name}! Press any key to continue");
                        Playerrawr.Done_Quests.Add(Monsterrawr.Quest);
                        inBattle = false;  // End the battle
                        Console.ReadLine();
                        continue;
                    }

                    // Monster attacks back if not dead
                    damage = RandomDamage(0, Monsterrawr.MaximumDamage);
                    Console.WriteLine($"The {Monsterrawr.Name} hit you for {damage} damage.");
                    Playerrawr.Current_hp -= damage;

                    // Check if the player is defeated after monster's attack
                    if (Playerrawr.Current_hp <= 0)
                    {
                        Console.WriteLine("You have been defeated.");
                        inBattle = false;  // End the battle
                    }
                    continue;

                case "2":
                    // Player flees from battle

                    // if goblin, no flee allowed
                    if (Monsterrawr == goblin.Goblin)
                    {
                        Console.WriteLine($"{Playerrawr.Name}, you can't escape the magnificient Goblin!");
                        break;
                    }

                    BattleModeFlee();
                    inBattle = false;  // Exit the battle after fleeing
                    break;

                case "3":
                    // Opens inventory
                    Console.WriteLine("Opening inventory...");
                    Playerrawr.InvMenu();
                    break;

                case "4":
                    // Quit game
                    Console.WriteLine("Exiting the game...");
                    System.Environment.Exit(0);
                    break;

                default:
                    // Handle invalid input
                    Console.WriteLine("Invalid input! Please choose a valid option.");
                    break;
            }

            // Check if the player fled or was defeated
            if (!inBattle || Playerrawr.Current_hp <= 0)
            {
                break;
            }
        }
    }


    public int RandomDamage(int minDamage, int maxDamage)
    {
        // simple random damage returner
        Random rng = new Random();
        int rand = rng.Next(minDamage, maxDamage);
        return rand;
    }

    public void BattleModeFlee()
    {
        // 40% chance of escaping harmless, otherwise gets hit when fleeing
        Random chance = new Random();
        int randomchance = chance.Next(0, 101);
        if (randomchance > 0 && randomchance < 40)
        {
            Console.WriteLine("You could just escape in time without taking any damage!");
        }
        else
        {
            int damage = RandomDamage(0, Monsterrawr.MaximumDamage);
            Console.WriteLine($"The {Monsterrawr.Name} hit you for {damage} while you were trying to flee!");
            Playerrawr.Current_hp -= damage;
        }
    }
}