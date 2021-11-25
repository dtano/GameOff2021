using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents a major stat that will affect the customer's survivability
[System.Serializable]
public class Stat : IModifiable
{
    // Needs stat modifiers
    private static int _maxValue = 10;
    [SerializeField] private float _baseValue;

    private float valueAfterBonuses;

    private List<BaseModifier> statModifiers;
    private ModifierCalculator modifierCalculator;

    public float ModifiedValue => valueAfterBonuses;
    //public float BaseValue => _baseValue;
    public float BaseValue {get => _baseValue; set => _baseValue = value;}

    public Stat(float baseValue)
    {
        _baseValue = baseValue;
        valueAfterBonuses = _baseValue;
        statModifiers = new List<BaseModifier>();

        modifierCalculator = new ModifierCalculator(_baseValue, _maxValue);
    }

    public static int GetMaxStatValue()
    {
        return _maxValue;
    }

    public bool AddModifier(StatModifier mod)
    {
        if(_baseValue > 0){
            statModifiers.Add(mod);
            statModifiers.Sort(ModifierSorter.CompareModifierOrder);

            ApplyModifiers();
            return true;
        }

        return false;
    }

    public bool RemoveModifier(StatModifier mod)
    {
        if(statModifiers.Remove(mod)){
            // reapply modifiers as this modifier has been removed
            ApplyModifiers();
            //mod.ClearTraitBonuses();
            return true;
        }
        
        return false;
    }

    public void ApplyModifiers()
    {
        valueAfterBonuses = modifierCalculator.CalculateValueAfterModifierBonuses(statModifiers);
    }
}
