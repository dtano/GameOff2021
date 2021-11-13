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

    public override void Apply(Customer customer)
    {
        // Get customer's survival kit
        SurvivalKit survivalKit = customer.GetSurvivalKit();

        survivalKit.SetOnItemAdd(Boost);
        Debug.Log("Applied trait");
    }

    private void Boost(Item item)
    {
        Debug.Log("Boosting now");

        if(enduranceModifier != null) item.EnduranceModifier.AddTraitBonus(enduranceModifier);
        
        // if(intelligenceModifier != null) item.IntelligenceModifier.AddTraitBonus(intelligenceModifier);
        // if(survivabilityModifier != null) item.SurvivabilityModifier.AddTraitBonus(survivabilityModifier);

        // item.EnduranceModifier.Value += enduranceModifier.Value;
        // item.IntelligenceModifier.Value += intelligenceModifier.Value;
        // item.SurvivabilityModifier.Value += survivabilityModifier.Value;
    }
}
