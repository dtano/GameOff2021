using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitUI : MonoBehaviour
{
    [SerializeField] GameObject traitContainerParent;
    private TraitContainer[] containers;

    // Start is called before the first frame update
    void Awake()
    {
        if(traitContainerParent != null) 
            containers = traitContainerParent.GetComponentsInChildren<TraitContainer>();
            Clear();
    }

    public void DisplayTraits(List<Trait> traits)
    {
        Clear();
        for(int i = 0; i < traits.Count; i++){
            if(!containers[i].IsOccupied){
                containers[i].SetTraitDetails(traits[i]);
            }
        }

        // foreach(Trait trait in traits){
        //     TraitContainer container = FindEmptyContainer();
        //     if(container != null){
        //         container.SetTraitDetails(trait);
        //     }else{
        //         return;
        //     }
        // }
    }

    public void Hide()
    {
        // Clear();
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Clear()
    {
        foreach(TraitContainer container in containers) container.Clear();
    }

    private TraitContainer FindEmptyContainer()
    {
        foreach(TraitContainer container in containers){
            if(!container.IsOccupied){
                return container;
            }
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
