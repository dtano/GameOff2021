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

    public virtual void Apply(Customer customer)
    {
        // Add trait effect to the survival kit's delegate function
        customer.SurvivalKit.Subscribe(TraitEffect);
        
        Debug.Log($"Applied trait {_name}");
    }

    protected abstract void TraitEffect(Item item);

}
