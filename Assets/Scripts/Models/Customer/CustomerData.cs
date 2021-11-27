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
    private Stat _intelligence;

    private float _survivalProbability;

    private List<Trait> traits = new List<Trait>();
    
    
    public CustomerData(string name, int endurance, int survivability, int intelligence)
    {
        _name = name;
        _endurance = new Stat(endurance);
        _survivability = new Stat(survivability);
        _intelligence = new Stat(intelligence);
        
        // _sprite = sprite;
    }

    public CustomerData(CustomerInformation customerInformation)
    {
        _name = customerInformation._name;
        _endurance = new Stat(customerInformation.Endurance.BaseValue);
        _survivability = new Stat(customerInformation.Survivability.BaseValue);
        _intelligence = new Stat(customerInformation.Intelligence.BaseValue);

        //traits = customerInformation.Traits;
        
        _sprite = customerInformation._sprite;
    }

    public Stat Endurance { get => _endurance; set => _endurance = value; }
    public Stat Survivability { get => _survivability; set => _survivability = value; }
    public Stat Intelligence { get => _intelligence; set => _intelligence = value; }

    public float SurvivalProbability { get => _survivalProbability; set => _survivalProbability = value; }
    public string Name {get => _name; set => _name = value;}
    public Sprite Sprite {get => _sprite; set => _sprite = value;}
    public List<Trait> Traits {get => traits;}

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
        string statsString = $"endurance = {_endurance.BaseValue}\nsurvivability = {_survivability.BaseValue}\nintelligence = {_intelligence.BaseValue}\n";
        sb.Append(statsString);

        sb.Append($"Survival probability: {_survivalProbability}");

        return sb.ToString();
    }
}
