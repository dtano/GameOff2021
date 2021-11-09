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

    private List<StatModifier> statModifiers;

    public Stat(int baseValue)
    {
        _baseValue = baseValue;
        statModifiers = new List<StatModifier>();
    }

    public float GetBaseValue()
    {
        return _baseValue;
    }

    public static int GetMaxStatValue()
    {
        return _maxValue;
    }

    public void AddModifier(StatModifier mod)
    {
        statModifiers.Add(mod);
    }

    public bool RemoveModifier(StatModifier mod)
    {
        return statModifiers.Remove(mod);
    }
}
