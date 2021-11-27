using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A trait that either boosts or reduces a stat 
[CreateAssetMenu(menuName = "Traits/Stat blanket trait")]
public class OverallStatTrait : Trait
{
    [SerializeField] private float effectPercentage;

    [SerializeField] StatModifier enduranceModifier;
    [SerializeField] StatModifier intelligenceModifier;
    [SerializeField] StatModifier survivabilityModifier;
    
    
    public override void Apply(Customer customer)
    {
        Stat intelligence = customer.CustomerData.Intelligence;
        //if(enduranceModifier.Value > 0) AffectChosenStat(customer.CustomerData.Endurance);
        Debug.Log($"Blanket boost");
        Debug.Log($"Before boost: {customer.CustomerData.Intelligence.ModifiedValue}");
        if(intelligenceModifier.Value > 0) {
            customer.CustomerData.Intelligence.AddModifier(intelligenceModifier);
            Debug.Log($"After boost: {customer.CustomerData.Intelligence.ModifiedValue}");
        }
        //if(survivabilityModifier.Value > 0) AffectChosenStat(customer.CustomerData.Survivability);
    }

    private void AffectChosenStat(ref Stat stat)
    {
        Debug.Log($"Blanket boost");
        Debug.Log($"Before boost: {stat.BaseValue}");
        stat.BaseValue = stat.BaseValue + (effectPercentage * stat.BaseValue);
        //stat.BaseValue += effectPercentage * stat.BaseValue;
        Debug.Log($"After boost: {stat.BaseValue}");
    }
    
    
    protected override void TraitEffect(Item item)
    {
        // Do nothing
    }
}
