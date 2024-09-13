public class Encounter
    {

    public Player mc;
    public Monster monsterLivingHere;

    public Encounter(Player mc, Monster monsterLivingHere)
    {
        this.mc = mc;
        this.monsterLivingHere = monsterLivingHere;
    }

    public string choice()
    {
        while (true)
        {
            Console.WriteLine($"{mc.Name} is facing {monsterLivingHere.Name}");
            Console.WriteLine("How do you wish to proceed:");
            Console.Write("1) Attack\n2) Sneak\n3) Flee\n> ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                return "Attack";
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
