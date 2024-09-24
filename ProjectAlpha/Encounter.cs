using System.Numerics;
using System.Threading;

public class Encounter
{

    public Player Player;
    public Monster Monster;
    public bool monsterDefeated = false;

    public Encounter(Monster monster, Player player)
    {
        this.Monster = monster;
        this.Player = player;
    }

    public void choice()
    {
        while (true)
        {
            Console.WriteLine($"{Player.Name} watch out! There is danger ahead!");
            Console.WriteLine("How do you wish to proceed:");
            Console.Write("(1) Attack\n(2) Sneak\n(3) Flee\n");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                if (Player.Current_weapon.maximumDamage != 0)
                {
                    BattleMode battle = new BattleMode(Monster, Player);
                    SoundAccess.PlayFight();
                    battle.BattleMenu();
                    break;
                }
                else
                {
                    Console.WriteLine("Ah... maybe grab a weapon?");
                    Player.Monster_Encountered.Remove(Monster);
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
                    BattleMode battle = new BattleMode(Monster, Player);
                    battle.BattleMenu();
                    return;
                }
            }
            else if (choice == 3)
            {
                (Player.Current_location, Player.Previous_Location) = (Player.Previous_Location, Player.Current_location);
                Player.Monster_Encountered.Remove(Monster);
                break;
            }
            else
            {
                Console.WriteLine("Wrong input! Try again!");
            }
        }
    }
}
