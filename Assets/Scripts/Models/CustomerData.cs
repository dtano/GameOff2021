using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Maybe make CustomerData a monobehaviour? 
public class CustomerData
{
    private string _name;
    private Sprite _sprite;
    
    // Customer's counting stats
    // POSSIBLE IMPROVEMENT: Make a CustomerStat class and make child classes that represent stats below
    private int _strength;
    private int _vitality;
    private int _perception;
    private int _intelligence;

    List<Trait> traits = new List<Trait>();
    
    
    public CustomerData(string name, int strength, int vitality, int perception, int intelligence)
    {
        _name = name;
        _strength = strength;
        _vitality = vitality;
        _perception = perception;
        _intelligence = intelligence;
        // _sprite = sprite;
    }

    public int Strength { get => _strength; set => _strength = value; }
    public int Vitality { get => _vitality; set => _vitality = value; }
    public int Perception { get => _perception; set => _perception = value; }
    public int Intelligence { get => _intelligence; set => _intelligence = value; }
    // public Sprite Sprite { get => _sprite; set => _sprite = value; }

    public bool AddTrait(Trait trait)
    {
        if(traits.Contains(trait)){
            return false;
        }

        traits.Add(trait);
        return true;
    }

    public bool RemoveTrait(Trait trait)
    {
        return traits.Remove(trait);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        // Show name
        sb.AppendFormat("Name: {0}\n", _name);

        // Show stats
        string statsString = $"strength = {_strength}\nvitality = {_vitality}\nperception = {_perception}\nintelligence = {_intelligence}\n";
        sb.Append(statsString);

        return sb.ToString();
    }
}
