public class Monster
{
    public string ID;
    public string Name;
    public int CurrentHitPoints;
    public int MaximumHitPoints;
    public int MaximumDamage;

    public Monster(string id, string Name, int CurrentHitPoints, int MaximumHitPoints, int MaximumDamage)
    {
        this.ID = id;
        this.Name = Name;
        this.CurrentHitPoints = CurrentHitPoints;
        this.MaximumHitPoints = MaximumHitPoints;
        this.MaximumDamage = MaximumDamage;
    }
}