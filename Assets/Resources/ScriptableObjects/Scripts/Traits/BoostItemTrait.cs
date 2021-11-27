using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traits/Boost items trait")]
public class BoostItemTrait : Trait
{
    [SerializeField] private List<ItemObject> itemsToBoost = new List<ItemObject>();
    [SerializeField] private float effectPercentage;

    private bool hasAdded = false;
    
    
    private void Boost(Item item)
    {
        if(!hasAdded && !item.IsNullified()){
            ItemObject itemObject = item.ItemObject;
            if(itemsToBoost.Contains(itemObject)){
                hasAdded = true;
                if(item.EnduranceModifier.Value != 0) AddTraitBonusToModifier(item.EnduranceModifier);
                if(item.IntelligenceModifier.Value != 0) AddTraitBonusToModifier(item.IntelligenceModifier);
                if(item.SurvivabilityModifier.Value != 0) AddTraitBonusToModifier(item.SurvivabilityModifier);
            }
        }
    }

    private void AddTraitBonusToModifier(StatModifier statModifier)
    {
        statModifier.AddTraitBonus(CreateStatModifier());
    }

    private StatModifier CreateStatModifier()
    {
        return new StatModifier(effectPercentage, StatModType.PercentMult);
    }

    
    protected override void TraitEffect(Item item)
    {
        Boost(item);
    }
}
