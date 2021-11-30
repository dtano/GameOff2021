using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{

    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI amountText;
    /*[SerializeField] ItemToolTip tooltip;*/

    public event Action<ItemSlot> OnPointerEnterEvent;
    public event Action<ItemSlot> OnPointerExitEvent;
    public event Action<ItemSlot> OnRightClickEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    private Color normalColor = Color.white;
    private Color disabledColor = new Color(1, 1, 1, 0);

    private Item itemMono;
    // Item slot has to hold an item object 
    /*private Item _item;*/
   /* public Item Item
    {
        get {
            return _item; }
        set
        {
            
            _item = value;

            if (_item == null)
            {
                image.color = disabledColor;
            }
            else
            {
                image.sprite = _item.ItemObject.sprite;
                image.color = normalColor;
            }
        }
    }*/

    private int _amount;
    public int Amount
    {
        get { return _amount; }
        set
        {

            _amount = value;
            if (_amount < 0) _amount = 0;
            if (_amount == 0) {
                //setting empty slot to null
                SetItem(null);
            }

            if (amountText != null)
            {
                amountText.enabled = itemMono != null && _amount > 0;
                if (amountText.enabled)
                {
                    amountText.text = _amount.ToString();
                }
            }
            
        }
    }

    void Awake()
    {
        itemMono = GetComponent<Item>();
    }

    protected virtual void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();

        if (amountText == null)
            amountText = GetComponentInChildren<TextMeshProUGUI>();

        /*if (tooltip == null)
            tooltip = FindObjectOfType<ItemToolTip>();*/
    }

    //check if this is required
 /*   public virtual bool CanReceiveItem(Item item)
    {
        return true;
    }*/

    public Item GetItem()
    {
        return itemMono;
    }

    public void SetItemObject(ItemObject itemObject)
    {
        itemMono.ItemObject = itemObject;

        if (itemMono.ItemObject == null)
        {
            image.color = disabledColor;
        }
        else
        {
            Debug.Log("itemMono not null, so color needs to be changed");
            image.sprite = itemMono.ItemObject.sprite;
            image.color = normalColor;
        }
    }

    public void SetItem(Item item)
    {
        itemMono = item;

        if(item == null)
        {
            image.color = disabledColor;
        }
        else
        {
/*            itemMono = item;*/
            //itemMono.ItemObject = item.ItemObject;
            Debug.Log("itemMono not null, so color needs to be changed");
            image.sprite = item.ItemObject.sprite;
            image.color = normalColor;
        }
    }
/*
    public virtual bool CanAddStack(ItemSO item, int amount = 1)
    {
        return Item != null && Item.ID == item.ID && Amount + amount <= item.MaximumStacks;
    }*/

    public virtual bool CanAddStack(Item item, int amount = 1)
    {
        return itemMono.ItemObject != null && itemMono.ID == item.ID && Amount + amount <= item.ItemObject.MaximumStacks;
    }

    public bool IsOccupied()
    {
        return itemMono != null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (OnRightClickEvent != null)
            {
                OnRightClickEvent(this);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (OnPointerEnterEvent != null)
        {
            OnPointerEnterEvent(this);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (OnPointerExitEvent != null)
        {
            OnPointerExitEvent(this);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragEvent != null)
        {
            OnBeginDragEvent(this);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragEvent != null)
        {
            OnEndDragEvent(this);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragEvent != null)
        {
            OnDragEvent(this);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropEvent != null)
        {
            OnDropEvent(this);
        }
    }
}

