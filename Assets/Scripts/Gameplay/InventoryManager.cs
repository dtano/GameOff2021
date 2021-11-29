using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    /*public CustomerStat Strength;
    public CustomerStat Agility;
    public CustomerStat Intelligence;
    public CustomerStat Vitality;*/

    [SerializeField] ShopInventory shopInventory;
    [SerializeField] BackpackInventory backpackInventory;
    [SerializeField] SurvivalKit survivalKit;
    /*[SerializeField] StatPanel statPanel;*/
    [SerializeField] ItemToolTip itemTooltip;
    [SerializeField] Image draggableItem;

    private ItemSlot dragItemSlot;


    public SurvivalKit SurvivalKit => survivalKit;
    private void OnValidate()
    {
        if (itemTooltip == null)
        {
            itemTooltip = FindObjectOfType<ItemToolTip>();
        }
    }

    private void Awake()
    {
        //stat panel setup
        //statPanel.SetStats(Strength, Agility, Itelligence, Vitality);
        //statPanel.UpdateStatValue();

        // Setup Events
        //Right Click
        shopInventory.OnRightClickEvent += Equip;
        backpackInventory.OnRightClickEvent += Unequip;

        //Pointer Enter
        shopInventory.OnPointerEnterEvent += ShowTooltip;
        backpackInventory.OnPointerEnterEvent += ShowTooltip;

        //Pointer Exit
        shopInventory.OnPointerExitEvent += HideTooltip;
        backpackInventory.OnPointerExitEvent += HideTooltip;

        //Begin Drag
        shopInventory.OnBeginDragEvent += BeginDrag;
        /*backpackInventory.OnBeginDragEvent += BeginDrag;*/

        //End Drag
        shopInventory.OnEndDragEvent += EndDrag;
        /*backpackInventory.OnEndDragEvent += EndDrag;*/

        //Drag
        shopInventory.OnDragEvent += Drag;
        /*backpackInventory.OnDragEvent += Drag;*/

        //Drop
        shopInventory.OnDropEvent += Drop;
        backpackInventory.OnDropEvent += Drop;

    }

    private void Equip(ItemSlot itemSlot)
    {
        //EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        Item item = itemSlot.GetItem();
        if (item != null)
        {
            Equip(item);
        }
    }

    private void Unequip(ItemSlot itemSlot)
    {
        //EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        Item item = itemSlot.GetItem();
        // if (equippableItem != null)
        // {
        //     Unequip(equippableItem);
        // }

        if (item != null)
        {
            Unequip(item);
        }
    }

    // public void Equip(EquippableItem item)
    // {
    //     if (shopInventory.RemoveItem(item))
    //     {
    //         EquippableItem previousItem;
    //         if (backpackInventory.AddItem(item, out previousItem))
    //         {
    //             if (previousItem != null)
    //             {
    //                 shopInventory.AddItem(previousItem);
    //                 previousItem.Unequip(this);
    //                 /*statPanel.UpdateStatValues();*/
    //             }
    //             item.Equip(this);
    //             /*statPanel.UpdateStatValues();*/
    //         }
    //         else
    //         {
    //             shopInventory.AddItem(item);
    //         }
    //     }
    // }

    public void Equip(Item item)
    {
        Debug.Log("Calling equip");
        if (shopInventory.RemoveItem(item))
        {
            Item previousItem;
            if (backpackInventory.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    shopInventory.AddItem(previousItem);
                    previousItem.Unequip(this);
                }
                item.Equip(this);
            }
            else
            {
                shopInventory.AddItem(item);
            }
        }
    }

    /*    public void Unequip(EquippableItem item)
        {
            if (!shopInventory.IsFull() && backpackInventory.RemoveItem(item))
            {
                item.Unequip(this);
                *//*statPanel.UpdateStatValues();*//*
                shopInventory.AddItem(item);
            }
        }*/


    public void Unequip(Item item)
    {
        Debug.Log("calling unequip");
        /*!shopInventory.IsFull() &&*/
        if (backpackInventory.RemoveItem(item))
        {
            Debug.Log("Returning item");

            Debug.Log(item.ID);
            item.Unequip(this);
            shopInventory.AddItem(item);

        }
    }

    private void ShowTooltip(ItemSlot itemSlot)
    {
        Item item = itemSlot.GetItem();
        if (item != null)
        {

            itemTooltip.ShowTooltip(item);
        }
    }
    private void HideTooltip(ItemSlot itemSlot)
    {
        itemTooltip.HideToolTip();
    }

    private void BeginDrag(ItemSlot itemSlot)
    {
        // if (itemSlot.Item != null)
        // {

        //     dragItemSlot = itemSlot;
        //     draggableItem.sprite = itemSlot.Item.Icon;
        //     draggableItem.transform.position = Input.mousePosition;
        //     draggableItem.enabled = true;
        // }

        if (itemSlot.GetItem() != null)
        {
            dragItemSlot = itemSlot;
            draggableItem.sprite = itemSlot.GetItem().ItemObject.sprite;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }
    private void EndDrag(ItemSlot itemSlot)
    {
        dragItemSlot = null;
        draggableItem.enabled = false;
    }

    private void Drag(ItemSlot itemSlot)
    {
        if (draggableItem.enabled)
        {
            draggableItem.transform.position = Input.mousePosition;
        }
    }

    private void Drop(ItemSlot dropItemSlot)
    {
        Debug.Log("Dropping");
        if (dragItemSlot == null || dragItemSlot == dropItemSlot) return;

        /*Item dragItem = dragItemSlot.GetItem();*/
        /*Item dropItemMono = dropItemSlot.GetItem();*/
        /*Item draggedItemMono = dragItemSlot.GetItem();*/

        /*if (draggedItem != null) draggedItem.Equip(this);
        if (dropItem != null) dropItem.Unequip(this);*/

        Item dragItem = dragItemSlot.GetItem();
        Item dropItem = dropItemSlot.GetItem();

        if (dropItemSlot.IsOccupied() && dropItemSlot.CanAddStack(dragItemSlot.GetItem()))
        {
            if (dragItem != null) dragItem.Unequip(this);
            if (dropItem != null) dropItem.Equip(this);

            AddStacks(dropItemSlot);
            Debug.Log("adding stacks");
        }
        else
        {
            if (dragItemSlot is BackpackSlot)
            {
                if (dragItem != null) dragItem.Unequip(this);
                if (dropItem != null) dropItem.Equip(this);

                if (dropItemSlot.GetItem() != null && !(dropItemSlot is BackpackSlot) && dragItemSlot.GetItem().ID == dropItemSlot.GetItem().ID)
                {
                    Debug.Log("Moving one item from backpack inventory back to stacked item of the same type");
                    dropItemSlot.Amount++;
                    dragItemSlot.Amount = 0;
                }

                else if (dropItemSlot.GetItem() == null && !(dropItemSlot is BackpackSlot))
                {
                    Debug.Log("Moving one item from backpack inventory back to empty slot");
                    ExchangeItems(dropItemSlot);
                }

                else if (dragItemSlot is BackpackSlot && dropItemSlot is BackpackSlot)
                {
                    // Do nothing when dropping items within the bag
                }



            }

            else if (dropItemSlot is BackpackSlot)
            {
                Debug.Log("Entering Backpack Slot");
                if (dragItem != null) dragItem.Equip(this);
                if (dropItem != null) dropItem.Unequip(this);

                //Moving one item (from a stack) in shop inventory to backpack inventory
                if (dragItemSlot.Amount == 1)
                {
                    
                    dropItemSlot.SetItem(dragItemSlot.GetItem().GetCopy());
                    dropItemSlot.Amount = 1;
                    dragItemSlot.Amount--;
                    Debug.Log("swapping item from shop to bag inventory when amount = 1");
                }
                else if (dropItemSlot.IsOccupied())
                {
                    // Do not swap if the drop slot is occupied
                }
                else
                {
                    Debug.Log("Moving one item (from a stack) in shop inventory to backpack inventory");
               
                    dropItemSlot.SetItem(dragItemSlot.GetItem().GetCopy());
                    dropItemSlot.Amount = 1;
                    dragItemSlot.Amount--;
                }


            }
            else
            {
                ExchangeItems(dropItemSlot);
                Debug.Log("swapping items");
            }

        }

    }

    private void ExchangeItems(ItemSlot dropItemSlot)
    {

        Item draggedItem = dragItemSlot.GetItem();
        int draggedItemAmount = dragItemSlot.Amount;
        

        dragItemSlot.SetItem(dropItemSlot.GetItem());
        dragItemSlot.Amount = dropItemSlot.Amount;

        dropItemSlot.SetItem(draggedItem);
        dropItemSlot.Amount = draggedItemAmount;

        /*Debug.Log("draggeditem:" + dragItemSlot.GetItem().ItemObject.itemName + " " + "droppeditem" + dropItemSlot.GetItem().ItemObject.itemName);*/
    }

    private void AddStacks(ItemSlot dropItemSlot)
    {
        int numAddableStacks = dropItemSlot.GetItem().ItemObject.MaximumStacks - dropItemSlot.Amount;
        int stacksToAdd = Mathf.Min(numAddableStacks, dragItemSlot.Amount);

        dropItemSlot.Amount += stacksToAdd;
        dragItemSlot.Amount -= stacksToAdd;
       /* if (dragItemSlot.Amount == 0)
        {
            dragItemSlot.SetItem(null);
        }*/
    }
}


