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
    public float Value;
    public StatModType Type;
    public int Order;

    public StatModifier(float value, StatModType type, int order)
    {
        Value = value;
        Type = type;
        Order = order;
    }

    public StatModifier(float value, StatModType type) : this (value, type, (int)type) {}

    public StatModifier(StatModifier modifier)
    {
        Value = modifier.Value;
        Type = modifier.Type;
        Order = modifier.Order;
    }
}
