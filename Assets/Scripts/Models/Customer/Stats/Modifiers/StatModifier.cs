using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatModifier : BaseModifier, IModifiable
{
    public override float Value {
        get => CalculateValueAfterBonuses();
    }

    private List<BaseModifier> traitBonuses = new List<BaseModifier>();
    private ModifierCalculator modifierCalculator;
    private float modifiedValue;

    public StatModifier(float value, StatModType type, int order) : base(value, type, order){}

    public StatModifier(float value, StatModType type) : base (value, type, (int)type) {}

    public StatModifier(StatModifier modifier) : base(modifier.Value, modifier.Type, modifier.Order){}

    private float CalculateValueAfterBonuses()
    {
        modifiedValue = _value;

        if(traitBonuses != null && traitBonuses.Count > 0){
            ApplyModifiers();
        }
        
        return modifiedValue;
    }

    public void ApplyModifiers()
    {
        if(modifierCalculator == null){
            modifierCalculator = new ModifierCalculator(_value, Stat.GetMaxStatValue());
        }
        modifiedValue = modifierCalculator.CalculateValueAfterModifierBonuses(traitBonuses);
    }

    public bool AddTraitBonus(BaseModifier mod)
    {
        if(traitBonuses == null){
            traitBonuses = new List<BaseModifier>();
        }
        
        // Gotta make sure there is no duplicate modifier
        if(Value > 0 && !traitBonuses.Contains(mod)){
            traitBonuses.Add(mod);

            traitBonuses.Sort(ModifierSorter.CompareModifierOrder);
            
            return true;
        }

        return false;
    }

    public List<BaseModifier> GetTraitBonuses()
    {
        return traitBonuses;
    }

    public bool RemoveTraitBonus(BaseModifier mod)
    {
        return traitBonuses.Remove(mod);
    }

    public void ClearTraitBonuses()
    {
        traitBonuses?.Clear();
    }
}
