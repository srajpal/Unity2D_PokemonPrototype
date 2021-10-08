using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class that defines our pokemon, return valies based on the pokemons level
public class Pokemon
{
    PokemonBase _base;
    int _level;

    public List<Move> Moves { get; set; } // moves list
    public int HP { get; set; } // current HP

    public Pokemon(PokemonBase pBase, int pLevel)
    {
        _base = pBase; // base information to start with
        _level = pLevel; // current level of the pokemon
        HP = _base.MaxHp; // current HP

        // add the moves to this pokemon based on its level
        Moves = new List<Move>();
        foreach (var move in _base.LearnableMoves)
        {
            // check if a moves level is less than that of the pokemon
            if (move.Level <= _level)
            {
                // add the move to the move list
                Moves.Add(new Move(move.Base));
            }

            // we can only have max 4 moves per pokemon
            if (Moves.Count >= 4)
            {
                break;
            }
        }
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
