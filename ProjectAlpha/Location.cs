public class Location
{
    public int ID;
    public string Name;
    public string Description;
    public Location LocationToNorth;
    public Location LocationToSouth;
    public Location LocationToEast;
    public Location LocationToWest;
    public Quest QuestAvailableHere;
    public Monster MonsterLivingHere;

    public Location(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;

    }
}