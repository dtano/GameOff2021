using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System;

public class CustomerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI statDisplay;
    [SerializeField] TextMeshProUGUI nameDisplay;
    [SerializeField] TextMeshProUGUI probabilityDisplay;
    // [SerializeField] TextMeshProUGUI traitsDisplay;
    [SerializeField] TraitUI traitUI;
    [SerializeField] TextMeshProUGUI customersServedCounter;
    [SerializeField] Image customerImg;
    
    [SerializeField] Animator animator;
    private Customer customer;
    //private CustomerData custData;

    private StringBuilder sb;
    private bool isActive = false;

    public bool IsActive => isActive;
    
    // Start is called before the first frame update
    void Start()
    {
        sb = new StringBuilder();
        customer = GetComponent<Customer>();

        ShowNumCustomersServed(0);

        HideUIElements();
        
        // nameDisplay.text = customer.CustomerData.Name;
        // customerImg.sprite = customer.CustomerData.Sprite;
        // Activate();

    }

    // Update is called once per frame
    void Update()
    {
        if(isActive){
            DisplayCustomerDetails();
        }
    }


    private void DisplayCustomerDetails()
    {
        CustomerData custData = customer.CustomerData;

        //Debug.Log(custData.Name);
        nameDisplay.text = custData.Name;
        customerImg.sprite = custData.Sprite;
        
        DisplayStats(custData);
        //DisplayTraits(custData);
        DisplaySurvivalProbability();
        
    }


    private void DisplayStats(CustomerData custData)
    {
        statDisplay.text = "";
        sb.Clear();

        sb.Append(String.Format("Endurance - {0:F1}\n", custData.Endurance.ModifiedValue));
        sb.Append(String.Format("Intelligence - {0:F1}\n", custData.Intelligence.ModifiedValue));
        sb.Append(String.Format("Survivability - {0:F1}\n", custData.Survivability.ModifiedValue));
        // sb.Append($"Endurance - {custData.Endurance.ModifiedValue}\n");
        // sb.Append($"Intelligence - {custData.Intelligence.ModifiedValue}\n");
        // sb.Append($"Survivability - {custData.Survivability.ModifiedValue}\n");

        statDisplay.text = sb.ToString();
    }

    public void DisplayTraits(CustomerData custData)
    {
        traitUI.DisplayTraits(custData.Traits);
    }

    private void DisplaySurvivalProbability()
    {
        int prob = (int) Math.Ceiling(customer.CalculateSurvivalProbability());
        probabilityDisplay.text = $"{prob}%";
    }

    public void HideUIElements()
    {
        statDisplay.gameObject.SetActive(false);
        nameDisplay.gameObject.SetActive(false);
        probabilityDisplay.gameObject.SetActive(false);
        traitUI.Hide();
        
    }


    public void ShowUIElements()
    {
        statDisplay.gameObject.SetActive(true);
        nameDisplay.gameObject.SetActive(true);
        probabilityDisplay.gameObject.SetActive(true);
        traitUI.Show();
        Activate();
    }

    public void ShowNumCustomersServed(int amount)
    {
        customersServedCounter.text = $"{amount}/12";
    }

    public void MakeCustomerLeaveStore()
    {
        HideUIElements();
        
        // Hide all UI text here and set animation trigger to leave
        animator.SetTrigger("LeaveStore");
    }

    public void EnterNewCustomer()
    {
        customerImg.sprite = customer.CustomerData.Sprite;
        animator.SetTrigger("EnterStore");
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
    }

    
}
