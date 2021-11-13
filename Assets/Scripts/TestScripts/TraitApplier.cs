using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitApplier : MonoBehaviour
{
    [SerializeField] List<Trait> traits = new List<Trait>();
    [SerializeField] Customer customer;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(Trait trait in traits){
            trait.Apply(customer);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearTraitBonuses()
    {
        
    }
}
