using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents a major stat that will affect the customer's survivability
[System.Serializable]
public class Stat
{
    private static int _maxValue = 5;
    [SerializeField] private float _baseValue;

    public Stat(int baseValue)
    {
        _baseValue = baseValue;
    }

    public float GetBaseValue()
    {
        return _baseValue;
    }

    public static int GetMaxStatValue()
    {
        return _maxValue;
    }
}
