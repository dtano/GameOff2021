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
    /*[SerializeField] StatPanel statPanel;
    [SerializeField] ItemTooltip itemTooltip;*/
    [SerializeField] Image draggableItem;

    private ItemSlot dragItemSlot;

    /*    private void OnValidate()
        {
            if (itemTooltip == null)
            {
                itemTooltip = FindObjectOfType<ItemTooltip>();
            }
        }*/

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
        /*shopInventory.OnPointerEnterEvent += ShowTooltip;
        backpackInventory.OnPointerEnterEvent += ShowTooltip;*/

        //Pointer Exit
        /*shopInventory.OnPointerExitEvent += HideTooltip;
        backpackInventory.OnPointerExitEvent += HideTooltip;*/

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
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            Equip(equippableItem);
        }
    }

    private void Unequip(ItemSlot itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            Unequip(equippableItem);
        }
    }

    public void Equip(EquippableItem item)
    {
        if (shopInventory.RemoveItem(item))
        {
            EquippableItem previousItem;
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

    public void Unequip(EquippableItem item)
    {
        if (!shopInventory.IsFull() && backpackInventory.RemoveItem(item))
        {
            item.Unequip(this);
            /*statPanel.UpdateStatValues();*/
            shopInventory.AddItem(item);
        }
    }

    /* private void ShowTooltip(ItemSlot itemSlot)
     {
         EquipableItem equippableItem = itemSlot.Item as equippableItem;
         if (equippableItem != null)
         {
             itemTooltip.ShowTooltip(equippableItem);
         }
     }
     private void HideTooltip(ItemSlot itemSlot)
     {
         itemTooltip.HideTooltip()
     }*/

    private void BeginDrag(ItemSlot itemSlot)
    {
        if (itemSlot.Item != null)
        {

            dragItemSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.Icon;
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

    private void Drop(SurvivalKit survivalKit)
    {
        
    }

    private void SwapItems(ItemSlot dropItemSlot)
    {
        EquippableItem dragItem = dragItemSlot.Item as EquippableItem;
        EquippableItem dropItem = dropItemSlot.Item as EquippableItem;

        ItemSO draggedItem = dragItemSlot.Item;
        int draggedItemAmount = dragItemSlot.Amount;

        //When dragging from the backpack
        if (dragItemSlot is BackpackSlot)
        {
            if (dragItem != null) dragItem.Unequip(this);
            if (dropItem != null) dropItem.Equip(this);

            if (dropItemSlot.CanAddStack(dragItemSlot.Item))
            {
                AddStacks(dropItemSlot);
            }

            else if (dropItemSlot.Item != null && dropItemSlot.Item.ID != dragItemSlot.Item.ID && dropItemSlot.Amount != 1)
            {
                // Add stacked shop items to the backpack and add backpack item back into shop
                shopInventory.AddItem(draggedItem);
                dropItemSlot.Amount--;
                dragItemSlot.Item = dropItemSlot.Item;
                dropItemSlot.Amount = 1;

            }
            else if (dropItemSlot.Item != null && dropItemSlot.Item.ID == dragItemSlot.Item.ID)
            {
                //Do nothing, Items are the same and you are trying to drag and drop a stack
            }
            else
            {
                ExchangeItems(dropItemSlot, draggedItem, draggedItemAmount);
            }
        }

        //When dropping into the backpack
        else if (dropItemSlot is BackpackSlot)
        {
            if (dragItem != null) dragItem.Equip(this);
            if (dropItem != null) dropItem.Unequip(this);

            //If items are the same
            if (dropItemSlot.Item != null && dropItemSlot.Item.ID != dragItemSlot.Item.ID && dragItemSlot.Amount == 1)
            {
                ExchangeItems(dropItemSlot, draggedItem, draggedItemAmount);
            }
            else if (dropItemSlot.Item != null && dropItemSlot.Item.ID != dragItemSlot.Item.ID && dragItemSlot.Amount != 1)
            {
                // Add stacked shop items to the backpack and add backpack item back into shop
                shopInventory.AddItem(dropItemSlot.Item);
                dragItemSlot.Amount--;
                dropItemSlot.Item = draggedItem;
                dropItemSlot.Amount = 1;

            }
            else if (dropItemSlot.Item != null && dropItemSlot.Item.ID == dragItemSlot.Item.ID)
            {
                //Do nothing, Items are the same and you are trying to drag and drop a stack
            }

            // Dragging stacked items into backpack
            else
            {
                dragItemSlot.Amount--;
                dropItemSlot.Item = draggedItem;
                dropItemSlot.Amount = 1;
            }

        }

        else
        {
            ExchangeItems(dropItemSlot, draggedItem, draggedItemAmount);
        }
    }

    //Swap items 1 for 1
    private void ExchangeItems(ItemSlot dropItemSlot, ItemSO draggedItem, int draggedItemAmount)
    {
        dragItemSlot.Item = dropItemSlot.Item;
        dragItemSlot.Amount = dropItemSlot.Amount;

        dropItemSlot.Item = draggedItem;
        dropItemSlot.Amount = draggedItemAmount;
    }

    //Stacks items
    private void AddStacks(ItemSlot dropItemSlot)
    {
        int numAddableStacks = dropItemSlot.Item.MaximumStacks - dropItemSlot.Amount;
        int stacksToAdd = Mathf.Min(numAddableStacks, dragItemSlot.Amount);

        dropItemSlot.Amount += stacksToAdd;
        dragItemSlot.Amount -= stacksToAdd;
    }
}


