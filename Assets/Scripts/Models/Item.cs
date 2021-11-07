using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemObject itemObject;
    
    [SerializeField] SpriteRenderer spriteRenderer;
    
    void Awake()
    {
        if(spriteRenderer == null){
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        spriteRenderer.sprite = itemObject.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Equals(object other)
    {
        //Check for null and compare run-time types.
        if ((other == null) || ! this.GetType().Equals(other.GetType()))
        {
            return false;
        }
        return itemObject.Equals(((Item) other).GetItemObject());
    }

    public ItemObject GetItemObject()
    {
        return itemObject;
    }
}
