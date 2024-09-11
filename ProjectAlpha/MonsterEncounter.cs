// Made a barebone class for the moster encounter, it returns fight, sneak or flee, which should be used to detect battle mode.
// In the future implement name of the monster and name of the player if needed.

public class Encounter
{
    public string player;
    public string monster;
    public bool engaged;

    public Encounter(string player, string monster, bool engaged)
    {
        this.player = player;
        this.monster = monster; 
        this.engaged = engaged;
    }

    public string choice()
    {
        while (true)
        {
            Console.WriteLine($"You are facing [monster]");
            Console.WriteLine("How do you wish to proceed:");
            Console.Write("A: Attack\nB: Sneak\nC: Flee");
            string choice = Console.ReadLine();
            if (choice == "A")
            {
                return "Fight";
            }
            else if (choice == "B")
            {
                return "Sneak";
            }
            else if (choice == "C")
            {
                return "Flee";
            }

        }
    }
}