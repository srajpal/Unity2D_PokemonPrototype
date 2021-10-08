using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    PokemonBase _base;
    int _level;

    public Pokemon(PokemonBase pBase, int pLevel)
    {
        _base = pBase;
        _level = pLevel;
    }

    public int MaxHp { 
        get { return Mathf.FloorToInt((_base.MaxHp * _level) / 100f) + 5; } 
    }

    public int Attack { 
        get { return Mathf.FloorToInt((_base.Attack * _level) / 100f) + 5; } 
    }

    public int Deffense { 
        get { return Mathf.FloorToInt((_base.Deffense * _level) / 100f) + 5; } 
    }

    public int SpAttack { 
        get { return Mathf.FloorToInt((_base.SpAttack * _level) / 100f) + 5; } 
    }

    public int SpDefense { 
        get { return Mathf.FloorToInt((_base.SpDefense * _level) / 100f) + 5; } 
    }

    public int Speed { 
        get { return Mathf.FloorToInt((_base.Speed * _level) / 100f) + 10; } 
    }
}
