using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDataComponent : MonoBehaviour
{
    [SerializeField] string _name;
    
    // Customer's counting stats
    // POSSIBLE IMPROVEMENT: Make a CustomerStat class and make child classes that represent stats below
    [SerializeField] int _strength;
    [SerializeField] int _vitality;
    [SerializeField] int _perception;
    [SerializeField] int _intelligence;

    List<Trait> traits = new List<Trait>();

    public int Strength { get => _strength; set => _strength = value; }
    public int Vitality { get => _vitality; set => _vitality = value; }
    public int Perception { get => _perception; set => _perception = value; }
    public int Intelligence { get => _intelligence; set => _intelligence = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddTrait(Trait trait)
    {
        if(traits.Contains(trait)){
            return false;
        }

        traits.Add(trait);
        return true;
    }

    public bool RemoveTrait(Trait trait)
    {
        return traits.Remove(trait);
    }
}
