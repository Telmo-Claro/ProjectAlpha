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
        Inventory.Items.Add(Current_weapon);
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
            Console.WriteLine("Choose Item (1)");
            Console.WriteLine("Sort A-Z/Z-A (2)");
            Console.WriteLine("Exit (3)");
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
            if (item is not Weapon weapon)
            {
                Console.Clear();
                Console.WriteLine("This item is not usable");
                Thread.Sleep(100);
                break;
            }
            else if ((item is Weapon) && BattleMode.inBattle)
            {
                Console.Clear();
                Console.WriteLine("You cannot change your weapon in a fight!");
                Thread.Sleep(1000);
                break;
            }
            else if (item is Weapon)
            {
                Console.Clear();
                Console.WriteLine($"Item: {item.Name}");
                Console.WriteLine("Do you want to equip this Weapon?");
                Console.WriteLine("Yes (1)");
                Console.WriteLine("No (2)");
                string tmp = Console.ReadLine();
                if (tmp == "1") 
                {
                    Console.Clear();
                    Console.WriteLine($"You have equiped {item.Name}");
                    Current_weapon = weapon;
                    Thread.Sleep(800);
                    break;
                }
                else if(tmp == "2") 
                {
                    break;
                }

            }
        }
        InvMenu();
    }
}