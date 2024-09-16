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
}

