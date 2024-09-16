using System.Xml;

public class BattleMode
{
    public int damageByMonster;
    public int damageByPlayer;
    public Monster Monsterrawr;
    public Player Playerrawr;
    public Weapon Weapon;

    public BattleMode(Monster monster, Player player)
    {
        this.Monsterrawr = monster;
        this.Playerrawr = player;
        this.Weapon = player.Current_weapon;
    }

    public void BattleMenu()
    {
        Console.WriteLine($"You encountered a {Monsterrawr.Name}!");

        while (Playerrawr.Current_hp > 0)
        {
            int damage = 0;

            if (Monsterrawr.CurrentHitPoints <= 0)
            {
                Console.WriteLine($"You have defeated the {Monsterrawr.Name}!");
                break;
            }

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(1) Attack\n(2) Flee\n(3) Look at inventory\n(4) Quit game");

            // Get the player input once and use it in the switch statement
            string? playerChoice = Console.ReadLine();

            switch (playerChoice)
            {
                case "1":
                    damage = RandomDamage(0, Weapon.maximumDamage);
                    Console.WriteLine($"You hit {Monsterrawr.Name} for {damage}");
                    Monsterrawr.CurrentHitPoints -= damage;
                    continue;

                case "2":
                    BattleModeFlee();
                    break;

                case "3":
                    // Inventory open logic here
                    Console.WriteLine("Opening inventory...");
                    continue;

                case "4":
                    System.Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Wrong input!");
                    continue;
            }

            if (playerChoice == "2")
                break;

            // Monster attacks the player
            damage = RandomDamage(0, Monsterrawr.MaximumDamage);
            Console.WriteLine($"The {Monsterrawr.Name} hit you for {damage}");
            Playerrawr.Current_hp -= damage;
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