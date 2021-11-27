using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A trait that either boosts or reduces a stat 
[CreateAssetMenu(menuName = "Traits/Stat blanket trait")]
public class OverallStatTrait : Trait
{
    [SerializeField] StatModifier enduranceModifier;
    [SerializeField] StatModifier intelligenceModifier;
    [SerializeField] StatModifier survivabilityModifier;
    
    
    public override void Apply(Customer customer)
    {
        if(enduranceModifier.Value != 0) customer.CustomerData.Endurance.AddModifier(enduranceModifier);
        if(intelligenceModifier.Value != 0) customer.CustomerData.Intelligence.AddModifier(intelligenceModifier);
        if(survivabilityModifier.Value != 0) customer.CustomerData.Survivability.AddModifier(survivabilityModifier);
    }

    protected override void TraitEffect(Item item)
    {
        // Do nothing
    }
}
