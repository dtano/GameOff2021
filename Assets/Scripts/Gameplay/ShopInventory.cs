using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour
{
    //[SerializeField] List<ItemSO> startingItems;
    
    
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
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            itemSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            itemSlots[i].OnRightClickEvent += OnRightClickEvent;
            itemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            itemSlots[i].OnEndDragEvent += OnEndDragEvent;
            itemSlots[i].OnDragEvent += OnDragEvent;
            itemSlots[i].OnDropEvent += OnDropEvent;
        }

        SetStartingItems();
    }

    private void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
    }


    private void SetStartingItems()
    {
        // int i = 0;
        // for (; i < startingItems.Count && i < itemSlots.Length; i++)
        // {
        //     itemSlots[i].Item = startingItems[i].GetCopy();
        //     itemSlots[i].Amount = 1;
        // }

        // for (; i < itemSlots.Length; i++)
        // {
        //     itemSlots[i].Item = null;
        //     itemSlots[i].Amount = 0;
        // }

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

    public bool AddItem(ItemSO item)
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
            if (itemSlots[i].GetItem().ItemObject == null || (itemSlots[i].GetItem().ID == item.ID && itemSlots[i].Amount < item.ItemObject.MaximumStacks))
            {
                itemSlots[i].SetItem(item);
                itemSlots[i].Amount++;
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(ItemSO item)
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

    // public ItemSO RemoveItem(string itemID)
    // {
    //     for (int i = 0; i < itemSlots.Length; i++)
    //     {
    //         ItemSO item = itemSlots[i].Item;
    //         if (item != null && item.ID == itemID)
    //         {
    //             itemSlots[i].Amount--;
    //             if (itemSlots[i].Amount == 0)
    //             {
    //                 itemSlots[i].Item = null;
    //             }
    //             return item;
    //         }
    //     }
    //     return null;
    // }

    public bool RemoveItem(Item item)
    {
        for(int i = 0; i < itemSlots.Length; i++){
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

    // public Item RemoveItem(string itemID)
    // {
    //     for (int i = 0; i < itemSlots.Length; i++)
    //     {
    //         Item item = itemSlots[i].GetItem();
    //         if (item != null && item.ID == itemID)
    //         {
    //             itemSlots[i].Amount--;
    //             if (itemSlots[i].Amount == 0)
    //             {
    //                 itemSlots[i].Item = null;
    //             }
    //             return item;
    //         }
    //     }
    //     return null;
    // }

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
