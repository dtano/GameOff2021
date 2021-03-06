using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitDistributor : MonoBehaviour
{
    [SerializeField] List<Trait> intelligenceTraits;
    [SerializeField] List<Trait> survivabilityTraits;
    [SerializeField] List<Trait> enduranceTraits;

    private List<List<Trait>> allTraitsCombined;
    
    // Start is called before the first frame update
    void Awake()
    {
        allTraitsCombined = new List<List<Trait>>{intelligenceTraits, survivabilityTraits, enduranceTraits};
    }

    public void AssignTraitsToCustomer(CustomerData chosenCustomer)
    {   
        //Pick random amount of traits for a customer (Might need weights for the amounts)
        int numTraits = Random.Range(1,3);
        List<List<Trait>> traitPools = new List<List<Trait>>(allTraitsCombined);

        // 50/50 chance for all types of traits
        for(int i = 0; i < numTraits; i++){
            int randomTraitPoolIndex = Random.Range(0, traitPools.Count);
            List<Trait> traitPool = traitPools[randomTraitPoolIndex];
            
            
            
            Trait chosenTrait = traitPool[Random.Range(0, traitPool.Count)];
            chosenCustomer.AddTrait(chosenTrait);

            traitPools.Remove(traitPool);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
