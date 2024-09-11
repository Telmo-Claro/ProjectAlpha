public class Location
{
    public int Id;
    public string Name;
    public string Description;
    public Location LocationToNorth;
    public Location LocationToSouth;
    public Location LocationToEast;
    public Location LocationToWest;

    public Location(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;

    }
}