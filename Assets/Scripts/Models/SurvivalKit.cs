using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalKit : MonoBehaviour
{
    // Maybe instead of a regular list, I could use an InventoryObject s
    private List<Item> allItems;
    [SerializeField] int maxSlots;

    private CustomerData affectedCustData;

    public delegate void OnItemAdd(Item item);
    private OnItemAdd OnItemAddFunction;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        allItems = new List<Item>(maxSlots);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Duplicates allowed
    public void AddItem(Item item)
    {
        if(allItems.Count < maxSlots){
            allItems.Add(item);
            if(OnItemAddFunction != null){
                OnItemAddFunction(item);
                Debug.Log("Function called when adding");
            }
            AddItemStatModifiers(item);
        }else{
            Debug.Log("Over capacity");
        }
    }

    public void RemoveItem(Item item)
    {
        bool removeSuccess = allItems.Remove(item);
        if(removeSuccess){
            RemoveItemStatModifiers(item);
        }
    }

    private void AddItemStatModifiers(Item item)
    {
        // Not great, as removal will mess up the calculations
        // Before adding, then apply any traits
        // bool affectedByTraits = false;
        // List<Trait> traits = affectedCustData.Traits;
        // if(traits.Count > 0){
        //     foreach(Trait trait in traits){
        //         trait.Apply(item);
        //     }
        //     affectedByTraits = true;
        // }
        
        // Debug.Log(item.EnduranceModifier.Value);
        
        Debug.Log(affectedCustData);
        affectedCustData.Endurance.AddModifier(item.EnduranceModifier);
        affectedCustData.Intelligence.AddModifier(item.IntelligenceModifier);
        affectedCustData.Survivability.AddModifier(item.SurvivabilityModifier);

        // if(affectedByTraits){
        //     item.ResetModifiers();
        // }

    }

    private void RemoveItemStatModifiers(Item item)
    {
        affectedCustData.Endurance.RemoveModifier(item.EnduranceModifier);
        affectedCustData.Intelligence.RemoveModifier(item.IntelligenceModifier);
        affectedCustData.Survivability.RemoveModifier(item.SurvivabilityModifier);
    }

    public void Clear()
    {
        allItems.Clear();
    }

    public List<Item> GetAllItems()
    {
        return allItems;
    }

    public void SetAffectedCustData(CustomerData custData)
    {
        affectedCustData = custData;
    }

    public void SetOnItemAdd(OnItemAdd addDelegate)
    {
        Debug.Log("Set on item add function");
        OnItemAddFunction = addDelegate;
    }



}
