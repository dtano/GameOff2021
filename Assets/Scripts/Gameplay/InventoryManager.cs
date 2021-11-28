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
        //backpackInventory.OnBeginDragEvent += BeginDrag;

        //End Drag
        shopInventory.OnEndDragEvent += EndDrag;
        //backpackInventory.OnEndDragEvent += EndDrag;

        //Drag
        shopInventory.OnDragEvent += Drag;
        //backpackInventory.OnDragEvent += Drag;

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
        Item equippableItem = itemSlot.GetItem();
        // if (equippableItem != null)
        // {
        //     Unequip(equippableItem);
        // }

        if(equippableItem != null)
        {
            Unequip(equippableItem);
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
            Debug.Log("Shop inventory failed to remove");
            Item previousItem;
            if (backpackInventory.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    shopInventory.AddItem(previousItem);
                    previousItem.Unequip(this);
                    /*statPanel.UpdateStatValues();*/
                }
                item.Equip(this);
                /*statPanel.UpdateStatValues();*/
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
        if(!shopInventory.IsFull() && backpackInventory.RemoveItem(item)){
            Debug.Log("Returning item");
            item.Unequip(this);

            shopInventory.AddItem(item);
        }
    }

     private void ShowTooltip(ItemSlot itemSlot)
     {
        Debug.Log("calling tooltips");
        Item item = itemSlot.GetItem();
/*        ItemObject item = itemSlot.GetItem();
*/        if (item != null)
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
        if (dragItemSlot == null) return;

        //updates values of stats
        //statPanel.UpdateStatValues;
        if (dropItemSlot.CanAddStack(dragItemSlot.Item))
        {
            AddStacks(dropItemSlot);
        }
        else
        {
            SwapItems(dropItemSlot);
        }
    }

    private void SwapItems(ItemSlot dropItemSlot)
    {
        ItemObject dragItem = dragItemSlot.Item as ItemObject;
        ItemObject dropItem = dropItemSlot.Item as ItemObject;
        Item dropItemMono = dropItemSlot.GetItem();

        ItemObject draggedItem = dragItemSlot.Item;
        Item draggedItemMono = dragItemSlot.GetItem();
        int draggedItemAmount = dragItemSlot.Amount;

        //When dragging from the backpack
        if (dragItemSlot is BackpackSlot)
        {
            if(draggedItemMono != null) draggedItemMono.Equip(this);
            if(dropItemMono != null) dropItemMono.Unequip(this);


            if (dropItemSlot.CanAddStack(dragItemSlot.Item))
            {
                AddStacks(dropItemSlot);
            }

            else if(dropItemSlot is BackpackSlot)
            {
                // Disable in-place swapping for backpack
            }
            
            else if (dropItemSlot.GetItem() != null && dropItemSlot.GetItem().ID != dragItemSlot.GetItem().ID && dropItemSlot.Amount != 1)
            {
                // Add stacked shop items to the backpack and add backpack item back into shop
                shopInventory.AddItem(draggedItem);
                dropItemSlot.Amount--;
                dragItemSlot.Item = dropItemSlot.Item;
                dropItemSlot.Amount = 1;

            }
            else if (dropItemSlot.GetItem() != null && dropItemSlot.GetItem().ID == dragItemSlot.GetItem().ID)
            {
                //Do nothing, Items are the same and you are trying to drag and drop a stack
            }
            else
            {
                ExchangeItems(dropItemSlot, draggedItemMono, draggedItemAmount);
            }
        }

        //When dropping into the backpack
        else if (dropItemSlot is BackpackSlot)
        {

            if(draggedItemMono != null) draggedItemMono.Equip(this);
            if(dropItemMono != null) dropItemMono.Unequip(this);
            

            //If items are the same
            if (dropItemSlot.GetItem() != null && dropItemSlot.GetItem().ID != dragItemSlot.GetItem().ID && dragItemSlot.Amount == 1)
            {
                Debug.Log("Calling exchange item when items are the same");
                ExchangeItems(dropItemSlot, draggedItemMono, draggedItemAmount);
            }
            // dropItemSlot.Item != null && dropItemSlot.Item.ID != dragItemSlot.Item.ID && dragItemSlot.Amount != 1
            else if (dropItemSlot.GetItem() != null && dropItemSlot.GetItem().ID != dragItemSlot.GetItem().ID && dragItemSlot.Amount != 1)
            {
                // Add stacked shop items to the backpack and add backpack item back into shop
                shopInventory.AddItem(dropItemSlot.Item);
                dragItemSlot.Amount--;
                dropItemSlot.Item = draggedItem;
                dropItemSlot.Amount = 1;

            }
            // dropItemSlot.Item != null && dropItemSlot.Item.ID == dragItemSlot.Item.ID
            else if (dropItemSlot.GetItem() != null && dropItemSlot.GetItem().ID == dragItemSlot.GetItem().ID)
            {
                //Do nothing, Items are the same and you are trying to drag and drop a stack
            }

            // Dragging stacked items into backpack
            else
            {
                Debug.Log("Drag stacked items into backpack");
                dragItemSlot.Amount--;
                //dropItemSlot.Item = draggedItem;
                dropItemSlot.SetItem(draggedItemMono);
                dropItemSlot.Amount = 1;
            }

        }

        else
        {
            Debug.Log("Calling exchange item from else leg");
            ExchangeItems(dropItemSlot, draggedItemMono, draggedItemAmount);
        }
    }

    //Swap items 1 for 1
    private void ExchangeItems(ItemSlot dropItemSlot, Item draggedItem, int draggedItemAmount)
    {
        Debug.Log("Drop exchange");

        dragItemSlot.SetItem(dropItemSlot.GetItem());
        dragItemSlot.Amount = dropItemSlot.Amount;

        dropItemSlot.SetItem(draggedItem);
        dropItemSlot.Amount = draggedItemAmount;
    }

    //Stacks items
    private void AddStacks(ItemSlot dropItemSlot)
    {
        //int numAddableStacks = dropItemSlot.Item.MaximumStacks - dropItemSlot.Amount;

        int numAddableStacks = dropItemSlot.GetItem().ItemObject.MaximumStacks - dropItemSlot.Amount;
        int stacksToAdd = Mathf.Min(numAddableStacks, dragItemSlot.Amount);

        dropItemSlot.Amount += stacksToAdd;
        dragItemSlot.Amount -= stacksToAdd;
    }
}


