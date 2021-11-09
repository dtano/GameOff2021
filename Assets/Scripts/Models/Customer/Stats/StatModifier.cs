using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StatModType
{
    Flat,
    Percent
}

[System.Serializable]
public class StatModifier
{
    public float Value;
    public StatModType Type;

    public StatModifier(float value, StatModType type)
    {
        Value = value;
        Type = type;
    }
}
