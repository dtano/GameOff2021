using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A trait that either boosts or reduces a stat 
public class OverallStatTrait : Trait
{
    [SerializeField] private float effectPercentage;

    [SerializeField] StatModifier enduranceModifier;
    [SerializeField] StatModifier intelligenceModifier;
    [SerializeField] StatModifier survivabilityModifier;
    
    
    public override void Apply(Customer customer)
    {
        if(enduranceModifier.Value > 0) AffectChosenStat(customer.CustomerData.Endurance);
        if(intelligenceModifier.Value > 0) AffectChosenStat(customer.CustomerData.Intelligence);
        if(survivabilityModifier.Value > 0) AffectChosenStat(customer.CustomerData.Survivability);


    }

    private void AffectChosenStat(Stat stat)
    {
        stat.BaseValue += effectPercentage * stat.BaseValue;
    }
    
    
    protected override void TraitEffect(Item item)
    {
        // Do nothing
    }
}
