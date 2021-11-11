using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/New Item")]
public class ItemObject : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
    [TextArea]
    public string description;

    public StatModifier enduranceModifier;
    public StatModifier intelligenceModifier;
    public StatModifier survivabilityModifier;

    // Might need a list of traits that it is affected by
    // public List<Trait> traitsAffectedBy;
}
