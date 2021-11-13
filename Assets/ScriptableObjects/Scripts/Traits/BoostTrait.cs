using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traits/Boost Trait")]
public class BoostTrait : Trait
{
    // This will be the Boost item modifier trait
    [SerializeField] private StatModifier enduranceModifier;
    [SerializeField] private StatModifier intelligenceModifier;
    [SerializeField] private StatModifier survivabilityModifier; 


    protected virtual void Boost(Item item)
    {
        Debug.Log("Boosting now");

        if(!item.IsNullified()){
            if(enduranceModifier != null) item.EnduranceModifier.AddTraitBonus(enduranceModifier);
            //if(intelligenceModifier != null) item.IntelligenceModifier.AddTraitBonus(intelligenceModifier);
            //if(survivabilityModifier != null) item.SurvivabilityModifier.AddTraitBonus(survivabilityModifier);
        }
    }

    protected override void TraitEffect(Item item)
    {
        Boost(item);
    }
}
