using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] ItemObject itemObject;
    
    [SerializeField] Image itemImage;
    
    void Awake()
    {
        if(itemImage == null){
            itemImage = GetComponent<Image>();
        }

        itemImage.sprite = itemObject.sprite;

        Debug.Log(itemObject.itemName);
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

    public ItemObject GetItemObject()
    {
        return itemObject;
    }

    // How will item affect customer survivability? 
    
}
