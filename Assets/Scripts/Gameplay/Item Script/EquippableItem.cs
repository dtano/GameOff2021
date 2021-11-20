using UnityEngine;

[CreateAssetMenu]
public class EquippableItem : ItemSO
{
    [TextArea]
    public string description;
    [Space]
    public StatModifier enduranceModifier;
    public StatModifier intelligenceModifier;
    public StatModifier survivabilityModifier;

    public override ItemSO GetCopy()
    {
        return Instantiate(this);
    }

    public override void Destroy()
    {
        Destroy(this);
    }

    public void Equip (InventoryManager c)
    {

    }

    public void Unequip (InventoryManager c)
    {

    }

}
