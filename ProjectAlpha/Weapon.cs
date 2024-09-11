using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Weapon
{
    public int ID;
    public int maximumDamage;
    public string name;

    public Weapon(int id, string name, int maximumDamage)
    {
        this.ID = id;
        this.maximumDamage = maximumDamage;
        this.name = name;
    }
}