using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    private bool _helmet;
    private bool _defend;

    public Player(int hp, int armor)
    {
        _hp = hp;
        _armor = armor;
        _maxHP = hp;
        _helmet = false;
        _defend = false;
    }
   
    public bool Helmet
    {
        get { return _helmet; }
        set { _helmet = value; }
    }

    public bool Defend
    {
        get { return _defend; }
        set { _defend = value; }
    }
}
