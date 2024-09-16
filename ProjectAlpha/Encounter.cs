using System.Numerics;
using System.Threading;

public class Encounter
    {

    public Player player;
    public Monster monster;
    public bool monsterDefeated = false;

    public Encounter(Monster monster, Player player)
    {
        this.monster = monster;
        this.player = player;
    }

    public void choice()
    {
        while (true)
        {
            Console.WriteLine($"{player.Name} watch out! There is danger ahead!");
            Console.WriteLine("How do you wish to proceed:");
            Console.Write("1) Attack\n2) Sneak\n3) Flee\n> ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                if (player.Current_weapon.maximumDamage != 0)
                {
                    BattleMode battle = new BattleMode(monster, player);
                    battle.BattleMenu();
                    break;
                }
                else
                {
                    Console.WriteLine("Ah... maybe grab a weapon?");
                    player.Monster_Encountered.Remove(monster);
                    break;
                }

            }
            else if (choice == 2)
            {
                Random escapeChance = new Random();
                double chance = escapeChance.NextDouble();
                if (chance <= 0.30)
                {
                    Console.WriteLine("You sneaked succesfully! You may continue your adventure!");
                    return;
                }
                else
                {
                    Console.WriteLine("Almost! You got caught!");
                    BattleMode battle = new BattleMode(monster, player);
                    battle.BattleMenu();
                    return;
                }
            }
            else if (choice == 3)
            {
                (player.Current_location, player.Previous_Location) = (player.Previous_Location, player.Current_location);
                player.Monster_Encountered.Remove(monster);
                break;
            }
            else
            {
                Console.WriteLine("Wrong input! Try again!");
            }

        }
    }
 }
