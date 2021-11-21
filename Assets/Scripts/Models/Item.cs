using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    // Might need to expose all itemObject attributes directly on the Item class
    [SerializeField] ItemObject itemObject;

    [SerializeField] Image itemImage;

    [SerializeField] private string itemName;

    private bool isNullified = false;

    [TextArea]
    public string description;

    public StatModifier EnduranceModifier { get; set; }
    public StatModifier SurvivabilityModifier { get; set; }
    public StatModifier IntelligenceModifier { get; set; }

    public string ID => itemObject.ID;

    public ItemObject ItemObject {
        get {
            return itemObject;
        } set {
            itemObject = value;
            
            if(itemObject != null)
            {
                SetUpItemDetails();
            }
        }}

    void Awake()
    {
        if (itemImage == null)
        {
            itemImage = GetComponent<Image>();
        }

        // Set up variables
        if(itemObject != null) SetUpItemDetails();
    }

    void SetUpItemDetails()
    {
        itemName = itemObject.itemName;

        description = itemObject.description;

        EnduranceModifier = itemObject.enduranceModifier;
        IntelligenceModifier = itemObject.intelligenceModifier;
        SurvivabilityModifier = itemObject.survivabilityModifier;

        itemImage.sprite = itemObject.sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        Activate();

        ClearTraitBonuses();
    }

    public void Nullify()
    {
        isNullified = true;
    }

    public void Activate()
    {
        isNullified = false;
    }

    public bool IsNullified()
    {
        return isNullified;
    }

    public void ClearTraitBonuses()
    {
        EnduranceModifier.ClearTraitBonuses();
        SurvivabilityModifier.ClearTraitBonuses();
        IntelligenceModifier.ClearTraitBonuses();
    }



    public ItemObject ItemDetails {get => itemObject;}
    public ItemObject GetItemObject()
    {
        return itemObject;
    }

    public void Equip (InventoryManager inventoryManager)
    {
        SurvivalKit survivalKit = inventoryManager.SurvivalKit;
        survivalKit.AddItem(this);
    }

    public void Unequip(InventoryManager inventoryManager)
    {
        SurvivalKit survivalKit = inventoryManager.SurvivalKit;
        survivalKit.RemoveItem(this);
    }

    public virtual Item GetCopy()
    {
        return this;
    }

}
