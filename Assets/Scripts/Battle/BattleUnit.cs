using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonBase _base;
    [SerializeField] int _level;
    [SerializeField] bool _isPlayerUnit;

    public Pokemon Pokemon { get; set; }

    public void Setup()
    {
        Pokemon = new Pokemon(_base, _level);
        if (_isPlayerUnit) 
        {
            GetComponent<Image>().sprite = Pokemon.Base.BackSprite;
        }
        else
        {
            GetComponent<Image>().sprite = Pokemon.Base.FrontSprite;
        }
    }
}
