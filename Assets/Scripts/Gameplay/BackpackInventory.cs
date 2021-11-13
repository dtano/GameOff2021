using System;
using UnityEngine;

public class BackpackInventory : MonoBehaviour
{
    [SerializeField] Transform backpackSlotParent;
    [SerializeField] BackpackSlot[] backpackSlots;

	public event Action<ItemSlot> OnPointerEnterEvent;
	public event Action<ItemSlot> OnPointerExitEvent;
	public event Action<ItemSlot> OnRightClickEvent;
	public event Action<ItemSlot> OnBeginDragEvent;
	public event Action<ItemSlot> OnEndDragEvent;
	public event Action<ItemSlot> OnDragEvent;
	public event Action<ItemSlot> OnDropEvent;

    private void Start()
    {
        for (int i = 0; i < backpackSlots.Length; i++)
        {
            backpackSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            backpackSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            backpackSlots[i].OnRightClickEvent += OnRightClickEvent;
            backpackSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            backpackSlots[i].OnEndDragEvent += OnEndDragEvent;
            backpackSlots[i].OnDragEvent += OnDragEvent;
            backpackSlots[i].OnDropEvent += OnDropEvent;
        }
    }




}
