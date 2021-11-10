using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalKit : MonoBehaviour
{
    // Maybe instead of a regular list, I could use an InventoryObject s
    private List<Item> allItems;
    [SerializeField] int maxSlots;

    private CustomerData affectedCustData;
    
    
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
        affectedCustData.Endurance.AddModifier(item.GetItemObject().enduranceModifier);
        affectedCustData.Intelligence.AddModifier(item.GetItemObject().intelligenceModifier);
        affectedCustData.Survivability.AddModifier(item.GetItemObject().survivabilityModifier);
    }

    private void RemoveItemStatModifiers(Item item)
    {
        affectedCustData.Endurance.RemoveModifier(item.GetItemObject().enduranceModifier);
        affectedCustData.Intelligence.RemoveModifier(item.GetItemObject().intelligenceModifier);
        affectedCustData.Survivability.RemoveModifier(item.GetItemObject().survivabilityModifier);
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



}
