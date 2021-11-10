using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents a major stat that will affect the customer's survivability
[System.Serializable]
public class Stat
{
    // Needs stat modifiers
    private static int _maxValue = 5;
    [SerializeField] private float _baseValue;

    private float valueAfterBonuses;

    private List<StatModifier> statModifiers;

    public Stat(int baseValue)
    {
        _baseValue = baseValue;
        valueAfterBonuses = _baseValue;
        statModifiers = new List<StatModifier>();
    }

    public float GetBaseValue()
    {
        return _baseValue;
    }

    public float GetModifiedValue()
    {
        return valueAfterBonuses;
    }

    public static int GetMaxStatValue()
    {
        return _maxValue;
    }

    public void AddModifier(StatModifier mod)
    {
        statModifiers.Add(mod);

        ApplyModifiers();
    }

    public bool RemoveModifier(StatModifier mod)
    {
        if(statModifiers.Remove(mod)){
            // reapply modifiers as this modifier has been removed
            ApplyModifiers();
            return true;
        }
        
        return false;
    }

    private void ApplyModifiers()
    {
        float totalBonus = 0;
        foreach(StatModifier mod in statModifiers){
            totalBonus += mod.Value;
        }

        valueAfterBonuses = _baseValue + totalBonus;
    }
}
