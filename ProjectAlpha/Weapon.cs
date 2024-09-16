using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Weapon : Item
{
    public int ID;
    public int maximumDamage;
    public string Name;

    public Weapon(int id, string name, int maximumDamage) : base(id, name)
    {
        this.ID = id;
        this.maximumDamage = maximumDamage;
        this.Name = name;
    }
}