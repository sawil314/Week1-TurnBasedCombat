using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature
{
    protected int _hp;
    protected int _maxHP;
    protected int _armor;
   // protected int _maxArmor;

    public int HP
    {
        get { return _hp; }
        set { _hp = value; }
    }
    public int MaxHP
    {
        get { return _maxHP; }
    }
     public int Armor
    {
        get { return _armor; }
        set { _armor = value; }
    }
    /*
    public int MaxArmor
    {
        get { return _maxArmor; }
        set { _maxArmor = value; }
    }*/

}
 