using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traits/Nullify items Trait")]
public class NullifyTrait : Trait
{
    [SerializeField] List<ItemObject> itemsToNullify = new List<ItemObject>();

    // public override void Apply(Customer customer)
    // {
    //     SurvivalKit survivalKit = customer.GetSurvivalKit();

    //     survivalKit.SetOnItemAdd(null);

    // }
    
    protected override void TraitEffect(Item item)
    {
        Nullify(item);
    }


    protected virtual void Nullify(Item item)
    {
        Debug.Log("Boosting now");

        ItemObject itemObjToAffect = item.GetItemObject();

        if(itemsToNullify.Contains(itemObjToAffect))
        {
            // Find item's modifier values and give a counter to it
            item.Nullify();

            // Clear trait bonuses
            item.ClearTraitBonuses();

            // How do I reactivate it though????
        }
    }
}
