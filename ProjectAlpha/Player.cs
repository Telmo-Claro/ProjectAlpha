public class Player
{
    public string Name;
    public Weapon Current_weapon;
    public int Current_hp;
    public int Max_hp;
    public Location Current_location;

    public Player(string name, Weapon current_weapon, int current_hp, int max_hp, Location current_location)
    {
        this.Name = name;
        this.Current_weapon = current_weapon;
        this.Current_hp = current_hp;
        this.Max_hp = max_hp;
        this.Current_location = current_location;
    }
}