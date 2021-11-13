using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TraitType {
    Boost,
    Nullify,
    Reduce
}

public abstract class Trait : ScriptableObject, ITrait
{
    [SerializeField] private string _name;
    [TextArea]
    [SerializeField] private string _description;


    public string Name => _name;

    public string Description { get => _description; set => _description = value; }

    //public abstract void Apply(Item item);

    public virtual void Apply(Customer customer)
    {
         // Get customer's survival kit
        SurvivalKit survivalKit = customer.GetSurvivalKit();

        survivalKit.SetOnItemAdd(TraitEffect);
        Debug.Log("Applied trait");
    }

    protected abstract void TraitEffect(Item item);

    // TraitType traitType = _type;
    //     switch(traitType){
    //         case TraitType.Boost:
    //             item.EnduranceModifier.Value += enduranceModifier.Value;
    //             Debug.Log($"Added {enduranceModifier.Value} to {enduranceModifier.Value}");
    //             break;
    //         case TraitType.Nullify:
    //             break;
    //         case TraitType.Reduce:
    //             break;
    //     }



}
