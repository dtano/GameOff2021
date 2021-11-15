using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullifyItemBonusTrait : Trait, INullify
{
    [SerializeField] private StatModifier enduranceModifier;
    [SerializeField] private StatModifier intelligenceModifier;
    [SerializeField] private StatModifier survivabilityModifier; 
    
    protected override void TraitEffect(Item item)
    {
        Nullify(item);
    }
    
    public void Nullify(Item item)
    {
        // Do some lock logic here
        if(enduranceModifier.IsLocked) item.EnduranceModifier.Lock();
        if(intelligenceModifier.IsLocked) item.IntelligenceModifier.Lock();
        if(survivabilityModifier.IsLocked) item.SurvivabilityModifier.Lock();
    }

}
