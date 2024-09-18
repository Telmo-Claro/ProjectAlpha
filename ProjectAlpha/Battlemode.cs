using System.Xml;

public class BattleMode
{
    public int damageByMonster;
    public int damageByPlayer;
    public static bool inBattle;
    public Monster Monsterrawr;
    public Player Playerrawr;
    public Weapon Weapon;
    public int roundCount = 0;

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

            // Round counter for the goblin + 3 round max
            GoblinEncounter goblin = new(Playerrawr);

            if (Monsterrawr == goblin.Goblin)
            {
                if (roundCount == 3)
                {
                    Console.Write($"{goblin.Goblin.Name} has ran away with your items!\n " + Playerrawr.Name + "! Try to defeat it in 3 rounds next time!\n");
                    inBattle = false;
                    break;
                }
                roundCount++;
            }

            // Check if the monster is already dead at the start of the loop
            if (Monsterrawr.CurrentHitPoints <= 0)
            {
                Console.WriteLine($"Your HP: {Playerrawr.Current_hp}");
                Console.WriteLine($"You have defeated the {Monsterrawr.Name}! Press any key to continue");
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