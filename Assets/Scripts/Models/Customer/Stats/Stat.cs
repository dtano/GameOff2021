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

    private int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if(a.Order < b.Order){
            return -1;
        }else if(a.Order > b.Order){
            return 1;
        }

        return 0;
    }

    public void AddModifier(StatModifier mod)
    {
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);

        ApplyModifiers();
    }

    public void AddModifier(StatModifier mod, List<Trait> traits)
    {
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);

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
        float finalValue = _baseValue;
        float sumPercentAdd = 0;
        
        int i = 0;
        foreach(StatModifier mod in statModifiers){
            switch(mod.Type){
                case StatModType.Flat:
                    finalValue += mod.Value;
                    Debug.Log($"Item after mod {finalValue}");
                    break;
                case StatModType.PercentAdd:
                    sumPercentAdd += mod.Value;

                    if(i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModType.PercentAdd){
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }

                    break;
                case StatModType.PercentMult:
                    finalValue *= 1 + mod.Value;
                    break;
            }
            i++;
        }

        valueAfterBonuses = finalValue;
    }
}
