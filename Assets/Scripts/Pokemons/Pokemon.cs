using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class that defines our pokemon, return valies based on the pokemons level
public class Pokemon
{
    public PokemonBase Base { get; set; }
    public int Level { get; set; }

    public List<Move> Moves { get; set; } // moves list
    public int HP { get; set; } // current HP

    public Pokemon(PokemonBase pBase, int pLevel)
    {
        Base = pBase; // base information to start with
        Level = pLevel; // current level of the pokemon
        HP = MaxHp; // current HP based on MaxHP using level

        // add the moves to this pokemon based on its level
        Moves = new List<Move>();
        foreach (var move in Base.LearnableMoves)
        {
            // check if a moves level is less than that of the pokemon
            if (move.Level <= Level)
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
        get { return Mathf.FloorToInt((Base.MaxHp * Level) / 100f) + 5; } 
    }

    public int Attack { 
        get { return Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5; } 
    }

    public int Deffense { 
        get { return Mathf.FloorToInt((Base.Deffense * Level) / 100f) + 5; } 
    }

    public int SpAttack { 
        get { return Mathf.FloorToInt((Base.SpAttack * Level) / 100f) + 5; } 
    }

    public int SpDefense { 
        get { return Mathf.FloorToInt((Base.SpDefense * Level) / 100f) + 5; } 
    }

    public int Speed { 
        get { return Mathf.FloorToInt((Base.Speed * Level) / 100f) + 10; } 
    }
}
