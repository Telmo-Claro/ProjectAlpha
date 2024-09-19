public class Potion : Item
{
    public int HealthPoints;
    public bool Usable;

    public Potion(int id, string name, int healthpoints) : base(id, name)
    {
        this.ID = id;
        this.HealthPoints = healthpoints;
        this.Name = name;
        this.Usable = true;
    }
}