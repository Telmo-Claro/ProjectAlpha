public class Location
{
    public int Id;
    public string Name;
    public string Description;
    public var placeholder1;
    public var placeholder2;
    public Location LocationToNorth;
    public Location LocationToSouth;
    public Location LocationToEast;
    public Location LocationToWest;

    public Location(int id, string name, string description, var ph1, var ph2)
    {
        Id = id;
        Name = name;
        Description = description;
        placeholder1 = ph1;
        placeholder2 = ph2;
    }
}