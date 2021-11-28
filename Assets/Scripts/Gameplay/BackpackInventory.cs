using System;
using UnityEngine;
using UnityEngine.UI;

public class BackpackInventory : MonoBehaviour
{
    [SerializeField] Transform backpackSlotParent;
    [SerializeField] BackpackSlot[] backpackSlots;
    [SerializeField] GameObject survivalKitSprite;

    private Animator survivalKitAnimator;

    public event Action<ItemSlot> OnPointerEnterEvent;
    public event Action<ItemSlot> OnPointerExitEvent;
    public event Action<ItemSlot> OnRightClickEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    

    public BackpackSlot[] BackpackSlots => backpackSlots;

    private void Start()
    {
        //backpackSlots = backpackSlotParent.GetComponentsInChildren<BackpackSlot>();
        foreach(BackpackSlot slot in backpackSlots){
            SetSlotEvents(slot);
        }

        if(survivalKitSprite != null) survivalKitAnimator = survivalKitSprite.GetComponent<Animator>();
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
        backpackSlots = backpackSlotParent.GetComponentsInChildren<BackpackSlot>();
    }

    public bool AddItem(Item item, out Item previousItem)
    {
        for (int i = 0; i < backpackSlots.Length; i++)
        {
            /*Debug.Log(backpackSlots[i].GetItem());*/

            if (backpackSlots[i].GetItem() && i == backpackSlots.Length - 1)
            {

                previousItem = backpackSlots[i].GetItem();
                backpackSlots[i].SetItem(item.GetCopy());
                return true;
            }
            if (backpackSlots[i].GetItem())
            {
                continue;
            }
            else
            {
                backpackSlots[i].SetItem(item.GetCopy());
                previousItem = null;
                return true;
            }
            
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(Item item)
    {
        for(int i = 0; i < backpackSlots.Length; i++){
            if(backpackSlots[i].GetItem() == item){
                backpackSlots[i].SetItem(null);
                Debug.Log($"{item.name} removed successfully");
                return true;
            }
        }
        return false;
    }

    public void Clear()
    {
        foreach(BackpackSlot slot in backpackSlots)
        {
            slot.SetItem(null);
        }
    }

    public bool IsFull()
    {
        foreach(BackpackSlot slot in backpackSlots){
            if(slot.GetItem() == null){
                return false;
            }
        }
        return true;
    }

    public void HideSlots()
    {
        foreach(BackpackSlot slot in backpackSlots){
            slot.gameObject.SetActive(false);
        }
    }

    public void ShowSlots()
    {
        foreach(BackpackSlot slot in backpackSlots){
            slot.gameObject.SetActive(true);
        }
    }

    public void ServeBag()
    {
        survivalKitAnimator?.SetTrigger("ServeBag");
    }

    public void GetNewBag()
    {
        survivalKitAnimator?.SetTrigger("GetNewBag");
    }

}
