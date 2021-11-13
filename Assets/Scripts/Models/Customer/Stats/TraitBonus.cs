using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitBonus : BaseModifier
{
    public TraitBonus(float value, StatModType type, int order) : base(value, type, order){}

    public TraitBonus(float value, StatModType type) : base(value, type, (int)type) {}

    public TraitBonus(StatModifier statMod) : base(statMod.Value, statMod.Type, statMod.Order){}
}
