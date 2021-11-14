using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ModifierSorter
{
    public static int CompareModifierOrder(BaseModifier a, BaseModifier b)
    {
        if(a.Order < b.Order){
            return -1;
        }else if(a.Order > b.Order){
            return 1;
        }

        return 0;
    }
}
