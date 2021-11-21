using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalKit : MonoBehaviour
{
    // Maybe instead of a regular list, I could use an InventoryObject s
    private List<Item> allItems;
    [SerializeField] int maxSlots;
    [SerializeField] BackpackInventory inventory;

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

        if(!item.IsNullified()){
            affectedCustData.Endurance.AddModifier(item.EnduranceModifier);
            affectedCustData.Intelligence.AddModifier(item.IntelligenceModifier);
            affectedCustData.Survivability.AddModifier(item.SurvivabilityModifier);
        }


    }

    private void RemoveItemStatModifiers(Item item)
    {
        if(!item.IsNullified()){
            affectedCustData.Endurance.RemoveModifier(item.EnduranceModifier);
            affectedCustData.Intelligence.RemoveModifier(item.IntelligenceModifier);
            affectedCustData.Survivability.RemoveModifier(item.SurvivabilityModifier);
        }
    }

    public void Clear()
    {
        // The game controller needs to be notified to remove all trait bonuses and clear the trait delegates
        allItems.Clear();

        SetOnItemAdd(null);
    }

    public bool IsEligibleForCustomer()
    {
        return allItems.Count > 0;
    }

    public List<Item> GetAllItems()
    {
        return allItems;
    }

    public void SetAffectedCustData(CustomerData custData)
    {
        affectedCustData = custData;
    }


    // Delegate related functions
    public void Subscribe(OnItemAdd traitEffect)
    {
        OnItemAddFunction += traitEffect;
    }

    public void Unsubscribe(OnItemAdd traitEffect)
    {
        OnItemAddFunction -= traitEffect;
    }

    public void SetOnItemAdd(OnItemAdd addDelegate)
    {
        OnItemAddFunction = addDelegate;
    }



}
