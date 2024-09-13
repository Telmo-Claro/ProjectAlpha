// Made a barebone class for the moster encounter, it returns fight, sneak or flee, which should be used to detect battle mode.
// In the future implement name of the monster and name of the player if needed.

public class Encounter
{
    public string player;
    public string monster;
    public bool engaged;

    public Encounter(string player, string monster)
    {
        this.player = player;
        this.monster = monster;
    }

    public string choice()
    {
        while (true)
        {
            Console.WriteLine($"{player} is facing {monster}");
            Console.WriteLine("How do you wish to proceed:");
            Console.Write("1) Attack\n2) Sneak\n3) Flee");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {

            }
            else if (choice == 2)
            {
                return "Sneak";
            }
            else if (choice == 3)
            {
                return "Flee";
            }

        }
    }
}