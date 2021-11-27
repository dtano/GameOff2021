using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traits/Nullify items Trait")]
public class NullifyTrait : Trait, INullify
{
    [SerializeField] List<ItemObject> itemsToNullify = new List<ItemObject>();


    protected override void TraitEffect(Item item)
    {
        Nullify(item);
    }


    public void Nullify(Item item)
    {
        Debug.Log("Boosting now");

        ItemObject itemObjToAffect = item.ItemObject;

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
