using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Weapon
{
    public int id;
    public int maximumDamage;
    public string name;

    public Weapon(int id, int maximumDamage, string name)
    {
        this.id = id;
        this.maximumDamage = maximumDamage;
        this.name = name;
    }
}