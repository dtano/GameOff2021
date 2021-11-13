using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    /*public CustomerStat Strength;
    public CustomerStat Agility;
    public CustomerStat Intelligence;
    public CustomerStat Vitality;*/

    [SerializeField] ShopInventory shopInventory;
    [SerializeField] BackpackInventory backpackInventory;
    //[SerializeField] StatPanel statPanel;
    [SerializeField] ItemTooltip itemTooltip;
    [SerializeField] Image draggableItem;

    private ItemSlot draggedSlot;

    private void OnValidate()
    {
        if (itemTooltip == null)
        {
            itemTooltip = FindObjectOfType<ItemTooltip>();
        }
    }

    private void Awake()
    {
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
        backpackInventory.OnBeginDragEvent += BeginDrag;

        //End Drag
        shopInventory.OnDragEvent += EndDrag;
        backpackInventory.OnDragEvent += EndDrag;

        //Drag
        shopInventory.OnDragEvent += Drag;
        backpackInventory.OnDragEvent += Drag;

        //Drop
        shopInventory.OnDragEvent += Drop;
        backpackInventory.OnDragEvent += Drop;

    }

    private void Equip (ItemSlot itemSlot)
    {
        EquipableItem equippableItem = itemSlot.Item as equippableItem;
        if (equippableItem != null)
        {
            Equip(equippableItem);
        }
    }

    private void Unequip(ItemSlot itemSlot)
    {
        EquipableItem equippableItem = itemSlot.Item as equippableItem;
        if (equippableItem != null)
        {
            Unequip(equippableItem);
        }
    }
    private void ShowTooltip(ItemSlot itemSlot)
    {
        EquipableItem equippableItem = itemSlot.Item as equippableItem;
        if (equippableItem != null)
        {
            itemTooltip.ShowTooltip(equippableItem);
        }
    }
    private void HideTooltip(ItemSlot itemSlot)
    {
        itemTooltip.HideTooltip
    }

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
        EquippableItem dragItem = draggedSlot.Item as EquippableItem;
        EquippableItem dropItem = dropItemSlot.Item as EquippableItem;

        if (draggedSlot is EquipmentSlot)
        {
            if (dragItem != null) dragItem.Unequip(this);
            if (dropItem != null) dropItem.Equip(this);
        }
        if (draggedSlot is EquipmentSlot)
        {
            if (dragItem != null) dragItem.Equip(this);
            if (dropItem != null) dropItem.Unequip(this);
        }
        
        //updates values of stats
        //statPanel.UpdateStatValues;

        Item draggedItem = draggedSlot.Item;
        draggedSlot.Item = dropItemSlot.Item;
        dropItemSlot.Item = draggedItem;

    }
}
