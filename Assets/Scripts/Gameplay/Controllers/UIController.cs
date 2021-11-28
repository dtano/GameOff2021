using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] BackpackInventory backpackInventory;
    [SerializeField] ShopInventory shopInventory;
    [SerializeField] CustomerUI customerUI;
    [SerializeField] Button serveKitButton;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if(backpackInventory != null && customerUI != null){
            HideUIElements();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideUIElements()
    {
        customerUI?.HideUIElements();
        HideBackpackUI();

    }

    public void ShowUIElements()
    {
        customerUI?.ShowUIElements();
        ShowBackpackUI();
    }

    public void HideBackpackUI()
    {
        backpackInventory?.HideSlots();
        serveKitButton?.gameObject.SetActive(false);
    }

    public void ShowBackpackUI()
    {
        backpackInventory?.ShowSlots();
        serveKitButton?.gameObject.SetActive(true);
    }
}
