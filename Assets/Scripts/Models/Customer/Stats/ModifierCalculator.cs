using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierCalculator
{
    private float _baseValue;
    private float _maxValue;

    public ModifierCalculator(float baseValue, float maxValue)
    {
        _baseValue = baseValue;
        _maxValue = maxValue;
    }


    public float CalculateValueAfterModifierBonuses(List<BaseModifier> modifiers)
    {
        float finalValue = _baseValue;
        float sumPercentAdd = 0;
        
        int i = 0;
        foreach(StatModifier mod in modifiers){
            switch(mod.Type){
                case StatModType.Flat:
                    finalValue += mod.Value;
                    break;
                case StatModType.PercentAdd:
                    sumPercentAdd += mod.Value;

                    if(i + 1 >=  modifiers.Count || modifiers[i + 1].Type != StatModType.PercentAdd){
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

        return finalValue;
    }
}
