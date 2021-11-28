using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackSlot : ItemSlot
{
    // Needs to have a reference to the survival kit then
    [SerializeField] SurvivalKit survivalKit;
    
    void Awake()
    {
        survivalKit = GetComponentInParent<SurvivalKit>();
    }
    
    protected override void OnValidate()
    {
        base.OnValidate();
    }

    public override bool CanAddStack(Item item, int amount = 1)
    {
        return false;
    }

 /*   public override bool CanReceiveItem(Item item)
    {
        if (item = null)
            return true;

        EquippableItem equippableItem = item as EquippableItem;
        return equippableItem != null;
    }*/
}
