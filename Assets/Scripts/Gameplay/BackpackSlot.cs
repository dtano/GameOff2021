using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackSlot : ItemSlot
{
    protected override void OnValidate()
    {
        base.OnValidate();
    }

   /* public override bool CanReceiveItem(Item item)
    {
        if (item = null)
            return true;

        EquippableItem equippableItem = item as EquippableItem;
        return equippableItem != null;
    }*/
}
