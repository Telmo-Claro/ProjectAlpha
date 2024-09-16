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
        Console.Clear();
        Console.WriteLine($"You encountered a {Monsterrawr.Name}!");

        while (Playerrawr.Current_hp > 0)
        {
            if (Monsterrawr.CurrentHitPoints <= 0)
            {
                Console.WriteLine($"You have defeated the {Monsterrawr.Name}!");
                break;
            }

            Console.WriteLine("What would you like to do?");
            Console.WriteLine($"(1) Attack\n(2) Flee\n(3) Look at inventory\n(4) Quit game");
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine($"You hit {Monsterrawr.Name} for {RandomDamage(0, Weapon.maximumDamage)}");
                Monsterrawr.CurrentHitPoints -= RandomDamage(0, Weapon.maximumDamage);
            }
            if (Console.ReadLine() == "2")
            {
                BattleModeFlee();
                return;
            }
            if (Console.ReadLine() == "3")
            {
                //inventory open
            }
            if (Console.ReadLine() == "4")
            {
                System.Environment.Exit(0);
            }

            else
            {
                Console.WriteLine("Wrong input!");
            }

            Console.WriteLine($"The {Monsterrawr.Name} hit you for {RandomDamage(0, Monsterrawr.MaximumDamage)}");
            Playerrawr.Current_hp -= RandomDamage(0, Monsterrawr.MaximumDamage);
        }
    }

    public int RandomDamage(int maxDamage, int minDamage = 0)
    {
        // simple random damage returner
        Random rng = new Random();
        int rand = rng.Next(0, maxDamage);
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
            Console.WriteLine($"The {Monsterrawr.Name} hit you for {RandomDamage(0, Monsterrawr.MaximumDamage)} while you were trying to flee!");
            Playerrawr.Current_hp -= RandomDamage(0, Monsterrawr.MaximumDamage);
        }
    }
}