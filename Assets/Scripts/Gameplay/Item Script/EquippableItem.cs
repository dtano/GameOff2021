using UnityEngine;

[CreateAssetMenu]
public class EquippableItem : Item
{
    [TextArea]
    public string description;
    [Space]
    public StatModifier enduranceModifier;
    public StatModifier intelligenceModifier;
    public StatModifier survivabilityModifier;

    public void Equip (InventoryManager c)
    {

    }

    public void Unequip (InventoryManager c)
    {

    }

}
