using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour
{   
    [SerializeField] List<ItemObject> startingItemObjects;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;

    public event Action<ItemSlot> OnPointerEnterEvent;
    public event Action<ItemSlot> OnPointerExitEvent;
    public event Action<ItemSlot> OnRightClickEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    

    private void Start()
    {
        foreach(ItemSlot slot in itemSlots){
            SetSlotEvents(slot);
        }

        PopulateStartingItems();
        SetStartingItems();
    }

    private void SetSlotEvents(ItemSlot slot)
    {
        slot.OnPointerEnterEvent += OnPointerEnterEvent;
        slot.OnPointerExitEvent += OnPointerExitEvent;
        slot.OnRightClickEvent += OnRightClickEvent;
        slot.OnBeginDragEvent += OnBeginDragEvent;
        slot.OnEndDragEvent += OnEndDragEvent;
        slot.OnDragEvent += OnDragEvent;
        slot.OnDropEvent += OnDropEvent;
    }

    private void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
    }

    private void PopulateStartingItems()
    {
        startingItemObjects = new List<ItemObject>(Resources.LoadAll<ItemObject>("ScriptableObjects/Objects/Items"));
    }


    private void SetStartingItems()
    {
        int j = 0;
        for(; j < startingItemObjects.Count && j < itemSlots.Length; j++)
        {
            itemSlots[j].SetItemObject(startingItemObjects[j].GetCopy());
            itemSlots[j].Amount = 1;
        }

        for(; j < itemSlots.Length; j++)
        {
            itemSlots[j].SetItem(null);
            itemSlots[j].Amount = 0;
        }
    }

    public bool AddItem(ItemObject item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null || (itemSlots[i].Item.ID == item.ID && itemSlots[i].Amount < item.MaximumStacks))
            {
                itemSlots[i].Item = item;
                itemSlots[i].Amount++;
                return true;
            }
        }
        return false;
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].GetItem() == null || (itemSlots[i].GetItem().ID == item.ID && itemSlots[i].Amount < item.ItemObject.MaximumStacks))
            {
                itemSlots[i].SetItem(item);
                itemSlots[i].Amount++;
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(ItemObject item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                itemSlots[i].Amount--;
                if (itemSlots[i].Amount == 0)
                {
                    itemSlots[i].Item = null;
                } 
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(Item item)
    {
        for(int i = 0; i < itemSlots.Length; i++){
            if (itemSlots[i].GetItem() == item)
            {
                itemSlots[i].Amount--;
                if (itemSlots[i].Amount == 0)
                {
                    itemSlots[i].SetItem(null);
                } 
                return true;
            }
        }
        return false;
    }

    public void ResetItemEffects()
    {
        foreach(ItemSlot slot in itemSlots){
            Item itemInSlot = slot.GetItem();
            itemInSlot?.Reset();
            Debug.Log("Resetting item in slot");
        }
    }

    public bool IsFull()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                return false;
            }
        }
        return true;
    }

    public int ItemCount(string itemID)
    {
        int number = 0;

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item.ID == itemID)
            {
                number++;
            }
        }
        return number;
    }

}
