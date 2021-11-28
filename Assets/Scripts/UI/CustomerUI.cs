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
    [SerializeField] TextMeshProUGUI traitsDisplay;
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
        DisplayTraits(custData);
        DisplaySurvivalProbability();
        
    }


    private void DisplayStats(CustomerData custData)
    {
        statDisplay.text = "";
        sb.Clear();

        sb.Append($"Endurance - {custData.Endurance.ModifiedValue}\n");
        sb.Append($"Intelligence - {custData.Intelligence.ModifiedValue}\n");
        sb.Append($"Survivability - {custData.Survivability.ModifiedValue}\n");

        statDisplay.text = sb.ToString();
    }

    private void DisplayTraits(CustomerData custData)
    {
        traitsDisplay.text = "";
        sb.Clear();

        foreach(Trait trait in custData.Traits)
        {
            sb.Append($"{trait.Name}\n");
        }

        traitsDisplay.text = sb.ToString();
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
        traitsDisplay.transform.parent.gameObject.SetActive(false);
    }


    public void ShowUIElements()
    {
        statDisplay.gameObject.SetActive(true);
        nameDisplay.gameObject.SetActive(true);
        probabilityDisplay.gameObject.SetActive(true);
        traitsDisplay.transform.parent.gameObject.SetActive(true);
        Activate();
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
