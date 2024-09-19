using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// Adds the goblin class, calculates a chance for it to appear and calls the battlemode.

public class GoblinEncounter
{
    public Monster Goblin = World.MonsterByID(World.MONSTER_ID_GOBLIN_THIEF);
    public Player Player;
    public int rounds = 0;
    public Inventory Inventory = new Inventory();

    public GoblinEncounter(Player argPlayer)   
    {
        this.Player = argPlayer;
    }

    // chance of encounter (change the double and the chance changes)
    public bool ChanceOfEncounter()
    {
        Random rand = new Random();
        double randResult = rand.NextDouble();
        if (randResult <= 0.30)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // goes into battle
    public void IntoBattle()
    {
        BattleMode Battle = new BattleMode(Goblin, Player);
        if (ChanceOfEncounter())
        {
            Battle.BattleMenu();
        }
    }
}
