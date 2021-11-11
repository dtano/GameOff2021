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
    
    [TextArea]
    public string description;

    //[SerializeField] StatModifier enduranceModifier;
    // [SerializeField] StatModifier intelligenceModifier;
    // [SerializeField] StatModifier survivabilityModifier;

    public StatModifier EnduranceModifier { get; set; }
    public StatModifier SurvivabilityModifier { get; set; }
    public StatModifier IntelligenceModifier { get; set; }
    
    void Awake()
    {
        if(itemImage == null){
            itemImage = GetComponent<Image>();
        }

        // Set up variables
        SetUpItemDetails();
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

    // public override bool Equals(object other)
    // {
    //     //Check for null and compare run-time types.
    //     if ((other == null) || ! this.GetType().Equals(other.GetType()))
    //     {
    //         return false;
    //     }
    //     return itemObject.Equals(((Item) other).GetItemObject());
    // }


    
    public ItemObject ItemDetails {get => itemObject;}
    public ItemObject GetItemObject()
    {
        return itemObject;
    }

    // How will item affect customer survivability? 
    
}
