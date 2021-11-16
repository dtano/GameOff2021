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

    private ItemSlot draggedSlot;

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
        backpackInventory.OnBeginDragEvent += BeginDrag;

        //End Drag
        shopInventory.OnEndDragEvent += EndDrag;
        backpackInventory.OnEndDragEvent += EndDrag;

        //Drag
        shopInventory.OnDragEvent += Drag;
        backpackInventory.OnDragEvent += Drag;

        //Drop
        shopInventory.OnDropEvent += Drop;
        backpackInventory.ondr += Drop;

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
        /*if (shopInventory.CanAddItem(item) && BackpackInventory.RemoveItem(item))
        {*/
            item.Unequip(this);
            /*statPanel.UpdateStatValues();*/
            shopInventory.AddItem(item);
        /*}*/
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
            
            draggedSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.Icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }
    private void EndDrag(ItemSlot itemSlot)
    {
        draggedSlot = null;
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
        /*if (dropItemSlot.CanReceiveItem(draggedSlot.Item) && draggedSlot.CanReceiveItem(dropItemSlot.Item))
        {*/
            EquippableItem dragItem = draggedSlot.Item as EquippableItem;
            EquippableItem dropItem = dropItemSlot.Item as EquippableItem;

            if (draggedSlot is BackpackSlot)
            {
                if (dragItem != null) dragItem.Unequip(this);
                if (dropItem != null) dropItem.Equip(this);
            }
            if (dropItemSlot is BackpackSlot)
            {
                if (dragItem != null) dragItem.Equip(this);
                if (dropItem != null) dropItem.Unequip(this);
            }
            //updates values of stats
            //statPanel.UpdateStatValues;

            Item draggedItem = draggedSlot.Item;
            draggedSlot.Item = dropItemSlot.Item;
            dropItemSlot.Item = draggedItem;
  /*      }*/








    }
}


