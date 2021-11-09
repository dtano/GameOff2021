using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Maybe make CustomerData a monobehaviour? 
[System.Serializable]
public class CustomerData
{
    private string _name;
    private Sprite _sprite;
    
    // Customer's counting stats
    // POSSIBLE IMPROVEMENT: Make a CustomerStat class and make child classes that represent stats below
    private Stat _endurance;
    private Stat _survivability;
    private Stat _perception;
    private Stat _intelligence;

    private float _survivalProbability;

    List<Trait> traits = new List<Trait>();
    
    
    public CustomerData(string name, int endurance, int survivability, int perception, int intelligence)
    {
        _name = name;
        _endurance = new Stat(endurance);
        _survivability = new Stat(survivability);
        _perception = new Stat(perception);
        _intelligence = new Stat(intelligence);

        _survivalProbability = CalculateSurvivalProbability();
        // _sprite = sprite;
    }

    // Gonna move this function elsewhere
    private float CalculateSurvivalProbability()
    {
        int maxStatValue = Stat.GetMaxStatValue();
        // THE METHOD COMMENTED BELOW CAN BE USED IF WEIGHTS ARE ASSIGNED TO EACH STAT
        //float prob = (_endurance.GetBaseValue()/maxStatValue) + (_survivability.GetBaseValue()/maxStatValue) + (_intelligence.GetBaseValue()/maxStatValue);
        
        
        float prob = (_endurance.GetBaseValue() + _survivability.GetBaseValue() + _intelligence.GetBaseValue()) / (maxStatValue * 3);

        return prob;
    }

    public Stat Endurance { get => _endurance; set => _endurance = value; }
    public Stat Survivability { get => _survivability; set => _survivability = value; }
    public Stat Perception { get => _perception; set => _perception = value; }
    public Stat Intelligence { get => _intelligence; set => _intelligence = value; }

    public float SurvivalProbability { get => _survivalProbability; set => _survivalProbability = value; }
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
        string statsString = $"endurance = {_endurance.GetBaseValue()}\nsurvivability = {_survivability.GetBaseValue()}\nintelligence = {_intelligence.GetBaseValue()}\n";
        sb.Append(statsString);

        sb.Append($"Survival probability: {_survivalProbability}");

        return sb.ToString();
    }
}
