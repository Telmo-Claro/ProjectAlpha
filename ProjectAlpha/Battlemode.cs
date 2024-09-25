using System.Diagnostics;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class BattleMode
{
    public int damageByMonster;
    public int damageByPlayer;
    public static bool inBattle;
    public Monster Monster;
    public Player Player;
    public Weapon Weapon;
    public int roundCount = 1;

    public BattleMode(Monster monster, Player player)
    {
        this.Monster = monster;
        this.Player = player;
        this.Weapon = player.Current_weapon;
        inBattle = true;
    }

    public void BattleMenu()
    {
        Ascii art = new Ascii();
        GoblinEncounter goblin = new(Player);
        Console.WriteLine($"You encountered a {Monster.Name}!");

        while (Player.Current_hp > 0 && inBattle)
        {
            int damage = 0;
            Console.WriteLine("Round: " + roundCount);
            if (Monster.Name == "Snake")
            {
                art.Snake();
            }
            else if(Monster.Name == "Rat")
            {
                art.Rat();
            }
            else if(Monster.Name == "Giant Spider")
            {
                art.Spider();
            }
            if (Monster == goblin.Goblin)
            {
                art.Goblin();
                int playerInventoryLenght = Player.Inventory.Items.Count();
                Random random = new Random();

                if (roundCount == 4)
                {
                    Console.Write($"{goblin.Goblin.Name} has ran away with your items!\n" + Player.Name + "! Try to defeat it in 3 rounds next time!\n");
                    Console.ReadKey();
                    inBattle = false;
                    break;
                }

                //steals an item every round
                if (Player.Inventory.Items.Count() is not 0)
                {
                    int itemToSteal = random.Next(0, playerInventoryLenght - 1);
                    Item itemStolen = Player.Inventory.Items[itemToSteal];
                    goblin.Inventory.Items.Add(itemStolen);
                    Player.Inventory.Items.RemoveAt(itemToSteal);
                    Console.WriteLine($"{goblin.Goblin.Name} has stolen {itemStolen.Name} from you!");
                    Console.ReadKey();
                }


                // if goblin dies, items go back to player
                if (Monster.CurrentHitPoints <= 0)
                {
                    for (int i = 0; i < goblin.Inventory.Items.Count(); i++)
                    {
                        Item itemBack = Player.Inventory.Items[i];
                        Player.Inventory.Items.Add(itemBack);
                        goblin.Inventory.Items.RemoveAt(i);
                    }
                    Console.ReadKey();
                }
            }
            Console.WriteLine("------------------------------------------------------------");
            roundCount++;

            // Check if the monster is already dead at the start of the loop
            if (Monster.CurrentHitPoints <= 0)
            {
                Console.WriteLine(Player.DisplayHealthBar());
                Console.WriteLine($"You have defeated the {Monster.Name}!");
                if (Monster.Drop != null)
                {
                    Player.Inventory.Items.Add(Monster.Drop);
                    Console.WriteLine($"You have dropped {Monster.Drop}");
                }
                Console.WriteLine("Press any key to continue ...");
                Player.Done_Quests.Add(Monster.Quest);
                inBattle = false;  // End the battle loop
                if (Monster.Drop != null)
                {
                    Player.Inventory.Items.Add(Monster.Drop);
                }
                Console.ReadLine();
                continue;
            }
            roundCount++;
            Console.WriteLine(Player.DisplayHealthBar());
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(1) Attack\n(2) Flee\n(3) Look at inventory\n(4) Quit game");

            // Get player input
            string? playerChoice = Console.ReadLine();

            switch (playerChoice)
            {
                case "1":
                    switch (Player.Name)
                    {
                        // player attacks
                        case "Kasper":
                            {
                                damage = KasperDamage();
                                Console.WriteLine($"You hit the {Monster.Name} for {damage}!");
                                Monster.CurrentHitPoints -= damage;
                                break;
                            }
                        case "Aksol":
                            {
                                damage = RandomDamage(0, Weapon.maximumDamage);
                                damage = damage * 3;
                                Console.WriteLine($"Wow you hit the {Monster.Name} for {damage}!");
                                Monster.CurrentHitPoints -= damage;
                                break;
                            }
                        default:
                            {
                                damage = RandomDamage(0, Weapon.maximumDamage);
                                Console.WriteLine($"You hit {Monster.Name} for {damage} damage.");
                                Monster.CurrentHitPoints -= damage;
                                break;
                            }
                    }

                    // Check if the monster is defeated after player's attack
                    if (Monster.CurrentHitPoints <= 0)
                    {
                        Console.WriteLine($"You have defeated the {Monster.Name}! Press any key to continue");
                        if (Monster.Drop != null)
                        {
                            Player.Inventory.Items.Add(Monster.Drop);
                            Console.WriteLine($"You have dropped {Monster.Drop}");
                        }
                        Console.WriteLine("Press any key to continue ...");
                        Player.Done_Quests.Add(Monster.Quest);
                        inBattle = false;  // End the battle
                        Console.ReadKey();
                        continue;
                    }

                    // Monster attacks back if not dead
                    damage = RandomDamage(0, Monster.MaximumDamage);
                    Console.WriteLine($"The {Monster.Name} hit you for {damage} damage.");
                    Player.Current_hp -= damage;

                    // Check if the player is defeated after monster's attack
                    if (Player.Current_hp <= 0)
                    {
                        Console.WriteLine("You have been defeated............");
                        inBattle = false;  // End the battle
                        Console.ReadKey();
                    }
                    continue;

                case "2":
                    // Player flees from battle

                    // if goblin, no flee allowed
                    if (Monster == goblin.Goblin)
                    {
                        Console.WriteLine($"{Player.Name}, you can't escape the magnificient Goblin!");
                        break;
                    }

                    BattleModeFlee();
                    inBattle = false;  // Exit the battle after fleeing
                    break;

                case "3":
                    // Opens inventory
                    Console.WriteLine("Opening inventory...");
                    Player.InvMenu();
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
            if (!inBattle || Player.Current_hp <= 0)
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
            int damage = RandomDamage(0, Monster.MaximumDamage);
            Console.WriteLine($"The {Monster.Name} hit you for {damage} while you were trying to flee!");
            Player.Current_hp -= damage;
        }
    }

    public int KasperDamage()
    {
        int kasperDamage = RandomDamage(0, Weapon.maximumDamage);
        Random rnd = new Random();
        int rndChance = rnd.Next(0, 101);
        if (rndChance > 0 && rndChance < 50)
        {
            return kasperDamage * 2;
        }
        else
        {
            return 0;
        }
    }
}