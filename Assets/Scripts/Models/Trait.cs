using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Probably should be a ScriptableObject
[System.Serializable]
public class Trait
{
    [SerializeField] TraitObject _traitDetails;
    
    public Trait(TraitObject traitDetails)
    {
        _traitDetails = traitDetails;
    }

    public void Apply(Item item)
    {
        TraitType traitType = _traitDetails.Type;
        switch(traitType){
            case TraitType.Boost:
                item.EnduranceModifier.Value += _traitDetails.EnduranceModifier.Value;
                Debug.Log($"Added {_traitDetails.EnduranceModifier.Value} to {item.EnduranceModifier.Value}");
                break;
            case TraitType.Nullify:
                break;
            case TraitType.Reduce:
                break;
        }
    }



    public TraitObject TraitDetails { get => _traitDetails;}
}
