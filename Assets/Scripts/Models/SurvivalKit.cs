using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalKit : MonoBehaviour
{
    // Maybe instead of a regular list, I could use an InventoryObject s
    [SerializeField] List<Item> _allItems = new List<Item>();
    [SerializeField] int maxSlots;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Duplicates allowed
    public bool AddItem(Item item)
    {
        if(_allItems.Count < maxSlots){
            _allItems.Add(item);
            return true;
        }
        
        return false;
    }

    public bool RemoveItem(Item item)
    {
        return _allItems.Remove(item);
    }

    public void Clear()
    {
        _allItems.Clear();
    }
}
