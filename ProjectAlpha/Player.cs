
public class Player
{
    public string Name;
    public Weapon Current_weapon;
    public int Current_hp;
    public int Max_hp;
    public bool InFight;
    public Location Current_location;
    public Location Previous_Location;
    public List<Quest> Quest_List = new List<Quest> { };
    public List<Quest> Done_Quests = new List<Quest>() { };
    public List<Monster> Monster_Encountered = new List<Monster>() { };
    public Inventory Inventory = new Inventory();

    public Player(string name, Weapon current_weapon, int current_hp, int max_hp, Location current_location)
    {
        this.Name = name;
        this.Current_weapon = current_weapon;
        this.Current_hp = current_hp;
        this.Max_hp = max_hp;
        this.Current_location = current_location;
    }

    public void InvMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Inventory");
            Console.WriteLine("---------");
            Console.WriteLine($"Current Weapon: {Current_weapon.Name}");
            Console.WriteLine("---------");
            for (int i = 0; i < Inventory.Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Inventory.Items[i].Name}");
            }
            Console.WriteLine("(1) Choose Item");
            Console.WriteLine("(2) Sort A-Z/Z-A");
            Console.WriteLine("(3) Exit");
            var tmp = Console.ReadLine();
            if (tmp == "1")
            {
                Item item = Inventory.ChooseFromInv();
                if (item != null)
                {
                    ChoosedItemMenu(item);
                }
            }
            else if (tmp == "2")
            {
                Inventory.InvSort();
            }
            else if (tmp == "3")
            {
                break;
            }
        }
    }

    public void ChoosedItemMenu(Item item)
    {
        while (true)
        {
            if (item.Name == "Snus")
            {
                UseSnus();
                break;
            }
            else if (item.Name == "Tren")
            {
                InjectTren();
                break;
            }
            else if (item.Name == "Beer")
            {
                Item? Beer = Inventory.Items.FirstOrDefault(i => i.ID == 3 && i.Name == "Beer");
                Inventory.Items.Remove(Beer);
                Console.WriteLine("Yummmmmmmmmmmm");
                Thread.Sleep(1000);
                break;
            }
            else if (item is Potion potion)
            {
                Console.Clear();
                Console.WriteLine($"Item: {item.Name}");
                Console.WriteLine("Do you want to use this Potion?");
                Console.WriteLine("(1) Yes");
                Console.WriteLine("(2) No");
                string tmp = Console.ReadLine();
                if (tmp == "1")
                {
                    Console.Clear();
                    Console.WriteLine($"You have used {item.Name}");
                    Console.WriteLine($"+ {potion.HealthPoints}");
                    Current_hp += potion.HealthPoints;
                    Inventory.Items.Remove(potion);
                    Thread.Sleep(1600);
                    break;
                }
                else if (tmp == "2")
                {
                    break;
                }
            }
            else if ((item is Weapon) && BattleMode.inBattle)
            {
                Console.Clear();
                Console.WriteLine("You cannot change your weapon in a fight!");
                Thread.Sleep(1000);
                break;
            }
            else if (item is Weapon weapon)
            {
                Console.Clear();
                Console.WriteLine($"Item: {item.Name}");
                Console.WriteLine("Do you want to equip this Weapon?");
                Console.WriteLine("(1) Yes");
                Console.WriteLine("(2) No");
                string tmp = Console.ReadLine();
                if (tmp == "1")
                {
                    Console.Clear();
                    Console.WriteLine($"You have equiped {item.Name}");
                    Inventory.Items.Add(Current_weapon);
                    Current_weapon = weapon;
                    Inventory.Items.Remove(weapon);
                    Thread.Sleep(800);
                    break;
                }
                else if (tmp == "2")
                {
                    break;
                }

            }
        }
    }
    void UseSnus()
    {
        Console.WriteLine("Hmmmmm I love the buzz");
        Current_hp -= 5;
        Item? Snus = Inventory.Items.FirstOrDefault(i => i.ID == 1 && i.Name == "Snus");
        Inventory.Items.Remove(Snus);

        Thread.Sleep(1500);
    }
    void InjectTren()
    {
        Console.WriteLine("aww it keeps stinging... RAAAAA( ๑ ˃̵ᴗ˂̵)و ♡");
        Current_hp = 1;
        Item? Tren = Inventory.Items.FirstOrDefault(i => i.ID == 4 && i.Name == "Tren");
        Inventory.Items.Remove(Tren);
        Thread.Sleep(1500);
    }
public string DisplayHealthBar()
    {
        string health = "";
        // Calculate the health percentage
        int healthPercentage = (Current_hp * 100) / Max_hp;
        int barLength = 10;

        // Calculate the number of filled segments
        int mathsSegments = (healthPercentage / 100) * barLength;

        // Build the health bar string
        //string healthBar = new string('-', mathsSegments) + new string('-', barLength - mathsSegments );

        // Display the health bar
        health += $"Health -`♡´- {Current_hp}/{Max_hp} {healthPercentage}%\n";
        return health;
    }
}