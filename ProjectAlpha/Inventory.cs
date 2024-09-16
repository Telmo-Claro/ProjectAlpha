public class Inventory
{
    public List<Item> Items;
    public bool Sort;
    public Inventory()
    {
        Items = new List<Item>();
    }

    public void InvSort()
    {
        if (Sort)
        {
            Items.Sort((item1, item2) => item1.Name.CompareTo(item2.Name));
            Sort = false;
        }
        else
        {
            Items.Sort((item1, item2) => item2.Name.CompareTo(item1.Name));
            Sort = true;
        }
    }

    public Item ChooseFromInv()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Inventory");
            Console.WriteLine("---------");
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Items[i].Name}");
            }
            Console.WriteLine("Exit (0)");
            Console.WriteLine("Choose Item Number: ");
            int tmp = Convert.ToInt32(Console.ReadLine());
            if (tmp == 0)
            {
                return null;
            }
            else if ((tmp > 0) | (tmp <= Items.Count))
            {
                return Items[tmp - 1];
            }
            
        }
    }
}

