using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traits/Boost Trait")]
public class BoostTrait : Trait
{
    // This will be the Boost item modifier trait
    [SerializeField] protected StatModifier enduranceModifier;
    [SerializeField] protected StatModifier intelligenceModifier;
    [SerializeField] protected StatModifier survivabilityModifier; 


    protected virtual void Boost(Item item)
    {
        if(!item.IsNullified()){
            if(enduranceModifier.Value != 0) item.EnduranceModifier.AddTraitBonus(enduranceModifier);
            if(intelligenceModifier.Value != 0) item.IntelligenceModifier.AddTraitBonus(intelligenceModifier);
            if(survivabilityModifier.Value != 0) item.SurvivabilityModifier.AddTraitBonus(survivabilityModifier);
        }
    }

    protected override void TraitEffect(Item item)
    {
        Boost(item);
    }
}
