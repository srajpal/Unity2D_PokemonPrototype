using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// add a new menu option to the create menu to create the scriptable object
[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create new Move")]

// MoveBase defines the moves available for pokemon
public class MoveBase : ScriptableObject
{
    [SerializeField] string moveName;
    [TextArea] [SerializeField] string description;
    [SerializeField] PokemonType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    public string Name { get { return moveName; } }
    public string Description { get { return description; } }
    public PokemonType Type { get { return type; } }
    public int Power { get { return power; } }
    public int Accuracy { get { return accuracy; } }
    public int PP { get { return pp; } }

}
