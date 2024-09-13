public class Location
{
    public int ID;
    public string Name;
    public string Description;
    public Location LocationToNorth = null;
    public Location LocationToSouth = null;
    public Location LocationToEast = null;
    public Location LocationToWest = null;
    public Quest QuestAvailableHere = null;
    public Monster MonsterLivingHere = null;

    public Location(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;

    }
}