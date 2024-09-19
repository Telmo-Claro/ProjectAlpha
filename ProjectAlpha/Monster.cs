public class Monster
{
    public int ID;
    public string Name;
    public int CurrentHitPoints;
    public int MaximumHitPoints;
    public int MaximumDamage;
    public Quest Quest;

    public Monster(int id, string Name, int MaximumDamage, int MaximumHitPoints, int CurrentHitPoints, Quest quest)
    {
        this.ID = id;
        this.Name = Name;
        this.CurrentHitPoints = CurrentHitPoints;
        this.MaximumHitPoints = MaximumHitPoints;
        this.MaximumDamage = MaximumDamage;
        this.Quest = quest;
    }
}