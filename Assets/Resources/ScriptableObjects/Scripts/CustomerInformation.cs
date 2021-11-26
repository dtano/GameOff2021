using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Customer/Customer information/Create new customer")]
public class CustomerInformation : ScriptableObject
{
    public string _name;
    public Sprite _sprite;

    [SerializeField] private Stat _endurance;
    [SerializeField] private Stat _survivability;
    [SerializeField] private Stat _intelligence;

    [SerializeField] private float _survivalProbability;
    [SerializeField] List<Trait> traits;

    public Stat Endurance { get => _endurance; set => _endurance = value; }
    public Stat Survivability { get => _survivability; set => _survivability = value; }
    public Stat Intelligence { get => _intelligence; set => _intelligence = value; }

    public float SurvivalProbability { get => _survivalProbability; set => _survivalProbability = value; }
    public List<Trait> Traits {get => traits;}

    public void AddTrait(Trait trait)
    {
        traits.Add(trait);
    }

    public bool RemoveTrait(Trait trait)
    {
        return traits.Remove(trait);
    }


}
