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

        // This might need to be changed
        EnduranceModifier = new StatModifier(itemObject.enduranceModifier);
        IntelligenceModifier = new StatModifier(itemObject.intelligenceModifier);
        SurvivabilityModifier = new StatModifier(itemObject.survivabilityModifier);

        itemImage.sprite = itemObject.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void ResetModifiers()
    // {
    //     EnduranceModifier.Value = itemObject.enduranceModifier.Value;
    //     IntelligenceModifier.Value = itemObject.intelligenceModifier.Value;
    //     SurvivabilityModifier.Value = itemObject.survivabilityModifier.Value;
    // }


    
    public ItemObject ItemDetails {get => itemObject;}
    public ItemObject GetItemObject()
    {
        return itemObject;
    }
    
}
