using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TraitType {
    Boost,
    Nullify,
    Reduce
}

[CreateAssetMenu(menuName = "Traits/New Trait")]
public class TraitObject : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private TraitType _type;

    [TextArea]
    public string _description;
    
    [SerializeField] private StatModifier enduranceModifier;
    [SerializeField] private StatModifier intelligenceModifier;
    [SerializeField] private StatModifier survivabilityModifier;

    public StatModifier EnduranceModifier { get => enduranceModifier; }
    public StatModifier IntelligenceModifier { get => intelligenceModifier; }
    public StatModifier SurvivabilityModifier { get => survivabilityModifier; }
    
    public string Title { get => _title; }
    public TraitType Type { get => _type; }

    public void Apply(Item item)
    {
        Debug.Log("Apply trait to item");
    }



}
