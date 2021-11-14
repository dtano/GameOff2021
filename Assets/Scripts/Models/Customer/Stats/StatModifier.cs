using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatModifier : BaseModifier
{
    public override float Value {
        get => CalculateValueAfterBonuses();
    }

    private List<BaseModifier> traitBonuses = new List<BaseModifier>();

    public StatModifier(float value, StatModType type, int order) : base(value, type, order){}

    public StatModifier(float value, StatModType type) : base (value, type, (int)type) {}

    public StatModifier(StatModifier modifier) : base(modifier.Value, modifier.Type, modifier.Order){}

    private float CalculateValueAfterBonuses()
    {
        float totalBonuses = 0;

        if(traitBonuses != null && traitBonuses.Count > 0){
            foreach(BaseModifier mod in traitBonuses){
                // We need to do the same calculation that Stat does
                totalBonuses += mod.Value;
            }
        }
        
        return _value + totalBonuses;
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

    public bool AddTraitBonus(BaseModifier mod)
    {
        if(traitBonuses == null){
            traitBonuses = new List<BaseModifier>();
        }
        
        // Gotta make sure there is no duplicate modifier
        if(Value > 0 && !traitBonuses.Contains(mod)){
            traitBonuses.Add(mod);
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
