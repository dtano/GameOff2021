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
            AddStatModifiers(item);
        }else{
            Debug.Log("Over capacity");
        }
    }

    private void AddStatModifiers(Item item)
    {
        affectedCustData.Endurance.AddModifier(item.GetItemObject().enduranceModifier);
        affectedCustData.Intelligence.AddModifier(item.GetItemObject().intelligenceModifier);
        affectedCustData.Survivability.AddModifier(item.GetItemObject().survivabilityModifier);
    }

    public bool RemoveItem(Item item)
    {
        return allItems.Remove(item);
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
