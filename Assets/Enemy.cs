using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    protected bool _charge;
    public Enemy(int hp, int armor)
    {
        _hp = hp;
        _armor = armor;
        _maxHP = hp;
    }

    public bool Charge
    {
        get { return _charge; }
        set { _charge = value; }
    }
}
