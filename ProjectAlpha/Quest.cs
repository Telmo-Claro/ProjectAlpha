using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Quest
{
    public int ID;
    public string Name;
    public string Description;

    public Quest(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;

    }
}