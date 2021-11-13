using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StatModType
{
    Flat = 100,
    PercentAdd = 200,
    PercentMult = 300
}

[System.Serializable]
public class StatModifier
{
    [SerializeField] private float _value;
    public StatModType Type;
    public int Order;

    public float Value {
        get => CalculateValueAfterBonuses();
    }

    private List<StatModifier> traitBonuses;

    public StatModifier(float value, StatModType type, int order)
    {
        _value = value;
        Type = type;
        Order = order;

        traitBonuses = new List<StatModifier>();
    }

    public StatModifier(float value, StatModType type) : this (value, type, (int)type) {}

    public StatModifier(StatModifier modifier)
    {
        _value = modifier.Value;
        Type = modifier.Type;
        Order = modifier.Order;

        traitBonuses = new List<StatModifier>();
    }

    private float CalculateValueAfterBonuses()
    {
        float totalBonuses = 0;
        foreach(StatModifier mod in traitBonuses){
            totalBonuses += mod.Value;
        }

        return _value + totalBonuses;
    }

    public bool AddTraitBonus(StatModifier mod)
    {
        // Gotta make sure there is no duplicate modifier
        Debug.Log(mod.Value);
        if(!traitBonuses.Contains(mod)){
            traitBonuses.Add(mod);
            return true;
        }

        return false;
    }

    public bool RemoveTraitBonus(StatModifier mod)
    {
        return traitBonuses.Remove(mod);
    }

    public void ClearTraitBonuses()
    {
        traitBonuses.Clear();
    }
}
