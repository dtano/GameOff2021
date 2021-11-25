using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatModType
{
    Flat = 100,
    PercentAdd = 200,
    PercentMult = 300
}

public abstract class BaseModifier
{
    [SerializeField] private bool isLocked = false;

    [SerializeField] protected float _value;
    [SerializeField] protected StatModType _type;
    [SerializeField] protected int _order;
    
    public virtual float Value {get => _value;}
    public StatModType Type {get => _type;}
    public int Order {get; set;}

    public bool IsLocked => isLocked;

    public BaseModifier(float value, StatModType type, int order)
    {
        _value = value;
        _type = type;
        _order = order;

    }

    public BaseModifier(float value, StatModType type) : this (value, type, (int)type) {}

    public void Lock()
    {
        if(_value > 0) isLocked = true;
    }

    public void Unlock()
    {
        isLocked = false;
    }


}
